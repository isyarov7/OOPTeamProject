using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeStoryPriorityToMediumCommand : Command
    {
        public ChangeStoryPriorityToMediumCommand(IList<string> commandParameters)
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
                if (story.Priority == Priority.Medium)
                {
                    return ("Story priority is already Medium.");
                }
                story.Priority = Priority.Medium;

                story.History.Add($"This story {story.Title} priority was changed to: Medium!");

                return $"This story {story.Title} priority was changed to: Medium!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryPriorityToMedium command parameters.");
            }
        }
    }
}
