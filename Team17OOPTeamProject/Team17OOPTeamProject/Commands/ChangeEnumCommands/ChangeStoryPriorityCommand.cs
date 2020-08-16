using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeStoryPriorityCommand : Command
    {
        public ChangeStoryPriorityCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }
           
            string storyName = this.CommandParameters[0];
            var story = this.Database.Stories.FirstOrDefault(m => m.Title == storyName);
            if (story == null)
            {
                return "There is no such a story!";
            }

            if (!Enum.TryParse<Priority>(this.CommandParameters[1], true, out Priority priorityType))
            {
                throw new ArgumentException("Please provide some of the following priorities: High, Medium, Low");
            }

            story.Priority = priorityType;

            story.History.Add($"This story {story.Title} priority was changed to: {story.Priority}!");

            return $"This story {story.Title} priority was changed to:{story.Priority}!";
        }
    }
}