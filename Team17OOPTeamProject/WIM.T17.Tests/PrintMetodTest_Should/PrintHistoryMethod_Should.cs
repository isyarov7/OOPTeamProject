using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Tests.PrintMetodTest_Should
{
    [TestClass]
    public class PrintHistoryMethod_Should : BaseTestClass
    {
        [TestMethod]

        public void PrintHistoryMethodShould()
        {
            string storyTitle = "SttoryTitle";
            string description = "Lllsdladadada";
            IStory story = new Story(storyTitle, description);

            string comment = "Neznam kakvo se sluchva";
            database.Stories.Add(story);
            story.History.Add($"Story with title: {story.Title} was created!");
            story.Comments.Add(DateTime.Now, comment);

            var sb = new StringBuilder();
            sb.AppendLine("Type of WorkItem: Story");
            sb.AppendLine($"Title: {story.Title}");
            sb.AppendLine($"Description: {story.Description}");
            if (story.History.Count > 0)
            {
                sb.AppendLine("Activity history:");
                int counter = 1;
                foreach (var item in story.History)
                {
                    sb.AppendLine($"{counter}. {item}");
                    counter++;
                }
            }
            else
            {
                sb.AppendLine("There is no activity history.");
            }
            if (story.Comments.Count > 0)
            {
                sb.AppendLine("Comments:");
                int counter = 1;
                foreach (var item in story.Comments)
                {
                    sb.Append($"{counter}. {item.Key} {item.Value}");
                    counter++;
                }
            }
            else
            {
                sb.AppendLine("There is no comments.");
            }
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine($"Story size: {story.Size}");
            sb.AppendLine($"Story priority: {story.Priority}");
            sb.AppendLine($"Story status: {story.StoryStatus}");

            string expected = sb.ToString();
            string actual = story.PrintDetails();
            Assert.AreEqual(expected, actual);
        }
    }
}
