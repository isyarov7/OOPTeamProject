using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    class CreateNewBoardInTeamCommand : Command
    {
        public CreateNewBoardInTeamCommand(IList<string> commandParameters)
           : base(commandParameters)
        {
        }

        public override string Execute()
        {

            string name, teamName;

            try
            {
                name = CommandParameters[0];
                if (name.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("The name of board should contains at least 4 symbols!");
                }
                var board = this.Factory.CreateBoard(name);

                teamName = CommandParameters[1];

                var team = this.Database.Teams.Where(t => t.Name == teamName).FirstOrDefault();

                team.Boards.Add(board);
                this.Database.Boards.Add(board);

                team.History.Add($"New board: {name} was successfully created!");

                return $"New board: {name} was successfully created!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateNewBoardInTeam command parameters.");
            }
        }
    }
}