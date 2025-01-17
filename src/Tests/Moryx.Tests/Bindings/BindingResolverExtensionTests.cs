// Copyright (c) 2023, Phoenix Contact GmbH & Co. KG
// Licensed under the Apache License, Version 2.0

using Moryx.Bindings;
using NUnit.Framework;

namespace Moryx.Tests.Bindings
{
    [TestFixture]
    public class BindingResolverExtensionTests
    {
        private IBindingResolverChain _resolver;

        [SetUp]
        public void Setup()
        {
            _resolver = new ReflectionResolver(nameof(SomeComplexClass.SubClass));
        }

        [TestCase(1, Description = "Call extend (1 time) to extend chain")]
        [TestCase(2, Description = "Call extend (2 times) to extend chain")]
        [TestCase(3, Description = "Call extend (3 times) to extend chain")]
        public void CallExtendExtendsChain(int extendCount)
        {
            // Arrange
            var data = CreateData();
            for (var i = 0; i < extendCount; ++i)
            {
                _resolver.Extend(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            }

            // Act
            var value = _resolver.Resolve(data) as SomeComplexClass;

            // Assert
            Assert.NotNull(value);
            Assert.AreEqual(2, value.Value);
            Assert.AreEqual(2, CountChainLinks(_resolver));
        }

        [TestCase(1, Description = "Call append (1 time) to append an item to chain")]
        [TestCase(2, Description = "Call append (2 times) to append an item to chain")]
        [TestCase(3, Description = "Call append (3 times) to append an item to chain")]
        public void CallAppendAppendsItemToChain(int appendCount)
        {
            // Arrange
            var data = CreateData();
            for (var i = 0; i < appendCount; ++i)
            {
                _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            }

            // Act
            var value = _resolver.Resolve(data) as SomeComplexClass;

            // Assert
            Assert.NotNull(value);
            Assert.AreEqual(appendCount + 1, value.Value);
            Assert.AreEqual(appendCount + 1, CountChainLinks(_resolver));
        }

        [TestCase(1, Description = "Call insert (1 time) to insert an item into chain")]
        [TestCase(2, Description = "Call insert (2 times) to insert an item into chain")]
        [TestCase(3, Description = "Call insert (3 times) to insert an item into chain")]
        public void CallInsertInsertItemIntoChain(int insertCount)
        {
            // Arrange
            var data = CreateData();
            for (var i = 0; i < insertCount; ++i)
            {
                _resolver.Insert(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            }

            // Act
            var value = _resolver.Resolve(data) as SomeComplexClass;

            // Assert
            Assert.NotNull(value);
            Assert.AreEqual(insertCount + 1, value.Value);
            Assert.AreEqual(insertCount + 1, CountChainLinks(_resolver));
        }

        [Test(Description = "Call replace to replace an item from chain")]
        public void CallReplaceReplacesItemFromChain()
        {
            // Arrange
            var data = CreateData();
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));

            // Act
            _resolver.NextResolver.NextResolver.Replace(new SomeComplexClassResolver());
            var value = _resolver.Resolve(data) as SomeComplexClass;

            // Assert
            Assert.NotNull(value);
            Assert.AreEqual(300, value.Value);
            Assert.AreEqual(4, CountChainLinks(_resolver));
        }

        [TestCase(0, Description = "Call remove (0 times) to remove an item from chain")]
        [TestCase(1, Description = "Call remove (1 time) to remove an item from chain")]
        [TestCase(2, Description = "Call remove (2 times) to remove an item from chain")]
        [TestCase(3, Description = "Call remove (3 times) to remove an item from chain")]
        public void CallRemoveRemovesItemFromChain(int removeCount)
        {
            // Arrange
            var data = CreateData();
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));
            _resolver.Append(new ReflectionResolver(nameof(SomeComplexClass.SubClass)));

            // Act
            for (var i = 0; i < removeCount; ++i)
            {
                _resolver.NextResolver.Remove();
            }
            var value = _resolver.Resolve(data) as SomeComplexClass;

            // Assert
            Assert.NotNull(value);
            Assert.AreEqual(5 - removeCount, value.Value);
            Assert.AreEqual(5 - removeCount, CountChainLinks(_resolver));
        }

        private int CountChainLinks(IBindingResolverChain chain)
        {
            var links = 0;
            var currentChainLink = chain;
            while (currentChainLink != null)
            {
                ++links;
                currentChainLink = currentChainLink.NextResolver;
            }

            return links;
        }

        private SomeComplexClass CreateData()
        {
            return new SomeComplexClass
            {
                Value = 0,
                SubClass = new SomeComplexClass
                {
                    Value = 1,
                    SubClass = new SomeComplexClass
                    {
                        Value = 2,
                        SubClass = new SomeComplexClass
                        {
                            Value = 3,
                            SubClass = new SomeComplexClass
                            {
                                Value = 4,
                                SubClass = new SomeComplexClass
                                {
                                    Value = 5,
                                    SubClass = null
                                }
                            }
                        },
                        OtherSubClass = new SomeComplexClass
                        {
                            Value = 200,
                            SubClass = new SomeComplexClass
                            {
                                Value = 300,
                                SubClass = new SomeComplexClass
                                {
                                    Value = 400,
                                    SubClass = null
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
