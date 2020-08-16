using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.ChangeEnumCommands_Should
{
    [TestClass]
    public class ChangeBugPriorityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ValidChangeBugPriority_Should()
        {
            string bugName = "BugNameShould";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            Priority newPriority = Priority.Low;

            List<string> parameters = new List<string>
            {
               bugName,
               newPriority.ToString()
            };

            ChangeBugPriorityCommand command = new ChangeBugPriorityCommand(parameters);
            command.Execute();
            Assert.IsTrue(bug.Priority.Equals(newPriority));
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

            ChangeBugPriorityCommand command = new ChangeBugPriorityCommand(parameters);
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

            ChangeBugPriorityCommand command = new ChangeBugPriorityCommand(parameters);
            command.Execute();
        }
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InValidChangeBugPriority_Should()
        {
            string bugName = "BugName";
            string description = "MegaBadBug";      
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            string newPriority = "Invalid Priority";

            List<string> parameters = new List<string>
            {
               bugName,
               newPriority
            };

            ChangeBugPriorityCommand command = new ChangeBugPriorityCommand(parameters);
            command.Execute();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string bugName = "BugName";
            string description = "MegaBadBug";
            List<string> stepsToProduce = new List<string> { "steps" };
            var bug = new Bug(bugName, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
                bugName
            };

            ChangeBugPriorityCommand command = new ChangeBugPriorityCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string bugName = "BugName";
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

            ChangeBugPriorityCommand command = new ChangeBugPriorityCommand(parameters);
            command.Execute();
        }
    }
}