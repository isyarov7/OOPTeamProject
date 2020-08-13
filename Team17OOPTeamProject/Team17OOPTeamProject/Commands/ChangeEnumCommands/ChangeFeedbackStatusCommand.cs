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
                string feedbackName = this.CommandParameters[0];
                var feedback = this.Database.Feedbacks.Where(m => m.Title == feedbackName).FirstOrDefault();
                if (feedback == null)
                {
                    return "There is no such a feedback!";
                }

                Enum.TryParse<FeedbackStatus>(this.CommandParameters[1], true, out FeedbackStatus status);

                feedback.FeedbackStatus = status;
                if(feedback.FeedbackStatus == FeedbackStatus.Done)
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
