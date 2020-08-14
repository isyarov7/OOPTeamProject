using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Commands.SortCommands
{
    public class SortByRatingCommand : Command
    {
        public SortByRatingCommand(IList<string> commandParameters)
         : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var feedbackRating = this.Database.Feedbacks.OrderBy(x => x.Rating).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY RATING***");
            foreach (var item in feedbackRating)
            {
                sb.AppendLine($"{item.Title}: {item.Rating}");
            }
            return sb.ToString();
        }
    }
}
