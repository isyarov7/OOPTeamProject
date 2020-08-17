using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Tests.StoryTest_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void PassValues_Should()
        {
            //Arrage
            string title = "StoryTitle";
            string description = "Very nice story";

            //Act
            var story = new Story(title, description);

            //Assert
            Assert.AreEqual(story.Title, "StoryTitle");
            Assert.AreEqual(story.Description, "Very nice story");
            Assert.AreEqual(story.Priority, Priority.High);
            Assert.AreEqual(story.Size, Size.Large);
            Assert.AreEqual(story.StoryStatus, StoryStatus.NotDone);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Arrage
            string title = "Sto";
            string description = "Very nice story";

            //Act
            var story = new Story(title, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Arrage
            string title = "StoryTiStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangetleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRange";
            string description = "Very nice story";

            //Act
            var story = new Story(title, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Arrage
            string title = null;
            string description = "Very nice story";

            //Act
            var story = new Story(title, description);
        }

        [TestMethod]
        public void DescriptionPassValues_Should()
        {
            //Arrage
            string title = "StoryTitle";
            string description = "Very nice story";

            //Act
            var story = new Story(title, description);

            //Assert
            Assert.AreEqual(story.Title, "StoryTitle");
            Assert.AreEqual(story.Description, "Very nice story");
            Assert.AreEqual(story.Priority, Priority.High);
            Assert.AreEqual(story.Size, Size.Large);
            Assert.AreEqual(story.StoryStatus, StoryStatus.NotDone);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenDescriptionIsShort_Should()
        {
            //Arrage
            string title = "StoryTitle";
            string description = "Very";


            //Act
            var story = new Story(title, description);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenDescriptionIsLonge_Should()
        {
            //Arrage
            string title = "StoryTitle";
            string description = "Very nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story" +
                "Very nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice storyVery nice story";

            //Act
            var story = new Story(title, description);
        }
    }
}
