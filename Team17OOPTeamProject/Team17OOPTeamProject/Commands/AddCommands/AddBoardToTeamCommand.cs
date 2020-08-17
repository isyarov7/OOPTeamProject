using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.AddCommands
{
    public class AddBoardToTeamCommand : Command
    {
        public AddBoardToTeamCommand(IList<string> commandParameters)
                 : base(commandParameters)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }

            string boardName = this.CommandParameters[0];
            var board = this.Database.Boards.FirstOrDefault(m => m.Name == boardName);
            if (board == null)
            {
                throw new ArgumentException("There is no such board!");
            }

            string teamName = this.CommandParameters[1];
            var team = this.Database.Teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException("There is no such team!");
            }

            team.Boards.Add(board);

            team.History.Add($"Board: {board.Name} successfully added to team: {team.Name}!");
            board.History.Add($"Board: {board.Name} successfully added to team: {team.Name}!");

            return $"Board: {board.Name} successfully added to team: {team.Name}!";
        }
    }
}