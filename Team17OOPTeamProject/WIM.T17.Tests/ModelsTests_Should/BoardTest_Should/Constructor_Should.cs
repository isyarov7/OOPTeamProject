using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
namespace WIM.T17.Tests.BoardTest_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void PassValues_Should()
        {
            //Act
            var board = new Board("Board");

            //Assert
            Assert.AreEqual(board.Name, "Board");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Act
            string name = "Boa";
            var board = new Board(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Act
            string name = "ThrowExeptionWhenNameIsLonger";
            var board = new Board(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Act
            string name = null;
            var board = new Board(name);
        }
    }
}
