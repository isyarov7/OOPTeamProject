using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    public class CreateFeedbackCommand : Command
    {
        public CreateFeedbackCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {

            if (CommandParameters.Count < 3)
                throw new ArgumentException("You have to submit 3 parameters!");

            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            int rating = int.Parse(this.CommandParameters[2]);

            var feedback = this.Factory.CreateFeedback(title, description, rating);
            this.Database.Feedbacks.Add(feedback);

            feedback.History.Add($"Feedback with title: {title} was created!");

            return $"Feedback with ID {this.Database.Feedbacks.Count} was created.";
        }
    }
}
