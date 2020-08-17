using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;

namespace WIM.T17.Commands
{
    public class CreateBoardCommand : Command
    {
        public CreateBoardCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != 1)
            {
                throw new ArgumentException("You should have 1 parameter!");
            }

            string name = this.CommandParameters[0];
            IBoard board = this.Factory.CreateBoard(name);
            this.Database.Boards.Add(board);
            board.History.Add($"Board with ID {this.Database.Boards.Count} was created.");
            return $"Board with ID {this.Database.Boards.Count} was created.";
        }
    }
}