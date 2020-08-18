using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace T17.Models.Commands
{
    public class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***All Teams***");
            foreach (var item in this.Database.Teams)
            {
                sb.AppendLine(item.PrintDetails());
            }
            return sb.ToString();
        }
    }
}
