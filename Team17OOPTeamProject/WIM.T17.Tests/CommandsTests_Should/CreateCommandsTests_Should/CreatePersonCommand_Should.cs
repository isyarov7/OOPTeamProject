using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreatePersonCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreatePersonCommand()
        {
            string name = "PersonName";
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>
                {
                    name
                };

            CreatePersonCommand command = new CreatePersonCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Members.Any(x => x.Name == name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShouldCorrectly()
        {
            string name = "PersonName";
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>
            {
            };

            CreatePersonCommand command = new CreatePersonCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Members.Any(x => x.Name == name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string name = "PersonName";
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>
                {
                    name,
                    name
                };

            CreatePersonCommand command = new CreatePersonCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Members.Any(x => x.Name == name));
        }
    }
}
