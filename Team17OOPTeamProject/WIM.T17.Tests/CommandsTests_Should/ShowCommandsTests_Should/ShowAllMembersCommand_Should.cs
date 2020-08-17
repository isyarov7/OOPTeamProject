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
    public class ShowAllMembersCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void ShowAllMembersCommandPrint()
        {
            string memberName = "RATAI";
            IMember member = new Member(memberName);

            database.Members.Add(member);

            List<string> parameters = new List<string>();

            ShowAllMembersCommand command = new ShowAllMembersCommand(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("***All People***");
            foreach (var item in this.database.Members)
            {
                sb.AppendLine(item.PrintDetails());
            }
            string expected = sb.ToString();
            string actual = command.Execute();

            Assert.AreEqual(expected, actual);
        }
    }
}
