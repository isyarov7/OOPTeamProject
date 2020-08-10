using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject;

namespace WIM.T17.Tests.FeedbackTest
{
    class FeedbackTest
    {
        [TestMethod]
        public void IsTitleTheSameAsExpected()
        {
            Feedback feedback = new Feedback("Title", new List<string>() { "steps" }, 10);

            string expected = "Title";
            string actual = feedback.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAdvanceStatusCorrect()
        {
            Feedback feedback = new Feedback("Title", new List<string>() {"steps"}, 10);
            //TODO
        }

        [TestMethod]
        public void IsLowerStatusCorrect()
        {
            //TODO
        }

        [TestMethod]
        public void HasRating()
        {
            Feedback feedback = new Feedback("Title", new List<string>() { "dsad" }, 10);

            int expected = 10;
            int actual = feedback.Rating;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetsZeroOnNegativeRating()
        {
            Feedback feedback = new Feedback("Title", new List<string>() { "dsad" }, -10);

            int expected = 0;
            int actual = feedback.Rating;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleOOB()
        {
            Feedback feedback = new Feedback("abcde", new List<string>() { "dsad" }, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleNull()
        {
            Feedback feedback = new Feedback(null, new List<string>() { "dsad" }, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenDescriptionOOB()
        {
            Feedback feedback = new Feedback("asdasdaf",new List<string>() {"dsad"}, 10);
        }
    }
}
