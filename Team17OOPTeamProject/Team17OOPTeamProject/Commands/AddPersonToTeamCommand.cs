using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;

namespace T17.Models.Commands
{
    public class AddPersonToTeamCommand : Command
    {
        public AddPersonToTeamCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string name;
            string teamName;

            try
            {
                name = this.CommandParameters[0];
                var member = this.Database.Member.Where(m => m.Name == name).FirstOrDefault();
                if (member == null)
                {
                    return "There is no such member!";
                }
                teamName = this.CommandParameters[1];
                var team = this.Database.Teams.Where(t => t.Name == teamName).FirstOrDefault();
                if (team == null)
                {
                    return "There is no such team!";
                }
                team.Members.Add(member);
                return $"Member: {name} was added to team: {teamName}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }
        }
    }
}
