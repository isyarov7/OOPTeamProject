using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.SortCommands;

namespace WIM.T17.Tests.CommandsTests_Should.SortCommandsTest_Should
{
    [TestClass]
    public class SortByPriorityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void SortByPriorityCommandShould()
        {
            string bugName = "BugNameShould";
            string description = "Description11";
            List<string> stepToProduce = new List<string> { "ONe" };
            IBug bug = new Bug(bugName, description, stepToProduce);

            string storyName = "StotyNameShould";
            string stDescription = "Description11";
            IStory story = new Story(storyName, stDescription);

            var bugPriority = this.database.Bugs.OrderByDescending(x => x.Priority).ToList();
            var storyPriority = this.database.Stories.OrderByDescending(x => x.Priority).ToList();

            List<string> parameters = new List<string>();

            SortByPriorityCommand command = new SortByPriorityCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY PRIORITY***");
            foreach (var item in bugPriority)
            {
                sb.AppendLine($"{item.Title}: {item.Priority}");
            }

            foreach (var item in storyPriority)
            {
                sb.AppendLine($"{item.Title}: {item.Priority}");
            }

            string expected = sb.ToString();
            string actual = command.Execute();
            Assert.AreEqual(expected, actual);
        }
    }
}
