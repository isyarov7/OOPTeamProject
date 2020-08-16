using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreateStoryCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreateStoryCommand()
        {
            string storyTitle = "MnogoLoshoStory";
            string description = "Story description";
            IStory story = new Story(storyTitle, description);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
                {
                    storyTitle,
                    description,
                };

            CreateStoryCommand command = new CreateStoryCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Stories.Any(x => x.Title == storyTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string storyTitle = "MnogoLoshoStory";
            string description = "Story description";
            IStory story = new Story(storyTitle, description);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
                {
                    storyTitle
                };

            CreateStoryCommand command = new CreateStoryCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Stories.Any(x => x.Title == storyTitle));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string storyTitle = "MnogoLoshoStory";
            string description = "Story description";
            IStory story = new Story(storyTitle, description);

            database.Stories.Add(story);
            string newParam = "newParam";
            List<string> parameters = new List<string>
                {
                    storyTitle,
                    description,
                    newParam
                };

            CreateStoryCommand command = new CreateStoryCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Stories.Any(x => x.Title == storyTitle));
        }
    }
}
