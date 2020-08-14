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
            var team = new Team("Tigrite");

            //Assert
            Assert.AreEqual(team.Name, "Tigrite");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Act
            var team = new Team("Tig");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Act
            var team = new Team("ThrowExeptionWhenNameIsLonger");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Act
            var team = new Team(null);
        }
    }
}