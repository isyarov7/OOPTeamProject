using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models;

namespace WIM.T17.Commands
{
    public class ShowAllTeamMembersCommand : Command
    {
        public ShowAllTeamMembersCommand(IList<string> commandParameters)
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

            if (team.Members.Count < 1)
            {
                throw new ArgumentException("There are no registered members.");
            }

            var sb = new StringBuilder();
            sb.AppendLine($"***TEAM: {teamName}***");
            sb.AppendLine("***MEMBERS***");
            foreach (var item in team.Members)
            {
                sb.AppendLine(item.PrintDetails());
            }
            return sb.ToString();
        }
    }
}