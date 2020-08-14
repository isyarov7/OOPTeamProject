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
            var member = new Member("Tigura88");

            //Assert
            Assert.AreEqual(member.Name, "Tigura88");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Act
            var member = new Member("Tig");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Act
            var member = new Member("ThrowExeptionWhenNameIsLonger");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Act
            var member = new Member(null);
        }
    }
}
