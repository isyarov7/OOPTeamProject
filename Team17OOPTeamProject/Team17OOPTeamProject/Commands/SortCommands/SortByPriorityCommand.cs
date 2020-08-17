using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace WIM.T17.Commands.SortCommands
{
    public class SortByPriorityCommand : Command
    {
        public SortByPriorityCommand(IList<string> commandParameters)
         : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var bug = this.Database.Bugs.OrderByDescending(x => x.Priority).ToList();
            var story = this.Database.Stories.OrderByDescending(x => x.Priority).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY PRIORITY***");
            foreach (var item in bug)
            {
                sb.AppendLine($"{item.Title}: {item.Priority}");
            }

            foreach (var item in story)
            {
                sb.AppendLine($"{item.Title}: {item.Priority}");
            }

            return sb.ToString();
        }
    }
}
