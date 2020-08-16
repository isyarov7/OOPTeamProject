using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.ChangeEnumCommands_Should
{
    [TestClass]
    public class ChangeFeedbackStatusCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeFeedbackStatus_Should()
        {
            string feedbackTitle = "FeedbackNameShould";
            string description = "MegaBadFeedback";
            int rating = 4;
            var feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            FeedbackStatus feedbackStatus = FeedbackStatus.Scheduled;

            List<string> parameters = new List<string>
            {
               feedbackTitle,
             feedbackStatus.ToString()
            };

            ChangeFeedbackStatusCommand command = new ChangeFeedbackStatusCommand(parameters);
            command.Execute();
            Assert.IsTrue(feedback.FeedbackStatus.Equals(feedbackStatus));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeFeedbackInvalidParameters_Should()
        {
            string bugName = "BugNameShould";

            List<string> parameters = new List<string>
            {
               bugName
            };

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputFeedbackNameIsNULL_Should()
        {
            string feedbackTitle = null;
            string description = "MegaBadFeedback";
            int rating = 4;
            var feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            FeedbackStatus feedbackStatus = FeedbackStatus.Scheduled;

            List<string> parameters = new List<string>
            {
               feedbackTitle,
             feedbackStatus.ToString()
            };

            ChangeFeedbackStatusCommand command = new ChangeFeedbackStatusCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeFeedbackStatus_Should()
        {
            string feedbackTitle = "FeedbackTitle";
            string description = "MegaBadFeedback";
            int rating = 4;
            var feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            string newStatus = "Invalid Status";

            List<string> parameters = new List<string>
            {
               feedbackTitle,
               newStatus
            };

            ChangeFeedbackStatusCommand command = new ChangeFeedbackStatusCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string feedbackTitle = "FeedbackTitle";
            string description = "MegaBadFeedback";
            int rating = 4;
            var feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
            {
                feedbackTitle
            };

            ChangeFeedbackStatusCommand command = new ChangeFeedbackStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string feedbackTitle = "FeedbackShould";
            string description = "MegaBadFeedback";
            int rating = 4;
            var feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            FeedbackStatus feedbackStatus = FeedbackStatus.Scheduled;

            List<string> parameters = new List<string>
            {
             feedbackTitle,
             feedbackStatus.ToString(),
             feedbackTitle
            };

            ChangeFeedbackStatusCommand command = new ChangeFeedbackStatusCommand(parameters);
            command.Execute();
        }
    }
}
