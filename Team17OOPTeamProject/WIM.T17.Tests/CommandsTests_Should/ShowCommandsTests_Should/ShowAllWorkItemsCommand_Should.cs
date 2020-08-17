using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.ShowCommands;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowAllWorkItemsCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllWorkItems()
        {
            string bugName = "MnogoLoshBug";
            string description = "BugDescription";
            List<string> stepsToProduce = new List<string>() {"Steps to produce"};
            IBug bug = new Bug(bugName, description, stepsToProduce);

            string storyTitle = "StoryTitle";
            string storyDesc = "StoryDescription";
            IStory story = new Story(storyTitle, storyDesc);

            string feedbackTitle = "FeedbackTitle";
            string feedbackDesc = "FeedbackDesc";
            int rating = 5;
            IFeedback feedback = new Feedback(feedbackTitle, feedbackTitle, rating);

            database.Bugs.Add(bug);
            database.Stories.Add(story);
            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>();

            ShowAllWorkItemsCommand command = new ShowAllWorkItemsCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***All Bugs***");
            foreach (var item in this.database.Bugs)
            {
                sb.AppendLine(item.PrintDetails());
            }
            sb.AppendLine("***All Stories***");
            foreach (var item in this.database.Stories)
            {
                sb.AppendLine(item.PrintDetails());
            }
            sb.AppendLine("***All Feedbacks***");
            foreach (var item in this.database.Feedbacks)
            {
                sb.AppendLine(item.PrintDetails());
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
