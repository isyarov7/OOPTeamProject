using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Story : Abstract.WorkItem, IStory
    {
        private StoryStatus storyStatus = StoryStatus.NotDone;
        public Story(string title, Priority priority, Size size)
           : base(title)
        {
            this.Size = size;
            this.Priority = priority;
            
        }

        public Story(string title, string description, Priority priority, Size size)
            : this(title, priority, size)
        {
           
            this.Description = description;
        }

        //Properties
        public Size Size { get; set; }

        public Priority Priority { get; set; }
        public StoryStatus StoryStatus { get; set; }

        public IMember Assignee { get; set; }
    }
}
