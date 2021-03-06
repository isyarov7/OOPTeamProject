﻿using System;
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

            if (!Enum.TryParse<Size>(this.CommandParameters[1], true, out Size size))
            {
                throw new ArgumentException("Please provide some of the following sizes: Large, Medium, Small");
            }

            story.Size = size;

            story.History.Add($"This story {story.Title} size was changed to: {story.Size}!");

            return $"This story {story.Title} size was changed to:{story.Size}!";
        }
    }
}