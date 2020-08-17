using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands;
using T17.Models.Models;
using T17.Models.Models.Contracts;

namespace WIM.T17.Tests.CommandsTests_Should.ShowCommandsTests_Should
{
    [TestClass]
    public class ShowPersonActivityCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllPersons()
        {
            string name = "Person";
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>()
            {
                name
            };

            ShowPersonActivityCommand command = new ShowPersonActivityCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine($"***MEMBER: {name}***");
            sb.AppendLine(person.PrintHistory());
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenNameIsNull()
        {
            string name = null;
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>()
            {
                name
            };

            ShowPersonActivityCommand command = new ShowPersonActivityCommand(parameters);

            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenLessParametersPassed()
        {
            string name = "Person";
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>()
            {
            };

            ShowPersonActivityCommand command = new ShowPersonActivityCommand(parameters);

            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenMoreParametersPassed()
        {
            string name = null;
            IMember person = new Member(name);

            database.Members.Add(person);

            List<string> parameters = new List<string>()
            {
                name,
                name
            };

            ShowPersonActivityCommand command = new ShowPersonActivityCommand(parameters);

            command.Execute();
        }
    }
}
