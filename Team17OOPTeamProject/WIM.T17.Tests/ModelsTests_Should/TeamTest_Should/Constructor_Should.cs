using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;

namespace WIM.T17.Tests.TeamTest_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void PassValues_Should()
        {
            //Act
            string name = "TeamTigrite";
            var team = new Team(name);

            //Assert
            Assert.AreEqual(team.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Act
            string name = "Tig";
            var team = new Team(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Act
            string name = "ThrowExeptionWhenNameIsLonger";
            var team = new Team(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Act
            string name = null;
            var team = new Team(name);
        }
    }
}