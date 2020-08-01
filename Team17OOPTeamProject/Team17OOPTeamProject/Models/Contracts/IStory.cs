using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IStory : IBug
    {
        public Size Size { get; }

        public Priority Priority { get; }

        public IReadOnlyList<string> Assignee { get; }
    }
}
