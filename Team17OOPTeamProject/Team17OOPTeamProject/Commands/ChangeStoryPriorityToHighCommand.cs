using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeStoryPriorityToHighCommand : Command
    {
        public ChangeStoryPriorityToHighCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            string storyName;
            try
            {
                storyName = this.CommandParameters[0];
                var story = this.Database.Story.Where(m => m.Title == storyName).FirstOrDefault();
                if (story == null)
                {
                    return "There is no such a story!";
                }
                if (story.Priority == Priority.High)
                {
                    return ("Story priority is already High.");
                }
                story.Priority = Priority.High;

                story.History.Add($"This story {story.Title} priority was changed to: High!");

                return $"This story {story.Title} priority was changed to: High!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryPriorityToHigh command parameters.");
            }
        }
    }
}
