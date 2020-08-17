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
    public class ShowAllStoriesCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllStoriesCommandPrint()
        {
            string storyName = "GlashataiII";
            string description = "Some description";
            IStory story = new Story(storyName, description);

            database.Stories.Add(story);

            List<string> parameters = new List<string>();

            ShowAllStoriesCommand command = new ShowAllStoriesCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***All Stories***");
            foreach (var item in this.database.Stories)
            {
                sb.AppendLine(item.PrintDetails());
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}