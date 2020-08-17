using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.AddCommands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddPersonToTeamCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void AddsPersonToTeamCommand_Should()
        {
            string memberName = "Tigura88";
            IMember member = new Member(memberName);

            string teamName = "Tigrite";
            ITeam team = new Team(teamName);

            database.Members.Add(member);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                memberName,
                teamName
            };

            AddPersonToTeamCommand command = new AddPersonToTeamCommand(parameters);
            command.Execute();
            Assert.IsTrue(team.Members.Any(x => x.Name == memberName));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenMemberNameIsNull()
        {
            string memberName = null;
            IMember member = new Member(memberName);

            string teamName = "Tigrite";
      
            List<string> parameters = new List<string>
            {
                memberName,
                teamName
            };

            AddPersonToTeamCommand command = new AddPersonToTeamCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenTeamNameIsNull()
        {
            string memberName = "Tigura88";
            IMember member = new Member(memberName);

            string teamName = null;
            ITeam team = new Team(teamName);

            database.Members.Add(member);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                memberName,
                teamName
            };

            AddPersonToTeamCommand command = new AddPersonToTeamCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string memberName = "Tigura88";
            IMember member = new Member(memberName);

            string teamName = "Tigrite";
            ITeam team = new Team(teamName);

            database.Members.Add(member);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                memberName
            };

            AddPersonToTeamCommand command = new AddPersonToTeamCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string memberName = "Tigura88";
            IMember member = new Member(memberName);

            string teamName = "Tigrite";
            ITeam team = new Team(teamName);

            database.Members.Add(member);
            database.Teams.Add(team);

            List<string> parameters = new List<string>
            {
                memberName,
                teamName,
                memberName
            };

            AddPersonToTeamCommand command = new AddPersonToTeamCommand(parameters);
            command.Execute();
        }
    }
}
