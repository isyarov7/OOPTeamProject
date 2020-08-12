using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeStatusOfABugCommand : Command
    {
        public ChangeStatusOfABugCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            string bugName;
            try
            {
                bugName = this.CommandParameters[0];
                var bug = this.Database.Bugs.Where(m => m.Title == bugName).FirstOrDefault();
                if (bug == null)
                {
                    return "There is no such a bug!";
                }

                Enum.TryParse<BugStatus>(this.CommandParameters[2], true, out BugStatus bugStatusType);

                bug.BugStatus = bugStatusType;


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
