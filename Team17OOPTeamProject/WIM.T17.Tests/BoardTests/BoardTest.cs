using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Tests.BoardTests
{
    class BoardTest
    {
        [TestClass]
        public class BoardTests
        {
            [TestMethod]
            public void IsNameSameAsExpected()
            {
                Board board = new Board("Board");

                string expected = "Board";
                string actual = board.Name;

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void HasNameValidations()
            {
                Board board = new Board("o");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void HasNameNullValidations()
            {
                Board board = new Board(null);
            }

            [TestMethod]
            public void AssignBugCorrectly()
            {
                Board board = new Board("Gosho");
                Bug bug = new Bug("Title", "description", Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });

                board.AddBug(bug);

                Assert.IsTrue(board.Bugs.Contains(bug));

                Assert.AreEqual(board.AddBug(bug), $"Bug {bug.Title} exists on the list!");
            }

            [TestMethod]
            public void AssignsStoryCorrectly()
            {
                Board board = new Board("Pesho");
                Story story = new Story("title", "description", Priority.High, Size.Large);

                board.AddStory(story);

                Assert.IsTrue(board.Stories.Contains(story));

                Assert.AreEqual(board.AddStory(story), $"Story {story.Title} is on the list!");
            }

            [TestMethod]
            public void AssignsFeedbackCorrectly()
            {
                Board board = new Board("Ivan");
                Feedback feedback = new Feedback("Title", 10);

                board.AddFeedback(feedback);

                Assert.IsTrue(board.Feedbacks.Contains(feedback));

                Assert.AreEqual(board.AddFeedback(feedback), $"Feedback {feedback.Title} is on the list!");
            }

            [TestMethod]
            public void RemovesBugCorrectly()
            {
                Board board = new Board("Board");
                Bug bug = new Bug("Title", "description", Priority.High, Severity.Critical, new List<string>() { "steps" });

                board.AddBug(bug);
                board.RemoveBug(bug);

                Assert.IsFalse(board.Bugs.Contains(bug));

                Assert.AreEqual(board.RemoveBug(bug), $"Bug {bug.Title} is not on the list anymore!");
            }

            [TestMethod]
            public void RemoveFeedbackCorrectly()
            {
                Board board = new Board("Gosho");
                Feedback feedback = new Feedback("Title", "description", 10);

                board.AddFeedback(feedback);
                board.RemoveFeedback(feedback);

                Assert.IsFalse(board.Feedbacks.Contains(feedback));

                Assert.AreEqual(board.RemoveFeedback(feedback), $"Feedback {feedback.Title} is not on the list anymore!");
            }


            [TestMethod]
            public void RemoveStoryCorrectly()
            {
                Board board = new Board("Manol");
                Story story = new Story("title", "description", Priority.High, Size.Large);

                board.AddStory(story);
                board.RemoveStory(story);

                Assert.IsFalse(board.Stories.Contains(story));

                Assert.AreEqual(board.RemoveStory(story), $"Story {story.Title} is not on the list anymore!");
            }
        }
    }
}
