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
                    return "There is no such a feedback!";
                }

                Enum.TryParse<FeedbackStatus>(this.CommandParameters[1], true, out FeedbackStatus status);
                if (status == FeedbackStatus.New || status == FeedbackStatus.Done || status == FeedbackStatus.Unscheduled || status != FeedbackStatus.Scheduled)
                {
                    feedback.FeedbackStatus = status;
                }
                else
                {
                    throw new ArgumentException("Please provide some of the following statuses: New, Done, Unscheduled, Scheduled.");
                }


                if (feedback.FeedbackStatus == FeedbackStatus.Done)
                {
                    feedback.History.Add($"This feedback {feedback.Title} status is: {status} ✅");
                    this.Database.Feedbacks.Remove(feedback);
                    return $"This feedback {feedbackName} status is: {status} ✅";

                }

                feedback.History.Add($"This feedback {feedback.Title} status was changed to: {status}!");
                return $"This feedback {feedback.Title} status was changed to: {status}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeFeedbackStatus command parameters.");
            }
        }
    }
}
