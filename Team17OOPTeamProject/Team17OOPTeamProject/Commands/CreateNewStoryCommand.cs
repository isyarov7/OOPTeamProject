using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class CreateNewStoryCommand : Command
    {
        public CreateNewStoryCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {

            if (CommandParameters.Count < 3)
                throw new ArgumentException("You have to submit 4 parameters!");

            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            Enum.TryParse<Priority>(this.CommandParameters[2], true, out Priority priority);
            Enum.TryParse<Size>(this.CommandParameters[3], true, out Size size);
            //TODO
            //List<Member> assignee = this.CommandParameters[4].Trim().Split(',').ToList();

            var story = this.Factory.CreateStory(title, description, priority, size);
            this.Database.Story.Add(story);

            story.History.Add($"Story with title: {title} was created!");

            return $"Story with ID {this.Database.Story.Count} was created.";
        }
    }
}
