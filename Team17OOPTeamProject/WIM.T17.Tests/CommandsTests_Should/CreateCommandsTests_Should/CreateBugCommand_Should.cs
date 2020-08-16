using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreateBugCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreateBugCommand()
        {
            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
                {
                    bugTitle,
                    description,
                    stepsToProduce.ToString(),
                };

            CreateBugCommand command = new CreateBugCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Bugs.Any(x => x.Title == bugTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
                {
                    bugTitle,
                    description,
                };

            CreateBugCommand command = new CreateBugCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Bugs.Any(x => x.Title == bugTitle));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IBug bug = new Bug(bugTitle, description, stepsToProduce);

            database.Bugs.Add(bug);
            string newParam = "newParam";
            List<string> parameters = new List<string>
                {
                    bugTitle,
                    description,
                    stepsToProduce.ToString(),
                    newParam

                };

            CreateBugCommand command = new CreateBugCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Bugs.Any(x => x.Title == bugTitle));
        }
    }
}
