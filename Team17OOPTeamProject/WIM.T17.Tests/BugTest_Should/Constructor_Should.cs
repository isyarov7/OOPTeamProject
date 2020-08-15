using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string title = "BugTitle";
            string description = "Very nice bug";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";
            

            //Act
            var bug = new Bug(title, description, priority, severity,stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, "BugTitle");
            Assert.AreEqual(bug.Description, "Very nice bug");
            Assert.AreEqual(bug.Priority, Priority.High);
            Assert.AreEqual(bug.Severity, Severity.Critical);
            Assert.AreEqual(bug.StepsToProduce, "Bug steps to produce");
            Assert.AreEqual(bug.BugStatus, BugStatus.Active);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsShorter_Should()
        {
            //Arrage
            string title = "Sto";
            string description = "Very nice story";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, "Sto");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsLonger_Should()
        {
            //Arrage
            string title = "StoryTiStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangetleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRangeStoryTitleIsOutOfRange";
            string description = "Very nice story";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, "BugTitleIsOutOfRange");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowWhenNameIsNull_Should()
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
            string title = "BugTitle";
            string description = "Very nice bug";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "Bug steps to produce";

            //Act
            var bug = new Bug(title, description, priority, severity, stepsToProduce);

            //Assert
            Assert.AreEqual(bug.Title, "BugTitle");
            Assert.AreEqual(bug.Description, "Very nice bug");
            Assert.AreEqual(bug.Priority, Priority.High);
            Assert.AreEqual(bug.Severity, Severity.Critical);
            Assert.AreEqual(bug.StepsToProduce, "Bug steps to produce");
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

            //Assert
            Assert.AreEqual(bug.Description, "Very");
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

            //Assert
            Assert.AreEqual(bug.Description, "BugDescriptionIsOutOfRange");
        }
    }
}

