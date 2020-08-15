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
            try
            {
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 2 parameters!");

                string name = this.CommandParameters[0];
                var member = this.Database.Members.Where(m => m.Name == name).FirstOrDefault();
                if (member == null)
                {
                    return "There is no such member!";
                }

                string teamName = this.CommandParameters[1];
                var team = this.Database.Teams.Where(t => t.Name == teamName).FirstOrDefault();
                if (team == null)
                {
                    return "There is no such team!";
                }

                team.Members.Add(member);
                team.History.Add($"Member: {name} was added to team: {teamName}!");
                member.History.Add($"Member: {name} was added to team: {teamName}!");

                return $"Member: {name} was added to team: {teamName}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }
        }
    }
}
