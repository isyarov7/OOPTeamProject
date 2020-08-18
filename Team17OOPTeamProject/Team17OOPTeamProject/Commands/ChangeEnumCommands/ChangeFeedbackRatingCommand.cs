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
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }

            string feedbackName = this.CommandParameters[0];
            var feedback = this.Database.Feedbacks.FirstOrDefault(m => m.Title == feedbackName);
            if (feedback == null)
            {
                return "There is no such a feedback!";
            }

            int feedbackRating = int.Parse(this.CommandParameters[1]);
            if (feedbackRating < 0 || feedbackRating > 5)
            {
                throw new ArgumentException("Rating must be between 0 and 5.");
            }

            feedback.Rating = feedbackRating;

            feedback.History.Add($"This feedback {feedback.Title} rating was changed to: {feedbackRating}!");
            return $"This feedback {feedback.Title} rating was changed to: {feedbackRating}!";
        }
    }
}