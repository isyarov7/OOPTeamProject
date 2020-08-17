using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace T17.Models.Commands
{
    public class ShowTeamActivityCommand : Command
    {
        public ShowTeamActivityCommand(IList<string> commandParameters)
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
            var team = this.Database.Boards.FirstOrDefault(x => x.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException("There is no such board!");
            }

            var sb = new StringBuilder();
            sb.AppendLine($"***TEAM: {teamName}***");
            sb.AppendLine(team.PrintHistory());
            return sb.ToString();
        }
    }
}
