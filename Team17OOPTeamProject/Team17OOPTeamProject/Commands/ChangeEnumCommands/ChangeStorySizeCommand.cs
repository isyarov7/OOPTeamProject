using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeStorySizeCommand : Command
    {
        public ChangeStorySizeCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            try
            {
                string storyName = this.CommandParameters[0];
                var story = this.Database.Story.Where(m => m.Title == storyName).FirstOrDefault();
                if (story == null)
                {
                    return "There is no such a story!";
                }

                Enum.TryParse<Size>(this.CommandParameters[1], true, out Size size);

                story.Size = size;

                story.History.Add($"This story {story.Title} size was changed to: {story.Size}!");

                return $"This story {story.Title} size was changed to:{story.Size}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStorySize command parameters.");
            }
        }
    }
}
