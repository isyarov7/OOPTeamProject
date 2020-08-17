using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.AssignWorkItemToPersonCommand_Should
{
    [TestClass]
    public class AssignWorkItemToPersonCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void AssignWorkItemToPersonCommand()
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

            AssignWorkItemToPersonCommand assign = new AssignWorkItemToPersonCommand(parameters);
            assign.Execute();

            var expected = this.database.Members.Any(x => x.WorkItems.Contains(bug));

            Assert.AreEqual(expected, true);
        }
        //TODO
    }
}
