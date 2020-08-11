using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeBugPriorityToHighCommand : Command
    {
        public ChangeBugPriorityToHighCommand(IList<string> commandParameters)
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
                if (bug.Priority == Priority.High)
                {
                    return ("Bug priority is already high.");
                }
                bug.Priority = Priority.High;

                bug.History.Add($"This bug {bug.Title} priority was changed to: High!");

                return $"This bug {bug.Title} priority was changed to: High!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugPriorityToHigh command parameters.");
            }
        }
    }
}
