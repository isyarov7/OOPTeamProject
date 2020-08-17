using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands;
using T17.Models.Models;
using T17.Models.Models.Contracts;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowTeamActivityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowTeamActivity()
        {
            string teamName = "Tigrite23";
            ITeam team = new Team(teamName);

            database.Teams.Add(team);

            List<string> parameters = new List<string>()
            {
                teamName
            };

            ShowTeamActivityCommand command = new ShowTeamActivityCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine($"***TEAM: {teamName}***");
            sb.AppendLine(team.PrintHistory());
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenNameIsNull()
        {
            string teamName = null;
            ITeam team = new Team(teamName);

            database.Teams.Add(team);

            List<string> parameters = new List<string>()
            {
                teamName
            };

            ShowTeamActivityCommand command = new ShowTeamActivityCommand(parameters);

            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenLessParametersPassed()
        {
            string teamName = "Tigrite23";
            ITeam team = new Team(teamName);

            database.Teams.Add(team);

            List<string> parameters = new List<string>()
            {
            };

            ShowTeamActivityCommand command = new ShowTeamActivityCommand(parameters);

            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenMoreParametersPassed()
        {
            string teamName = "Tigrite23";
            ITeam team = new Team(teamName);

            database.Teams.Add(team);

            List<string> parameters = new List<string>()
            {
                teamName,
                teamName
            };

            ShowTeamActivityCommand command = new ShowTeamActivityCommand(parameters);

            command.Execute();
        }
    }
}
