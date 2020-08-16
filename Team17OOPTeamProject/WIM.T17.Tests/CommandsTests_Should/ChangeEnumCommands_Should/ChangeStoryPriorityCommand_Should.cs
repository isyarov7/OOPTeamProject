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
    public class ChangeStoryPriorityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeStoryPriority_Should()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            Priority priority = Priority.High;
            Size size = Size.Large;
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description, priority, size);

            database.Stories.Add(story);

            string newPriority = "Low";

            List<string> parameters = new List<string>
            {
               storyName,
               newPriority.ToString()
            };

            ChangeStoryPriorityCommand command = new ChangeStoryPriorityCommand(parameters);
            command.Execute();
            Assert.AreEqual(story.Priority, newPriority);
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

            ChangeStoryPriorityCommand command = new ChangeStoryPriorityCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputStoryNameIsNULL_Should()
        {
            string storyName = null;
            string description = "MegaBadStory";
            Priority priority = Priority.High;
            Size size = Size.Large;
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description, priority, size);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
               storyName,
               priority.ToString()
            };

            ChangeStoryPriorityCommand command = new ChangeStoryPriorityCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeStoryPriority_Should()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            Priority priority = Priority.High;
            Size size = Size.Large;
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description, priority, size);

            database.Stories.Add(story);

            string newPriority = "Invalid Priority";

            List<string> parameters = new List<string>
            {
               storyName,
               newPriority
            };

            ChangeStoryPriorityCommand command = new ChangeStoryPriorityCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            Priority priority = Priority.High;
            Size size = Size.Large;
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description, priority, size);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyName
            };

            ChangeStoryPriorityCommand command = new ChangeStoryPriorityCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string storyName = "StoryNameShould";
            string description = "MegaBadStory";
            Priority priority = Priority.High;
            Size size = Size.Large;
            List<string> stepsToProduce = new List<string> { "steps" };
            var story = new Story(storyName, description, priority, size);

            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
             storyName,
             priority.ToString(),
             storyName
            };

            ChangeStoryPriorityCommand command = new ChangeStoryPriorityCommand(parameters);
            command.Execute();
        }
    }
}
