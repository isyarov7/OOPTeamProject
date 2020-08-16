﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreateBoardInTeamCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreateBoardInTeamCommandShould()
        {
            string boardName = "BoardName";
            string teamName = "TeamName";
            IBoard board = new Board(boardName);
            ITeam team = new Team(teamName);
            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
                {
                    boardName,
                    teamName
                };


            CreateBoardInTeamCommand command = new CreateBoardInTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Boards.Any(x => x.Name == boardName));
        }
        
           [TestMethod]
           [ExpectedException(typeof(ArgumentException))]
           public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
           {
            string boardName = "BoardName";
            string teamName = "TeamName";
            IBoard board = new Board(boardName);
            ITeam team = new Team(teamName);
            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
                {
                    boardName
                };


            CreateBoardInTeamCommand command = new CreateBoardInTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Teams.Any(x => x.Name == boardName));
        }
        
           [TestMethod]
           [ExpectedException(typeof(ArgumentException))]
           public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
           {
            string boardName = "BoardName";
            string teamName = "TeamName";
            IBoard board = new Board(boardName);
            ITeam team = new Team(teamName);
            database.Boards.Add(board);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
                {
                    boardName,
                    teamName,
                    boardName
                };


            CreateBoardInTeamCommand command = new CreateBoardInTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Teams.Any(x => x.Name == boardName));
        }
    }
}
