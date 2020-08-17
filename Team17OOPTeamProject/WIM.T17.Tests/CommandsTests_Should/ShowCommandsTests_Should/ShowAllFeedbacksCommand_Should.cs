using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.ShowCommands;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowAllFeedbacksCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllFeedbacksCommandPrint()
        {
            string feedbackName = "FeedbackName";
            string description = "Ne znam kakvo";
            int rating = 3;
            IFeedback feedback = new Feedback(feedbackName, description, rating);

            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>();

            ShowAllFeedbacksCommand command = new ShowAllFeedbacksCommand(parameters);

            var sb = new StringBuilder();
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
