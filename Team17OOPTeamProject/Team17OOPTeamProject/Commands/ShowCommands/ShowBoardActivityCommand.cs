using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.ShowCommands
{
    public class ShowBoardActivityCommand : Command
    {
        public ShowBoardActivityCommand(IList<string> commandParameters)
          : base(commandParameters)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count < 1)
                throw new ArgumentException("You should have 1 parameters!");

            string boardName = CommandParameters[0];
            var board = this.Database.Boards.Where(x => x.Name == boardName).FirstOrDefault();
            if(board == null)
            {
                throw new ArgumentException("There is no such board!");
            }

            var sb = new StringBuilder();
            sb.AppendLine($"***BOARD: {boardName}***");
            sb.AppendLine(board.PrintHistory());
            return sb.ToString();
        }
    }
}
