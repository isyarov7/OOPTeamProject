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

            List<IFeedback> ratingSort = new List<IFeedback>();
            

            var feedbackRating = this.Database.Feedbacks;

            foreach (var feedback in feedbackRating)
            {
                ratingSort.Add(feedback);
            }


            ratingSort = ratingSort.OrderBy(x => x.Rating).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY RATING***");
            foreach (var item in ratingSort)
            {
                sb.AppendLine(item.Rating.ToString());
            }
            return sb.ToString();

        }
    }
}
