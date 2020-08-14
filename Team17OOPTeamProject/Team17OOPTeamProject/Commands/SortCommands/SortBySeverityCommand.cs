using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Commands.SortCommands
{
    public class SortBySeverityCommand : Command
    {
        public SortBySeverityCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var bugs = this.Database.Bugs.OrderByDescending(x => x.Severity).ToList();

            var sb = new StringBuilder();

            sb.AppendLine("***SORT BY SEVERITY***");
            foreach (var item in bugs)
            {
                sb.AppendLine($"{item.Title}: {item.Severity}");
            }
            return sb.ToString();
        }
    }
}
