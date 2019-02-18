﻿using System.Collections.Generic;
using Marvin.Modules;

namespace Marvin.AbstractionLayer.Resources
{
    /// <summary>
    /// Resource initializers are used to create an initial set of resources. 
    /// This will be used by the module console of the resource management.
    /// </summary>
    public interface IResourceInitializer : IConfiguredPlugin<ResourceInitializerConfig>
    {
        /// <summary>
        /// Name of this initializer
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Short description for this initializer
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Within this method, the resource trees should be created
        /// It is only necessary to return the roots
        /// </summary>
        IReadOnlyList<Resource> Execute(IResourceGraph graph);
    }
}
