using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IStory
    {
        Priority Priority { get; }
        Size Size { get; }
        StoryStatus StoryStatus { get; }
        //ASSIGNEE
    }
}
