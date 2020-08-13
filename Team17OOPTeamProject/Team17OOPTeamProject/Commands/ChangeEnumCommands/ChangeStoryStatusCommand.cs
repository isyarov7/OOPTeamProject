﻿using System;
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
            try
            {
                string storyName = this.CommandParameters[0];
                var story = this.Database.Stories.Where(m => m.Title == storyName).FirstOrDefault();
                if (story == null)
                {
                    return "There is no such a story!";
                }

                Enum.TryParse<StoryStatus>(this.CommandParameters[1], true, out StoryStatus status);

                story.StoryStatus = status;

                if(story.StoryStatus == StoryStatus.Done)
                {
                    story.History.Add($"This story {story.Title} status is: {status} ✅");
                    this.Database.Stories.Remove(story);
                    return $"This story {storyName} was removed successfully ✅";
                    
                }

                story.History.Add($"This story {story.Title} status was changed to: {story.StoryStatus}!");

                return $"This story {story.Title} status was changed to:{story.StoryStatus}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeStoryStatus command parameters.");
            }
        }
    }
}
