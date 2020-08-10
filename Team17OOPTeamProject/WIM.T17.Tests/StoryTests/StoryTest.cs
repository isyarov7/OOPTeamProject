using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Tests.StoryTests
{
    class StoryTest
    {
        [TestMethod]
        public void HasTitle()
        {
            var story = new Story("title", new List<string>() { "description" } , Priority.High, Size.Large);

            string expected = "title";
            string actual = story.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasPriority()
        {
            var story = new Story("title", new List<string>() { "description" }, Priority.High, Size.Large);

            Priority expected = Priority.High;
            Priority actual = story.Priority;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasSize()
        {
            var story = new Story("title", new List<string>() { "description" }, Priority.High, Size.Large);

            Size expected = Size.Large;
            Size actual = story.Size;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleOOB()
        {
            var story = new Story("abcd", new List<string>() { "description" }, Priority.High, Size.Large);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleNull()
        {
            var story = new Story(null, new List<string>() { "description" }, Priority.High, Size.Large);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenDescriptionOOB()
        {
            var story = new Story("title", new List<string>() { "description" }, Priority.High, Size.Large);
        }
    }
}
