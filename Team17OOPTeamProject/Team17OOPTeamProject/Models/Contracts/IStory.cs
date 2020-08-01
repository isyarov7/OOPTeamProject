using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IStory : IAbstract
    {

        public Size Size { get; }

        public Priority Priority { get; }

        public IReadOnlyList<Member> Assignee { get; }
    }
}
