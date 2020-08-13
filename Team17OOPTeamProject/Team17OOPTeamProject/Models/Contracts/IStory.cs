using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IStory : IWorkItem
    {
        public Size Size { get; set; }
        public StoryStatus StoryStatus { get; set; }
        public Priority Priority { get; set; }
        public IMember Assignee { get; set; }
    }
}
