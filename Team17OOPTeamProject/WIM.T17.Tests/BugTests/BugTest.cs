using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Tests.BugTests
{
    class BugTest
    {
        [TestMethod]
        public void IsTitleTheSameAsExpected()
        {
            Bug bug = new Bug("Title", new List<string> (){"description"}, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() {"steps"});

            string expected = "Title";
            string actual = bug.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsAdvanceStatusCorrect()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });

            BugStatus expected = BugStatus.Fixed;
            BugStatus actual = bug.BugStatus;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsLowerStatusCorrect()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });

            BugStatus expected = BugStatus.Active;
            BugStatus actual = bug.BugStatus;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void StepsToReproduce()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });
            List<string> expected = new List<string>() { "dasdasdas" };
            List<string> actual = bug.StepsToProduce;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasPriority()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });

            Priority expected = Priority.High;
            Priority actual = bug.Priority;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HasSeverity()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });

            Severity expected = Severity.Critical;
            Severity actual = bug.Severity;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddsAssignee()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });
            Member member = new Member("pesho");

            bug.AddAssignee(member);

            Assert.IsTrue(bug.Assignee.Contains(member));
        }

        [TestMethod]
        public void AddsUniqueAssignee()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });
            Member member = new Member("Gosho");

            bug.AddAssignee(member);

            string expected = $"Member {member.Name} is already on the list!";
            string actual = bug.AddAssignee(member);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void RemoveAssignee()
        {
            Bug bug = new Bug("Title", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });
            Member member = new Member("Pesho");

            bug.RemoveAssignee(member);

            Assert.IsTrue(!bug.Assignee.Contains(member));
        }

        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleOOB()
        {
            Bug bug = new Bug("ttl", new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenTitleNull()
        {
            Bug bug = new Bug(null, new List<string>() { "description" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenDescriptionOOB()
        {
            Bug bug = new Bug("Title", new List<string>() { "desc" }, Priority.High, Severity.Critical, BugStatus.Active, new List<string>() { "steps" });

        }
    }
}
