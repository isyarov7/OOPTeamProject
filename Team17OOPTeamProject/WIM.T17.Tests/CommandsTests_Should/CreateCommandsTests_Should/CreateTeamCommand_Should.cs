using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using T17.Models.Models.Contracts;
using T17.Models.Models;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreateTeamCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreateTeamCommand()
        {
            string name = "TeamName";
            ITeam team = new Team(name);

            database.Teams.Add(team);

            List<string> parameters = new List<string>
                {
                    name
                };

            CreateTeamCommand command = new CreateTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Teams.Any(x => x.Name == name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string name = "TeamName";
            ITeam team = new Team(name);

            database.Teams.Add(team);

            List<string> parameters = new List<string>
                {
                };

            CreateTeamCommand command = new CreateTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Teams.Any(x => x.Name == name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string name = "TeamName";
            ITeam team = new Team(name);

            database.Teams.Add(team);

            List<string> parameters = new List<string>
                {
                    name,
                    name
                };

            CreateTeamCommand command = new CreateTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Teams.Any(x => x.Name == name));
        }
    }
}
