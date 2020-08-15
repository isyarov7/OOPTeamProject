using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    class CreateBoardInTeamCommand : Command
    {
        public CreateBoardInTeamCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {
            try
            {
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 2 parameters!");

                string boardName = CommandParameters[0];
                if (boardName.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The name of board should contains at least 4 symbols!");
                }
                var board = this.Factory.CreateBoard(boardName);

                string teamName = CommandParameters[1];

                var team = this.Database.Teams.Where(t => t.Name == teamName).FirstOrDefault();

                team.Boards.Add(board);
                team.History.Add($"{board} board was successfully added to team: {team}");
                board.History.Add($"{board} board was successfully added to team: {team}");
                this.Database.Boards.Add(board);

                return $"New board: {boardName} was successfully created!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateNewBoardInTeam command parameters.");
            }
        }
    }
}