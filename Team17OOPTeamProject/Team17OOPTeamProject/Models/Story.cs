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
    public class Story : WorkItem, IStory
    {
        private StoryStatus storyStatus;
        private Size size;
        private Priority priority;
        public Story(string title, string description, Priority priority, Size size)
           : base(title, description)
        {
            this.storyStatus = StoryStatus.NotDone;
            this.StoryStatus = storyStatus;
            this.Size = size;
            this.Priority = priority;
            
        }

        //Properties
        public Size Size
        { 
            get { return this.size; }
            set { this.size = value; }
        }
        public Priority Priority
        {
            get { return this.priority; }
            set { this.priority = value; }
        }
        public StoryStatus StoryStatus
        {
            get { return this.storyStatus; }
            set { this.storyStatus = value; }
        }
        public override string PrintDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Type of WorkItem: Story");
            sb.AppendLine(base.PrintDetails());
            sb.AppendLine($"Story size: {this.Size}");
            sb.AppendLine($"Story priority: {this.Priority}");
            sb.AppendLine($"Story status: {this.StoryStatus}");
            return sb.ToString();
        }
    }
}
