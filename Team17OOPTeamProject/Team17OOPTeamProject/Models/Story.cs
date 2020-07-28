using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Story : Abstract.Abstract, IStory
    {
        private Priority priority;
        private Size size;
        private StoryStatus storyStatus;
        public Story(string title, string description, Priority priority, Size size, StoryStatus storyStatus /*ASSIGNEE*/, List<string> comments, List<string> history) 
            : base(title, description, comments, history)
        {
            this.Priority = priority;
            this.Size = size;
            this.StoryStatus = storyStatus;
        }

        public Priority Priority { get; set; }

        public Size Size { get; set; }

        public StoryStatus StoryStatus { get; set; }
    }
}
