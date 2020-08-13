using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace T17.Models.Commands
{
    public class ShowAllMembersCommand : Command
    {
        public ShowAllMembersCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***All People***");
            foreach (var item in this.Database.Members)
            {
                sb.AppendLine(item.PrintDetails());
                sb.AppendLine("#############");
            }
            return sb.ToString();
        }
    }
}