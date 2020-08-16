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
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 2 parameters!");
                if (CommandParameters.Count > 2)
                    throw new ArgumentException("You should have 2 parameters!");

                string storyName = this.CommandParameters[0];
                var story = this.Database.Stories.Where(m => m.Title == storyName).FirstOrDefault();
                if (story == null)
                {
                    return "There is no such a story!";
                }

                Enum.TryParse<Size>(this.CommandParameters[1], true, out Size size);
                if (size == Size.Large || size == Size.Medium || size == Size.Small)
                {
                    story.Size = size;
                }
                else
                {
                    throw new ArgumentException("Please provide some of the following sizes: Large, Medium, Small");
                }

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
