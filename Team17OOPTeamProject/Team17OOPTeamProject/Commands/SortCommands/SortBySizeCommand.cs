using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Commands.SortCommands
{
    public class SortBySizeCommand : Command
    {
        public SortBySizeCommand(IList<string> commandParameters)
          : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var story = this.Database.Stories.OrderByDescending(x => x.Size).ToList();

            var sb = new StringBuilder();
            sb.AppendLine("***SORT BY SIZE***");
            foreach (var item in story)
            {
                sb.AppendLine($"{item.Title}: {item.Size}");
            }
            return sb.ToString();
        }
    }
}
