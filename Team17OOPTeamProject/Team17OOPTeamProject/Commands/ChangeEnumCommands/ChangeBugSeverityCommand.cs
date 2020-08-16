using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeBugSeverityCommand : Command
    {
        public ChangeBugSeverityCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }

            string bugName = this.CommandParameters[0];
            var bug = this.Database.Bugs.FirstOrDefault(m => m.Title == bugName);
            if (bug == null)
            {
                return "There is no such a bug!";
            }

            if (!Enum.TryParse<Severity>(this.CommandParameters[1], true, out Severity severityType))
            {
                throw new ArgumentException("Please provide some of the following priorities: Critical, Major, Minor");
            }

            bug.Severity = severityType;
            bug.History.Add($"This bug {bug.Title} severity was changed to: {bug.Severity}!");

            return $"This bug {bug.Title} severity was changed to: {bug.Severity}!";
        }
    }
}