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
    public class ShowAllBoardsCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllBoard()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            database.Boards.Add(board);

            List<string> parameters = new List<string>();

            ShowAllBoardsCommand command = new ShowAllBoardsCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***All Boards***");
            foreach (var item in this.database.Boards)
            {
                sb.AppendLine(item.PrintDetails());
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
