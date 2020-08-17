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
    public class ChangeStoryStatusCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeStoryStatus_Should()
        {
            //Default Status: NotDone
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            string newStatus = "Done";

            List<string> parameters = new List<string>
            {
               storyName,
               newStatus.ToString()
            };

            ChangeStoryStatusCommand command = new ChangeStoryStatusCommand(parameters);
            command.Execute();
            Assert.AreEqual(story.StoryStatus, StoryStatus.Done);
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

            ChangeStoryStatusCommand command = new ChangeStoryStatusCommand(parameters);
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

            ChangeStoryStatusCommand command = new ChangeStoryStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeStoryStatus_Should()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description);

            database.Stories.Add(story);

            string newStatus = "Invalid Priority";

            List<string> parameters = new List<string>
            {
               storyName,
               newStatus
            };

            ChangeStoryStatusCommand command = new ChangeStoryStatusCommand(parameters);
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

            ChangeStoryStatusCommand command = new ChangeStoryStatusCommand(parameters);
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

            ChangeStoryStatusCommand command = new ChangeStoryStatusCommand(parameters);
            command.Execute();
        }
    }
}
