using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.SortCommands;

namespace WIM.T17.Tests.PrintMetodTest_Should
{
    [TestClass]
    public class SortBySeverityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void SortBySeverityCommandShould()
        {
            string bugName = "BugNameShould";
            string description = "Description11";
            List<string> stepToProduce = new List<string> { "ONe" };
            IBug bug = new Bug(bugName, description, stepToProduce);

            var bugsPriority = this.database.Bugs.OrderByDescending(x => x.Severity).ToList();

            List<string> parameters = new List<string>();

            SortBySeverityCommand command = new SortBySeverityCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY SEVERITY***");
            foreach (var item in bugsPriority)
            {
                sb.AppendLine($"{item.Title}: {item.Severity}");
            }

            string expected = sb.ToString();
            string actual = command.Execute();
            Assert.AreEqual(expected, actual);
        }
    }
}
