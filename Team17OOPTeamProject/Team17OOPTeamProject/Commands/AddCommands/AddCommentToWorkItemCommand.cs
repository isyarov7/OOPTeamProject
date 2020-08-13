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
            try
            {
                if (CommandParameters.Count < 3)
                    throw new ArgumentException("You should have 3 parameters!");

                string workItemType = this.CommandParameters[0];
                string currenteWorkItem = this.CommandParameters[1];

                string comment = this.CommandParameters[2];

                if (workItemType == "Bug")
                {
                    var bug = this.Database.Bugs.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    bug.Comments.Add(DateTime.Now, comment);
                    bug.History.Add($"Bug {bug.Title} has new comment: {comment}");
                    return $"Bug {bug.Title} has new comment: {comment}";
                }
                else if (workItemType == "Story")
                {
                    var story = this.Database.Stories.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    story.Comments.Add(DateTime.Now, comment);
                    story.History.Add($"Story {story.Title} has new comment: {comment}");
                    return $"Story {story.Title} has new comment: {comment}";
                }
                else if (workItemType == "Feedback")
                {
                    var feedback = this.Database.Feedbacks.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    feedback.Comments.Add(DateTime.Now, comment);
                    feedback.History.Add($"Feedback {feedback.Title} has new comment: {comment}");
                    return $"Feedback {feedback.Title} has new comment: {comment}";
                }
                else
                {
                    return "Failed to parse AddCommentToWorkItem command parameters.";
                }
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddCommentToWorkItem command parameters.");
            }
        }
    }
}
