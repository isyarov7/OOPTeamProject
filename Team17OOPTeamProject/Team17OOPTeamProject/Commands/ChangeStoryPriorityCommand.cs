﻿using System;
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
            string storyName;
            try
            {
                storyName = this.CommandParameters[0];
                var story = this.Database.Story.Where(m => m.Title == storyName).FirstOrDefault();
                if (story == null)
                {
                    return "There is no such a story!";
                }

                Enum.TryParse<Priority>(this.CommandParameters[2], true, out Priority priorityType);

                story.Priority = priorityType;

                story.History.Add($"This story {story.Title} priority was changed to: {story.Priority}!");

                return $"This story {story.Title} priority was changed to:{story.Priority}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryPriority command parameters.");
            }
        }
    }
}