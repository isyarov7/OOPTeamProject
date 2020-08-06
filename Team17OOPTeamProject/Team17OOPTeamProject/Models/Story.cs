using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Story : Abstract.Abstract, IStory
    {
        private StoryStatus storyStatus = StoryStatus.NotDone;
        public Story(string title, Priority priority, Size size)
           : base(title)
        {
            this.Size = size;
            this.Priority = priority;
            this.StoryStatus = storyStatus;
        }

        public Story(string title, List<string> description, Priority priority, Size size)
            : this(title, priority, size)
        {
            this.Description = description;
        }

        //Properties
        public Size Size { get; private set; }

        public Priority Priority { get; private set; }
        public StoryStatus StoryStatus { get; private set; }

        public IReadOnlyList<Member> Assignee => throw new NotImplementedException();

        //Methods
        public void StoryStatusChangedToInProgressOrToDone()
        {
            if (StoryStatus == StoryStatus.NotDone || StoryStatus == StoryStatus.InProgress)
            {
                this.history.Add($"Story status is changed from {this.StoryStatus} to {++this.StoryStatus}");
            }
        }

        public void StoryStatusChangedToInProgressOrNotDone()
        {
            if (StoryStatus == StoryStatus.Done || StoryStatus == StoryStatus.InProgress)
            {
                this.history.Add($"Story status is changed from {this.StoryStatus} to {++this.StoryStatus}");
            }
        }
    }
}
