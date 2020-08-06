using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        public List<string> StepsToProduce { get; }
        public Priority Priority { get; }
        public Severity Severity { get; }
        public IReadOnlyList<Member> Assignee { get; }
    }
}
