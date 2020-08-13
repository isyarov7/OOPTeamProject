
using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.ShowCommands
{
    public class ShowAllStoriesCommand : Command
    {
        public ShowAllStoriesCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***All Stories***");
            foreach (var item in this.Database.Stories)
            {
                sb.AppendLine(item.PrintDetails());
                sb.AppendLine("#############");
            }
            return sb.ToString();
        }
    }
}
