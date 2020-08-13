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
            string feedbackName;
            try
            {
                feedbackName = this.CommandParameters[0];
                var feedback = this.Database.Feedback.Where(m => m.Title == feedbackName).FirstOrDefault();
                if (feedback == null)
                {
                    return "There is no such a feedback!";
                }

                Enum.TryParse<FeedbackStatus>(this.CommandParameters[2], true, out FeedbackStatus status);

                feedback.FeedbackStatus = status;
                if(feedback.FeedbackStatus == FeedbackStatus.Done)
                {
                    feedback.History.Add($"This feedback {feedback.Title} status is: {status} ✅");
                    Console.WriteLine($"This feedback {feedback.Title} status is: {status} ✅");
                    this.Database.Feedback.Remove(feedback);
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
