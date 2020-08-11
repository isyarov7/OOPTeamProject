using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeBugPriorityToLowCommand : Command
    {
        public ChangeBugPriorityToLowCommand(IList<string> commandParameters)
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
                if (bug.Priority == Priority.Low)
                {
                    return ("Bug priority is already low.");
                }
                bug.Priority = Priority.Low;

                bug.History.Add($"This bug {bug.Title} priority was changed to: Low!");

                return $"This bug {bug.Title} priority was changed to: Low!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugPriorityToLow command parameters.");
            }
        }
    }
}
