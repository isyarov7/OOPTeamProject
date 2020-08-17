using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.ChangeEnumCommands_Should
{
    [TestClass]
    public class ChangeFeedbackRatingCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeFeedbackRating_Should()
        {
            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);


            database.Feedbacks.Add(feedback);

            string newRating = "3";

            List<string> parameters = new List<string>
            {
               feedbackTitle,
               newRating
            };

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
            command.Execute();
            Assert.IsTrue(feedback.Rating.Equals(int.Parse(newRating)));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputFeedbackNameIsNULL_Should()
        {
            string feedbackTitle = null;
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);


            database.Feedbacks.Add(feedback);

            string newRating = "3";

            List<string> parameters = new List<string>
            {
               feedbackTitle,
               newRating
            };

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenDescIsNULL_Should()
        {
            string feedbackTitle = "feedbackTitle";
            string description = null;
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);


            database.Feedbacks.Add(feedback);

            string newRating = "3";

            List<string> parameters = new List<string>
            {
               feedbackTitle,
               newRating
            };

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BiggerRating_Should()
        {
            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = 6;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);


            database.Feedbacks.Add(feedback);

            string newRating = "6";

            List<string> parameters = new List<string>
            {
               feedbackTitle,
               newRating
            };

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SmallerRating_Should()
        {
            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = -1;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);


            database.Feedbacks.Add(feedback);

            string newRating = "-1";

            List<string> parameters = new List<string>
            {
               feedbackTitle,
               newRating
            };

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
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

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
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

            ChangeFeedbackRatingCommand command = new ChangeFeedbackRatingCommand(parameters);
            command.Execute();
        }
    }
}