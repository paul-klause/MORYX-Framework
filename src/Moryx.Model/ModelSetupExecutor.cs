// Copyright (c) 2023, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moryx.Model.Attributes;
using Moryx.Model.Configuration;
using Moryx.Model.Repositories;
using Moryx.Tools;

namespace Moryx.Model
{
    /// <inheritdoc />
    internal class ModelSetupExecutor<TContext> : IModelSetupExecutor
        where TContext : DbContext
    {
        private readonly IDbContextManager _dbContextManager;
        private readonly IModelSetup[] _setups;

        /// <summary>
        /// Creates a new instance of <see cref="ModelSetupExecutor{TContext}"/>
        /// </summary>
        /// <param name="dbContextManager"></param>
        public ModelSetupExecutor(IDbContextManager dbContextManager)
        {
            _dbContextManager = dbContextManager;

            // Load ModelSetups TODO: Load internals
            _setups = ReflectionTool.GetPublicClasses<IModelSetup>(delegate (Type type)
            {
                // Try to read context from attribute
                var setupAttr = type.GetCustomAttribute<ModelSetupAttribute>();
                return setupAttr != null && setupAttr.TargetContext == typeof(TContext);
            }).Select(s => (IModelSetup)Activator.CreateInstance((Type) s)).ToArray();
        }

        /// <inheritdoc />
        public IReadOnlyList<IModelSetup> GetAllSetups() => _setups;

        /// <inheritdoc />
        public Task Execute(IDatabaseConfig config, IModelSetup setup, string setupData)
        {
            var unitOfWorkFactory = new UnitOfWorkFactory<TContext>(_dbContextManager);
            using var uow = unitOfWorkFactory.Create(config);

            return setup.Execute(uow, setupData);
        }
    }
}