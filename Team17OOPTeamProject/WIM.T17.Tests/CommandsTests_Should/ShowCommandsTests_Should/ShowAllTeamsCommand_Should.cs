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
    public class ShowAllTeamsCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllTeams()
        {
            string teamName = "TeamName23";
            ITeam team = new Team(teamName);

            database.Teams.Add(team);

            List<string> parameters = new List<string>();

            ShowAllTeamsCommand command = new ShowAllTeamsCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***All Teams***");
            foreach (var item in this.database.Teams)
            {
                sb.AppendLine(item.PrintDetails());
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
