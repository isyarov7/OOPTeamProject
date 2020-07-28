using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IBug
    {
        List<string> Steps { get; }
        Priority Priority { get; }
        Severity Severity { get; }
        BugStatus BugStatus { get; }
    }
}
