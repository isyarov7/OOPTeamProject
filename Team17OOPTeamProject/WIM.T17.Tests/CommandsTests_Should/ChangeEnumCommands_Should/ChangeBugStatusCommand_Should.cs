using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.ChangeEnumCommands_Should
{
    [TestClass]
    public class ChangeBugStatusCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeBugStatus_Should()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            BugStatus bugStatus = BugStatus.Fixed;

            List<string> parameters = new List<string>
            {
               bugName,
               bugStatus.ToString()
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
            Assert.IsTrue(bug.BugStatus.Equals(bugStatus));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeBugInvalidParameters_Should()
        {
            string bugName = "BugNameShould";

            List<string> parameters = new List<string>
            {
               bugName
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputBugNameIsNULL_Should()
        {
            string bugName = null;
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            BugStatus bugStatus = BugStatus.Active;

            List<string> parameters = new List<string>
            {
               bugName,
               bugStatus.ToString()
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputBugStatusParameterIsNULL_Should()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            string newStatus = null;

            List<string> parameters = new List<string>
            {
               bugName,
               newStatus
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeBugStatus_Should()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            string newStatus = "Invalid Status";

            List<string> parameters = new List<string>
            {
               bugName,
               newStatus
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
                bugName
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            Priority priority = Priority.High;
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
             bugName,
             priority.ToString(),
             bugName
            };

            ChangeBugStatusCommand command = new ChangeBugStatusCommand(parameters);
            command.Execute();
        }
    }
}
