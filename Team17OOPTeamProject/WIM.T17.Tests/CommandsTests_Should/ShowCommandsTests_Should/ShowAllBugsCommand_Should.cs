using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.ShowCommands;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowAllBugsCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllBugsShould()
        {
            string bugName = "MnogoLoshBug";
            string description = "NeznamKakvoSeSluchva";
            List<string> stepsToProduce = new List<string> { "Zashto", "Stana", "taka" };
            IBug bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>();

            ShowAllBugsCommand command = new ShowAllBugsCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***All Bugs***");
            foreach (var item in this.database.Bugs)
            {
                sb.AppendLine(item.PrintDetails());
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
