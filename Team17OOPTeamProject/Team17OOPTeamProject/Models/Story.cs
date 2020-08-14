using System;
using System.Text;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Story : WorkItem, IStory
    {
        public Story(string title, string description, Priority priority, Size size)
           : base(title, description)
        {
            this.StoryStatus = StoryStatus.NotDone;
            this.Size = size;
            this.Priority = priority;           
        }

        //Properties
        public Size Size { get; set; }
        public Priority Priority { get; set; }
        public StoryStatus StoryStatus { get; set; }
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
