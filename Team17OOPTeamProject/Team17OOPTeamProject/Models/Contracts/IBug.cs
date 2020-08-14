using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IBug : IWorkItem
    {
        public string StepsToProduce { get; }
        public Priority Priority { get; set; }
        public BugStatus BugStatus { get; set; }
        public Severity Severity { get; set; }
        public IMember Assignee { get; set; }
    }
}
