using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using WIM.T17.Commands.AddCommands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddBoardToTeamCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void AddsBoardToTeamCommand_Should()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string teamName = "TeamName";
            ITeam team = new Team(teamName);

            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                boardName,
                teamName
            };

            AddBoardToTeamCommand command = new AddBoardToTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(team.Boards.Any(x => x.Name == boardName));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenBoardNameIsNull()
        {
            string boardName = null;
            IBoard board = new Board(boardName);

            string teamName = "TeamName";
            ITeam team = new Team(teamName);

            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                boardName,
                teamName
            };

            AddBoardToTeamCommand command = new AddBoardToTeamCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenTeamNameIsNull()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string teamName = null;
            ITeam team = new Team(teamName);

            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                boardName,
                teamName
            };

            AddBoardToTeamCommand command = new AddBoardToTeamCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string teamName = "TeamName";
            ITeam team = new Team(teamName);

            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                boardName
            };

            AddBoardToTeamCommand command = new AddBoardToTeamCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string teamName = "TeamName";
            ITeam team = new Team(teamName);

            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                boardName,
                teamName,
                boardName
            };

            AddBoardToTeamCommand command = new AddBoardToTeamCommand(parameters);
            command.Execute();
        }
    }
}
