using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.ShowCommands
{
    public class ShowAllBugsCommand : Command
    {
        public ShowAllBugsCommand(IList<string> commandParameters)
          : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***All Bugs***");
            foreach (var item in this.Database.Bugs)
            {
                sb.AppendLine(item.PrintDetails());
                sb.AppendLine("#############");
            }
            return sb.ToString();
        }
    }
}
