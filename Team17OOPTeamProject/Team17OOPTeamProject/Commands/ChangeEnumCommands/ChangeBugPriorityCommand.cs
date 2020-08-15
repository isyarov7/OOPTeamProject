using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeBugPriorityCommand : Command
    {
        public ChangeBugPriorityCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            try
            {
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 2 parameters!");

                string bugName = this.CommandParameters[0];
                var bug = this.Database.Bugs.Where(m => m.Title == bugName).FirstOrDefault();
                if (bug == null)
                {
                    return "There is no such a bug!";
                }

                Enum.TryParse<Priority>(this.CommandParameters[1], true, out Priority priorityType);

                bug.Priority = priorityType;

                bug.History.Add($"This bug {bug.Title} priority was changed to: {bug.Priority}!");

                return $"This bug {bug.Title} priority was changed to: {bug.Priority}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugPriority command parameters.");
            }
        }
    }
}
