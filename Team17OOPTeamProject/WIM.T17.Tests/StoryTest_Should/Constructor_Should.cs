﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

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
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

            //Assert
            Assert.AreEqual(story.Title, "Sto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        { 
            //Arrage
            string title = "StoryTiStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangetleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRange";
            string description = "Very nice story";
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

            //Assert
            Assert.AreEqual(story.Title, "StoryTitleIsOutOfRange");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
        {
            //Arrage
            string title = null;
            string description = "Very nice story";
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

            //Assert
            Assert.AreEqual(story.Title, null);
        }

        [TestMethod]
        public void DescriptionPassValues_Should()
        {
            //Arrage
            string title = "StoryTitle";
            string description = "Very nice story";
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

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
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

            //Assert
            Assert.AreEqual(story.Description, "Very");
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
            Priority priority = Priority.High;
            Size size = Size.Large;

            //Act
            var story = new Story(title, description, priority, size);

            //Assert
            Assert.AreEqual(story.Title, "StoryTitleIsOutOfRange");
        }
    }
}
