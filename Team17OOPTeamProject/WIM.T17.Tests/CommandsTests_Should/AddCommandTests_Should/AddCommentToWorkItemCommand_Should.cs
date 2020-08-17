using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands.AddCommands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddCommentToWorkItemCommand_Should : BaseTestClass
    {
        public void AddCommentToWorkItemCommand()
        {
            string workitem = "Bug";
            string currentWorkItemName = "MnogoLoshBug";
            string comment = "bugComment";

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "steps" };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
               workitem,
               currentWorkItemName,
               comment
            };

            AddCommentToWorkItemCommand command = new AddCommentToWorkItemCommand(parameters);
            command.Execute();
            Assert.IsTrue(bug.Comments.Any(x => x.Value == comment));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenWorkItemIsNull()
        {
            string workitem = null;
            string currentWorkItemName = "MnogoLoshBug";
            string comment = "bugComment";

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "steps" };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
               workitem,
               currentWorkItemName,
               comment
            };

            AddCommentToWorkItemCommand command = new AddCommentToWorkItemCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenWorkItemTitleIsNull()
        {
            string workitem = "Bug";
            string currentWorkItemName = null;
            string comment = "bugComment";

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "steps" };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
               workitem,
               currentWorkItemName,
               comment
            };

            AddCommentToWorkItemCommand command = new AddCommentToWorkItemCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string workitem = "Bug";
            string currentWorkItemName = "MnogoLoshBug";
            string comment = "bugComment";

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "steps" };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);
            List<string> parameters = new List<string>
            {
               workitem,
               currentWorkItemName
            };

            AddCommentToWorkItemCommand command = new AddCommentToWorkItemCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string workitem = "Bug";
            string currentWorkItemName = "MnogoLoshBug";
            string comment = "bugComment";

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "steps" };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
               workitem,
               currentWorkItemName,
               comment,
               workitem
            };

            AddCommentToWorkItemCommand command = new AddCommentToWorkItemCommand(parameters);
            command.Execute();
        }
    }
}
