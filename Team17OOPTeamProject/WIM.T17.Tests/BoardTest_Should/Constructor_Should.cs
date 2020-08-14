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
            var board = new Board("Boa");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Act
            var board = new Board("ThrowExeptionWhenNameIsLonger");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Act
            var board = new Board(null);
        }
    }
}
