﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Tests.BugTest_Should
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void PassValues_Should()
        {
            //Arrage
            string title = "BugTitleShould";
            string description = "Very nice bug";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";
            

            //Act
            var bug = new Bug(title, description, priority, severity,stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, "BugTitleShould");
            Assert.AreEqual(bug.Description, "Very nice bug");
            Assert.AreEqual(bug.Priority, Priority.High);
            Assert.AreEqual(bug.Severity, Severity.Critical);
            Assert.AreEqual(bug.StepsToProduce, "Bug steps to produce");
            Assert.AreEqual(bug.BugStatus, BugStatus.Active);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenTitleIsShort_Should()
        {
            //Arrage
            string title = "Bug";
            string description = "Very nice story";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, "Bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenTitleIsLonger_Should()
        {
            //Arrage
            string title = "StoryTiStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangetleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRange";
            string description = "Very nice story";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenTitleIsNull_Should()
        {
            //Arrage
            string title = null;
            string description = "Very nice bug";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, null);
        }

        [TestMethod]
        public void DescriptionPassValues_Should()
        {
            //Arrage
            string title = "BugTitleShould";
            string description = "Very nice bug";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);

            //Assert         
            Assert.AreEqual(bug.Description, "Very nice bug");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenDescriptionIsShort_Should()
        {
            //Arrage
            string title = "StoryTitle";
            string description = "Very";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);
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
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);
        }
    }
}

