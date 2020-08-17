using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;

namespace WIM.T17.Tests.MemberTest_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void PassValues_Should()
        {
            //Act
            string name = "Tigura88";
            var member = new Member(name);

            //Assert
            Assert.AreEqual(member.Name, name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Act
            string name = "Tig";
            var member = new Member(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Act
            string name = "ThrowExeptionWhenNameIsLonger";
            var member = new Member(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Act
            string name = null;
            var member = new Member(name);
        }
    }
}
