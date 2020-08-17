using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using WIM.T17.Commands.ShowCommands;

namespace WIM.T17.Tests.CommandsTests_Should.SortCommandsTest_Should
{
    [TestClass]
    public class SortByTitleCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void SortByTitleCommandShould()
        {
            string bugName = "BugNameShould";
            string description = "Description11";
            List<string> stepToProduce = new List<string> { "ONe" };
            IBug bug = new Bug(bugName, description, stepToProduce);

            string storyName = "StotyNameShould";
            string stDescription = "Description11";
            IStory story = new Story(storyName, stDescription);

            List<IWorkItem> titleSort = new List<IWorkItem>();

            var bugTitle = this.database.Bugs;
            var feedbackTitle = this.database.Feedbacks;
            var storyTitle = this.database.Stories;

            List<string> parameters = new List<string>();

            SortByTitleCommand command = new SortByTitleCommand(parameters);

            foreach (var item in bugTitle)
            {
                titleSort.Add(item);
            }

            foreach (var item in feedbackTitle)
            {
                titleSort.Add(item);
            }

            foreach (var item in storyTitle)
            {
                titleSort.Add(item);
            }

            titleSort = titleSort.OrderBy(title => title.Title).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY TITLES***");
            foreach (var item in titleSort)
            {
                sb.AppendLine(item.Title);
            }

            string expected = sb.ToString();
            string actual = command.Execute();
            Assert.AreEqual(expected, actual);
        }
    }
}
