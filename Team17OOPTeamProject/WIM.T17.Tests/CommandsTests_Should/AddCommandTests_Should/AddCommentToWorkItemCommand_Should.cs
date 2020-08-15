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
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            List<string> stepsToProduce = new List<string> { "steps" };
            IBug bug = new Bug(bugTitle, description, priority, severity, stepsToProduce);

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
    }
}
