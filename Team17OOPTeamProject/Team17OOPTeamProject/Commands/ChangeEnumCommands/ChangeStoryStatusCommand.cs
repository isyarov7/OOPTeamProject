using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeStoryStatusCommand : Command
    {
        public ChangeStoryStatusCommand(IList<string> commandParameters)
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

            if (!Enum.TryParse<StoryStatus>(this.CommandParameters[1], true, out StoryStatus status))
            {
                throw new ArgumentException("Please provide some of the following statuses: NotDone, InProfress, Done.");
            }

            story.StoryStatus = status;

            story.History.Add($"This story {story.Title} status was changed to: {story.StoryStatus}!");

            return $"This story {story.Title} status was changed to:{story.StoryStatus}!";
        }
    }
}
