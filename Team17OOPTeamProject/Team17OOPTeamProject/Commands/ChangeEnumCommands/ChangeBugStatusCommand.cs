using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;
using System.Text.Encodings.Web;
namespace WIM.T17.Commands
{
    public class ChangeBugStatusCommand : Command
    {
        public ChangeBugStatusCommand(IList<string> commandParameters)
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

                Enum.TryParse<BugStatus>(this.CommandParameters[1], true, out BugStatus bugStatusType);
                if (bugStatusType == BugStatus.Active || bugStatusType == BugStatus.Fixed)
                {
                    bug.BugStatus = bugStatusType;
                }
                else
                {
                    throw new ArgumentException("Please provide some of the following statuses: Active, Fixed");
                }


                if (bug.BugStatus == BugStatus.Fixed)
                {
                    bug.History.Add($"This bug {bug.Title} status is: {bugStatusType}!");
                    this.Database.Bugs.Remove(bug);
                    return $"This bug {bugName} was removed successfully ✅";
                }

                bug.History.Add($"This bug {bug.Title} status was changed to: {bug.BugStatus}!");

                return $"This bug {bug.Title} status was changed to: {bug.BugStatus}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugStatus command parameters.");
            }
        }
    }
}
