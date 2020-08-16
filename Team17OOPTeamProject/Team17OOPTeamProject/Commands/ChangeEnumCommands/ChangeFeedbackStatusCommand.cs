using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeFeedbackStatusCommand : Command
    {
        public ChangeFeedbackStatusCommand(IList<string> commandParameters)
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

            if (!Enum.TryParse<FeedbackStatus>(this.CommandParameters[1], true, out FeedbackStatus status))
            {
                throw new ArgumentException("Please provide some of the following statuses: New, Done, Unscheduled, Scheduled.");
            }

            feedback.FeedbackStatus = status;

            if (feedback.FeedbackStatus == FeedbackStatus.Done)
            {
                feedback.History.Add($"This feedback {feedback.Title} status is: {status} ✅");
                this.Database.Feedbacks.Remove(feedback);
                return $"This feedback {feedbackName} status is: {status} ✅";

            }

            feedback.History.Add($"This feedback {feedback.Title} status was changed to: {status}!");
            return $"This feedback {feedback.Title} status was changed to: {status}!";
        }
    }
}
