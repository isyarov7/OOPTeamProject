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
    public class ChangeBugSeverityCommand_Should : BaseTestClass
    {
        public void ValidChangeBugSeverity_Should()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            Severity newSeverity = Severity.Major;

            List<string> parameters = new List<string>
            {
               bugName,
               newSeverity.ToString()
            };

            ChangeBugSeverityCommand command = new ChangeBugSeverityCommand(parameters);
            command.Execute();
            Assert.IsTrue(bug.Priority.Equals(newSeverity));
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

            ChangeBugSeverityCommand command = new ChangeBugSeverityCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InputBugNameIsNULL_Should()
        {
            string bugName = null;
            string description = "MegaBadBug";
            Priority priority = Priority.High;
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
               bugName,
               priority.ToString()
            };

            ChangeBugSeverityCommand command = new ChangeBugSeverityCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeBugPriority_Should()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            string newSeverity = "Invalid";

            List<string> parameters = new List<string>
            {
               bugName,
               newSeverity
            };

            ChangeBugSeverityCommand command = new ChangeBugSeverityCommand(parameters);
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

            ChangeBugSeverityCommand command = new ChangeBugSeverityCommand(parameters);
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

            ChangeBugSeverityCommand command = new ChangeBugSeverityCommand(parameters);
            command.Execute();
        }
    }
}
