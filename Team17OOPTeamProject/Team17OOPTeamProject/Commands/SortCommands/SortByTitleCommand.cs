using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Commands.ShowCommands
{
    public class SortByTitleCommand : Command
    {
        public SortByTitleCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {
            List<IWorkItem> titleSort = new List<IWorkItem>();

            var bugTitle = this.Database.Bugs;
            var feedbackTitle = this.Database.Feedbacks;
            var storyTitle = this.Database.Stories;

            foreach (var bug in bugTitle)
            {
                titleSort.Add(bug);
            }

            foreach (var feedback in feedbackTitle)
            {
                titleSort.Add(feedback);
            }

            foreach (var story in storyTitle)
            {
                titleSort.Add(story);
            }

            titleSort = titleSort.OrderBy(title => title.Title).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY TITLES***");
            foreach (var item in titleSort)
            {
                sb.AppendLine(item.Title);
            }
            return sb.ToString();
        }
    }
}
