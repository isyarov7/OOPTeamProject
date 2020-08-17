using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using T17.Models.Core;
using T17.Models.Core.Contracts;

namespace WIM.T17.Tests
{
    public class BaseTestClass
    {
        protected IDatabase database = Database.Instance;
        protected IFactory factory = Factory.Instance;

        [TestInitialize]
        public void ResetState()
        {
            var instanceField = typeof(Database).GetField("instance", BindingFlags.NonPublic | BindingFlags.Static);
            var newSingleton = new Database();
            database = newSingleton;
            instanceField.SetValue(newSingleton, newSingleton);

            var factortInstanceField = typeof(Factory).GetField("instance", BindingFlags.NonPublic | BindingFlags.Static);
            var newFactorySingleton = new Factory();
            factory = newFactorySingleton;
            factortInstanceField.SetValue(newFactorySingleton, newFactorySingleton);
        }
    }
}