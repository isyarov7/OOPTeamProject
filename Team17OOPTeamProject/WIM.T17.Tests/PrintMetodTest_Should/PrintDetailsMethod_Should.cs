using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Tests.PrintMetodTest_Should
{
    [TestClass]
    public class PrintDetailsMethod_Should : BaseTestClass
    {
        [TestMethod]

        public void PrintDetailsMethodShould()
        {
            string storyTitle = "SttoryTitle";
            string description = "Lllsdladadada";
            IStory story = new Story(storyTitle, description);

            database.Stories.Add(story);
            story.History.Add($"Story with title: {story.Title} was created!");

            var sb = new StringBuilder();
            if (story.History.Count == 0)
            {
                sb.AppendLine($"The history of {story.Title} is empty!");
            }
            else
            {

                sb.AppendLine("History:");
                foreach (var item in story.History)
                {
                    sb.AppendLine(item);
                }
            }
            string expected = sb.ToString();
            string actual = story.PrintHistory();

            Assert.AreEqual(expected, actual);
        }
    }
}
