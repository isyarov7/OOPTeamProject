using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    public class ShowAllTeamBoardsCommand : Command
    {
        public ShowAllTeamBoardsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {

            if (CommandParameters.Count != 1)
            {
                throw new ArgumentException("You should have 1 parameters!");
            }

            string teamName = CommandParameters[0];
            var team = this.Database.Teams.FirstOrDefault(x => x.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException("There is no such team!");
            }

            if (team.Boards.Count < 1)
            {
                throw new ArgumentException("There are no registered boards.");
            }

            var sb = new StringBuilder();
            sb.AppendLine($"***TEAM: {teamName}***");
            sb.AppendLine("***BOARDS***");
            foreach (var item in team.Boards)
            {
                sb.AppendLine(item.PrintDetails());
            }
            return sb.ToString();
        }
    }
}
