using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands
{
    public class ChangeBugPriorityToMediumCommand : Command
    {

        public ChangeBugPriorityToMediumCommand(IList<string> commandParameters)
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
                    return "There is no such bug!";
                }
                bug.Priority = Priority.Medium;

                bug.History.Add($"This bug {bug.Title} priority was changed to: Medium!");

                return $"This bug {bug.Title} priority was changed to: Medium!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse ChangeBugPriorityToMedium command parameters.");
            }
        }
    }
}
