using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using WIM.T17.Commands.ShowCommands;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowBoardActivityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllBoards()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            database.Boards.Add(board);

            List<string> parameters = new List<string>()
            {
                boardName
            };

            ShowBoardActivityCommand command = new ShowBoardActivityCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine($"***BOARD: {boardName}***");
            sb.AppendLine(board.PrintHistory());
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenNameIsNull()
        {
            string boardName = null;
            IBoard board = new Board(boardName);

            database.Boards.Add(board);

            List<string> parameters = new List<string>()
            {
                boardName
            };

            ShowBoardActivityCommand command = new ShowBoardActivityCommand(parameters);

            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenLessParametersPassed()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            database.Boards.Add(board);

            List<string> parameters = new List<string>()
            {
            };

            ShowBoardActivityCommand command = new ShowBoardActivityCommand(parameters);

            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenMoreParametersPassed()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            database.Boards.Add(board);

            List<string> parameters = new List<string>()
            {
                boardName,
                boardName
            };

            ShowBoardActivityCommand command = new ShowBoardActivityCommand(parameters);

            command.Execute();
        }
    }
}
