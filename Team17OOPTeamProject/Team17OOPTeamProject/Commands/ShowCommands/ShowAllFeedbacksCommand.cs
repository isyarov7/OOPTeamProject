using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.ShowCommands
{
    public class ShowAllFeedbacksCommand : Command
    {
        public ShowAllFeedbacksCommand(IList<string> commandParameters)
          : base(commandParameters)
        {
        }

        public override string Execute()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***All Feedbacks***");
            foreach (var item in this.Database.Feedbacks)
            {
                sb.AppendLine(item.PrintDetails());
            }
            return sb.ToString();
        }
    }
}
