using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.AddCommands
{
    public class AddCommentToWorkItemCommand : Command
    {
        public AddCommentToWorkItemCommand(IList<string> commandParameters)
              : base(commandParameters)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != 3)
            {
                throw new ArgumentException("You should have 3 parameters!");
            }

            string workItemType = this.CommandParameters[0];
            if (workItemType != "Bug" && workItemType != "Story" && workItemType != "Feedback")
            {
                throw new ArgumentException("Please provide some of the following work items: Bug, Story, Feedback.");
            }

            string currenteWorkItem = this.CommandParameters[1];

            string comment = this.CommandParameters[2];

            if (workItemType == "Bug")
            {
                var bug = this.Database.Bugs.FirstOrDefault(x => x.Title == currenteWorkItem);
                if (bug == null)
                {
                    throw new ArgumentException("There is no such bug.");
                }
                bug.Comments.Add(DateTime.Now, comment);
                bug.History.Add($"Bug {bug.Title} has new comment: {comment}");
                return $"Bug {bug.Title} has new comment: {comment}";
            }
            else if (workItemType == "Story")
            {
                var story = this.Database.Stories.FirstOrDefault(x => x.Title == currenteWorkItem);
                if (story == null)
                {
                    throw new ArgumentException("There is no such story.");
                }
                story.Comments.Add(DateTime.Now, comment);
                story.History.Add($"Story {story.Title} has new comment: {comment}");
                return $"Story {story.Title} has new comment: {comment}";
            }
            else if (workItemType == "Feedback")
            {
                var feedback = this.Database.Feedbacks.FirstOrDefault(x => x.Title == currenteWorkItem);
                if (feedback == null)
                {
                    throw new ArgumentException("There is no such feedback.");
                }
                feedback.Comments.Add(DateTime.Now, comment);
                feedback.History.Add($"Feedback {feedback.Title} has new comment: {comment}");
                return $"Feedback {feedback.Title} has new comment: {comment}";
            }
            else
            {
                return "Failed to parse AddCommentToWorkItem command parameters.";
            }
        }
    }
}
