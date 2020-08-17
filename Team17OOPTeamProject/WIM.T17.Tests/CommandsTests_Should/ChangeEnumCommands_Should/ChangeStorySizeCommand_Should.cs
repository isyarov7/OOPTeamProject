using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.ChangeEnumCommands_Should
{
    [TestClass]
    public class ChangeStorySizeCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeStorySize_Should()
        {
            //Default Size: Large
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            string newSize = "Medium";

            List<string> parameters = new List<string>
            {
               storyName,
               newSize.ToString()
            };

            ChangeStorySizeCommand command = new ChangeStorySizeCommand(parameters);
            command.Execute();
            Assert.AreEqual(story.Size, Size.Medium);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeStoryInvalidParameters_Should()
        {
            string storyName = "StoryShould";

            List<string> parameters = new List<string>
            {
               storyName
            };

            ChangeStorySizeCommand command = new ChangeStorySizeCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputStoryNameIsNULL_Should()
        {
            string storyName = null;
            string description = "MegaBadStory";
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
               storyName,
               description
            };

            ChangeStorySizeCommand command = new ChangeStorySizeCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeStorySize_Should()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            string newSize = "Invalid Priority";

            List<string> parameters = new List<string>
            {
               storyName,
               newSize
            };

            ChangeStorySizeCommand command = new ChangeStorySizeCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyName
            };

            ChangeStorySizeCommand command = new ChangeStorySizeCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            Priority priority = Priority.High;
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
             storyName,
             priority.ToString(),
             storyName
            };

            ChangeStorySizeCommand command = new ChangeStorySizeCommand(parameters);
            command.Execute();
        }
    }
}
