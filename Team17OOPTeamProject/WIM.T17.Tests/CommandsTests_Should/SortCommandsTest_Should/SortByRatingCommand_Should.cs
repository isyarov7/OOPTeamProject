using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.SortCommands;

namespace WIM.T17.Tests.CommandsTests_Should.SortCommandsTest_Should
{
    [TestClass]
    public class SortByRatingCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void SortByRatingCommandShould()
        {
            string feedbackTitle = "FeedbackTitle";
            string description = "Description11";
            int rating = 3;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);
            
            string feedbackTitleUno = "FeedbackTitleUno";
            string descriptionUno = "Description11";
            int ratingUno = 2;
            IFeedback feedbackUno = new Feedback(feedbackTitleUno, descriptionUno, ratingUno);


            var feedbackRating = this.database.Feedbacks.OrderBy(x => x.Rating).ToList();
            var feedbackUnoRating = this.database.Feedbacks.OrderBy(x => x.Rating).ToList();

            List<string> parameters = new List<string>();

            SortByRatingCommand command = new SortByRatingCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY RATING***");
            foreach (var item in feedbackRating)
            {
                sb.AppendLine($"{item.Title}: {item.Rating}");
            }

            string expected = sb.ToString();
            string actual = command.Execute();
            Assert.AreEqual(expected, actual);
        }
    }
}