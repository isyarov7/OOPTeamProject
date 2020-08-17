using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.SortCommands;

namespace WIM.T17.Tests.CommandsTests_Should.SortCommandsTest_Should
{
    [TestClass]
    public class SortBySizeCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void SortBySizeCommandShould()
        {
            string storyName = "StotyNameShould";
            string stDescription = "Description11";
            IStory story = new Story(storyName, stDescription);


            var storyPriority = this.database.Stories.OrderByDescending(x => x.Priority).ToList();

            List<string> parameters = new List<string>();

            SortBySizeCommand command = new SortBySizeCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY SIZE***");
            foreach (var item in storyPriority)
            {
                sb.AppendLine($"{item.Title}: {item.Size}");
            }

            string expected = sb.ToString();
            string actual = command.Execute();
            Assert.AreEqual(expected, actual);
        }
    }
}
