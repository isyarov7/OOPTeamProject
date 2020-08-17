using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowAllTeamBoardsCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllTeamBoardsPrint()
        {
            string teamName = "Tigrite88";
            ITeam team = new Team(teamName);

            string boardName = "Board";
            IBoard board = new Board(boardName);

            database.Teams.Add(team);
            database.Boards.Add(board);
            team.Boards.Add(board);

            List<string> parameters = new List<string>
            {
                teamName
            };

            ShowAllTeamBoardsCommand command = new ShowAllTeamBoardsCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine($"***TEAM: {teamName}***");
            sb.AppendLine("***BOARDS***");
            foreach (var item in team.Boards)
            {
                sb.AppendLine(item.PrintDetails());
                sb.AppendLine("#############");
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
