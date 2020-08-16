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
            try
            {
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 2 parameters!");
                if (CommandParameters.Count > 2)
                    throw new ArgumentException("You should have 2 parameters!");

                string bugName = this.CommandParameters[0];
                var bug = this.Database.Bugs.Where(m => m.Title == bugName).FirstOrDefault();
                if (bug == null)
                {
                    return "There is no such a bug!";
                }

                Enum.TryParse<Severity>(this.CommandParameters[1], true, out Severity severityType);
                if (severityType == Severity.Critical || severityType == Severity.Major || severityType == Severity.Minor)
                {
                    bug.Severity = severityType;
                }
                else
                {
                    throw new ArgumentException("Please provide some of the following priorities: Critical, Major, Minor");
                }

                bug.History.Add($"This bug {bug.Title} severity was changed to: {bug.Severity}!");

                return $"This bug {bug.Title} severity was changed to: {bug.Severity}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugSeverity command parameters.");
            }
        }
    }
}
