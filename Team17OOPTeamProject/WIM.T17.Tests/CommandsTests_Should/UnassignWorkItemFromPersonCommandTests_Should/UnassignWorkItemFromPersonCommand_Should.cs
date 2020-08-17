using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should
{
    [TestClass]
    public class UnassignWorkItemToPersonCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void UnassignWorkItemFromPersonCommand_Should()
        {
            string bugTitle = "BugTitleShould";
            string description = "NeznamKakvoStava";
            List<string> stepsToProduce = new List<string> { "one", "two" };
            var bug = new Bug(bugTitle, description, stepsToProduce);

            string personName = "Gosho";
            var person = new Member(personName);

            database.Bugs.Add(bug);
            database.Members.Add(person);

            string typeOfWI = "Bug";

            List<string> parameters = new List<string>
            {
                typeOfWI,
                bugTitle,
                personName
            };

            UnassignWorkItemFromPersonCommand unassign = new UnassignWorkItemFromPersonCommand(parameters);
            unassign.Execute();

            var expected = this.database.Members.Any(x => x.WorkItems.Contains(bug));

            Assert.AreEqual(expected, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfCurrentWorkItemIsNull()
        {
            string bugTitle = "BugTitleShould";
            string description = "NeznamKakvoStava";
            List<string> stepsToProduce = new List<string> { "one", "two" };
            var bug = new Bug(bugTitle, description, stepsToProduce);

            string personName = "Gosho";
            var person = new Member(personName);

            database.Bugs.Add(bug);
            database.Members.Add(person);

            string typeOfWI = null;

            List<string> parameters = new List<string>
            {
                typeOfWI,
                bugTitle,
                personName
            };

            AssignWorkItemToPersonCommand assign = new AssignWorkItemToPersonCommand(parameters);
            assign.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfBugTitleIsNull()
        {
            string bugTitle = null;
            string description = "NeznamKakvoStava";
            List<string> stepsToProduce = new List<string> { "one", "two" };
            var bug = new Bug(bugTitle, description, stepsToProduce);

            string personName = "Gosho";

            string typeOfWI = "Bug";

            List<string> parameters = new List<string>
            {
                typeOfWI,
                bugTitle,
                personName
            };

            AssignWorkItemToPersonCommand assign = new AssignWorkItemToPersonCommand(parameters);
            assign.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfPersonIsNull()
        {
            string bugTitle = "BugTitleShould";

            string personName = null;
            var person = new Member(personName);

            string typeOfWI = "Bug";

            List<string> parameters = new List<string>
            {
                typeOfWI,
                bugTitle,
                personName
            };

            AssignWorkItemToPersonCommand assign = new AssignWorkItemToPersonCommand(parameters);
            assign.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string bugTitle = "BugTitleShould";
            string typeOfWI = "Bug";

            List<string> parameters = new List<string>
            {
                typeOfWI,
                bugTitle
            };

            AssignWorkItemToPersonCommand assign = new AssignWorkItemToPersonCommand(parameters);
            assign.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string bugTitle = "BugTitleShould";
 
            string personName = null;
   
            string typeOfWI = "Bug";

            List<string> parameters = new List<string>
            {
                typeOfWI,
                bugTitle,
                personName,
                typeOfWI
            };

            AssignWorkItemToPersonCommand assign = new AssignWorkItemToPersonCommand(parameters);
            assign.Execute();
        }
    }
}
