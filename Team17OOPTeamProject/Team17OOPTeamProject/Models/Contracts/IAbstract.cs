using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IAbstract
    {
        public string ID { get; }

        public string Title { get; }

        public string Description { get; }

        public abstract BugStatus BugStatus { get; }

        public abstract StoryStatus StortyStatus { get; }

        public abstract FeedbackStatus FeedbackStatus { get; }
        
        public IReadOnlyDictionary<string, string> Comment { get; }

        public IReadOnlyCollection<string> History { get; }



    }
}
