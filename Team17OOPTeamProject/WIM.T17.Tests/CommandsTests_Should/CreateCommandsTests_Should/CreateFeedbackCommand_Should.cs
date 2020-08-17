using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreateFeedbackCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreateFeedbackCommand()
        {
            string feedbackTitle = "MnogoLoshFeedback";
            string description = "Feedback description";
            int rating = 5;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
                {
                    feedbackTitle,
                    description,
                    rating.ToString()
                };

            CreateFeedbackCommand command = new CreateFeedbackCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Feedbacks.Any(x => x.Title == feedbackTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string feedbackTitle = "MnogoLoshFeedback";
            string description = "Feedback description";
            int rating = 5;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
                {
                    feedbackTitle,
                    description
                };

            CreateFeedbackCommand command = new CreateFeedbackCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Feedbacks.Any(x => x.Title == feedbackTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string feedbackTitle = "MnogoLoshFeedback";
            string description = "Feedback description";
            int rating = 5;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
                {
                    feedbackTitle,
                    description,
                    rating.ToString(),
                    description
                };

            CreateFeedbackCommand command = new CreateFeedbackCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Feedbacks.Any(x => x.Title == feedbackTitle));
        }
    }
}
