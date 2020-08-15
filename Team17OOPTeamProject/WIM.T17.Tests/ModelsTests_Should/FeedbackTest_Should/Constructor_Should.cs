using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject;

namespace WIM.T17.Tests.FeedbackTest_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void PassValues_Should()
        {
            //Arrage
            string title = "FeedbackTitleShould";
            string description = "Very nice feedback";
            int rating = 5;


            //Act
            var feedback = new Feedback(title, description, rating);

            //Assert
            Assert.AreEqual(feedback.Title, "FeedbackTitleShould");
            Assert.AreEqual(feedback.Description, "Very nice feedback");
            Assert.AreEqual(feedback.Rating, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenTitleIsShort_Should()
        {
            //Arrage
            string title = "Fee";
            string description = "Very nice feedback";
            int rating = 5;


            //Act
            var feedback = new Feedback(title, description, rating);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenTitleIsLonger_Should()
        {
            //Arrage
            string title = "StoryTiStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangetleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRange";
            string description = "Very nice feedback";
            int rating = 5;

            //Act
            var feedback = new Feedback(title, description, rating);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenTitleIsNull_Should()
        {
            //Arrage
            string title = null;
            string description = "Very nice feedback";
            int rating = 5;

            //Act
            var feedback = new Feedback(title, description, rating);
        }

        [TestMethod]
        public void DescriptionPassValues_Should()
        {
            //Arrage
            string title = "FeedbackTitleShould";
            string description = "Very nice feedback";
            int rating = 5;

            //Act
            var feedback = new Feedback(title, description, rating);

            //Assert         
            Assert.AreEqual(feedback.Description, "Very nice feedback");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenDescriptionIsShort_Should()
        {
            //Arrage
            string title = "FeedbackTitle";
            string description = "Very";
            int rating = 5;

            //Act
            var feedback = new Feedback(title, description, rating);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenDescriptionIsLonge_Should()
        {
            //Arrage
            string title = "BugTitle";
            string description = "Very nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story";
            int rating = 5;

            //Act
            var feedback = new Feedback(title, description, rating);
        }

        [TestMethod]
        public void RatingPassValues_Should()
        {
            //Arrage
            string title = "FeedbackTitleShould";
            string description = "Very nice feedback";
            int rating = 5;

            //Act
            var feedback = new Feedback(title, description, rating);

            //Assert         
            Assert.AreEqual(feedback.Rating, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenRatingIsBiggerThanFive_Should()
        {
            //Arrage
            string title = "FeedbackTitle";
            string description = "Very nice feedback";
            int rating = 6;

            //Act
            var feedback = new Feedback(title, description, rating);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenRatingIsLessThanZero_Should()
        {
            //Arrage
            string title = "FeedbackTitle";
            string description = "Very nice feedback";
            int rating = -1;

            //Act
            var feedback = new Feedback(title, description, rating);
        }
    }
}
