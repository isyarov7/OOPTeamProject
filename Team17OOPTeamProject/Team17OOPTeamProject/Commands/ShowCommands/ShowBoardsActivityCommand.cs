using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.ShowCommands
{
    public class ShowBoardsActivityCommand : Command
    {
        public ShowBoardsActivityCommand(IList<string> commandParameters)
          : base(commandParameters)
        {
        }
        public override string Execute()
        {
            return this.Database.Boards.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Boards).Trim()
                : "There are no registered members.";
        }
    }
}
