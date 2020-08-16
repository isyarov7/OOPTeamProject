using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    public class ChangeFeedbackRatingCommand : Command
    {
        public ChangeFeedbackRatingCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {
            try
            {
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 2 parameters!");
                if (CommandParameters.Count > 2)
                    throw new ArgumentException("You should have 2 parameters!");

                string feedbackName = this.CommandParameters[0];
                var feedback = this.Database.Feedbacks.Where(m => m.Title == feedbackName).FirstOrDefault();
                if (feedback == null)
                {
                    return "There is no such a story!";
                }

                int feedbackRating = int.Parse(this.CommandParameters[1]);
                var rating = this.Database.Feedbacks.Where(x => x.Rating == feedbackRating);
                feedback.History.Add($"This feedback {feedback.Title} rating was changed to: {feedbackRating}!");
                return $"This feedback {feedback.Title} rating was changed to: {feedbackRating}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeFeedbackRating command parameters.");
            }
        }
    }
}
