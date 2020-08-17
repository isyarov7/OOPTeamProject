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
    public class ShowAllTeamMembersCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllTeamMembersPrint()
        {
            string teamName = "Tigrite88";
            ITeam team = new Team(teamName);

            string memberName = "Tigura69";
            IMember member = new Member(memberName);

            database.Teams.Add(team);
            database.Members.Add(member);
            team.Members.Add(member);

            List<string> parameters = new List<string>
            {
                teamName
            };

            ShowAllTeamMembersCommand command = new ShowAllTeamMembersCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine($"***TEAM: {teamName}***");
            sb.AppendLine("***MEMBERS***");
            foreach (var item in team.Members)
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
