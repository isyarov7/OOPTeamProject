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
            Feedback feedback = new Feedback("Title", 10);

            string expected = "Title";
            string actual = feedback.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAdvanceStatusCorrect()
        {
            Feedback feedback = new Feedback("Title", 10);
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
            Feedback feedback = new Feedback("Title", 10);

            int expected = 10;
            int actual = feedback.Rating;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetsZeroOnNegativeRating()
        {
            Feedback feedback = new Feedback("Title", -10);

            int expected = 0;
            int actual = feedback.Rating;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleOOB()
        {
            Feedback feedback = new Feedback("abcde", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleNull()
        {
            Feedback feedback = new Feedback(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenDescriptionOOB()
        {
            Feedback feedback = new Feedback("asdasdaf", 10);
        }
    }
}
