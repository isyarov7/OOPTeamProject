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
                string bugName = this.CommandParameters[0];
                var bug = this.Database.Bugs.Where(m => m.Title == bugName).FirstOrDefault();
                if (bug == null)
                {
                    return "There is no such a bug!";
                }

                Enum.TryParse<Severity>(this.CommandParameters[1], true, out Severity severityType);

                bug.Severity = severityType;

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
