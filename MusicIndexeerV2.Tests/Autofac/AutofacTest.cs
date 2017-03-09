using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MusicIndexeerV2.Autofac;
using NUnit.Framework;

namespace MusicIndexeerV2.Tests.Autofac
{
    [TestFixture]
    public class AutofacTest
    {
        [Test]
        public void Autofac_BuildContainer_NoExceptionAndCanResolveMostImportantItems()
        {
            // Arrange
            var amountResolved = 0;

            // Act + // Assert
            Assert.DoesNotThrow(() =>
            {
                using (var scope = AutofacScope.Scope)
                {
                    foreach (
                        var type in
                        Assembly.GetAssembly(typeof(FormMain)).GetTypes()
                            .Where(n => n.Name.StartsWith("Form")).Union(Assembly.GetAssembly(typeof(FormMain)).GetTypes()
                            .Where(n => n.IsInterface && (n.Name.EndsWith("Repository") || n.Name.EndsWith("Facade")))))
                    {
                        scope.Resolve(type);
                        amountResolved++;
                    }
                }
            });
            Console.Write($"Autofac resolved {amountResolved} items.");
            Assert.NotZero(amountResolved);
        }
    }
}
