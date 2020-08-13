using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models;

namespace WIM.T17.Commands
{
    class ShowAllTeamMembersCommand : Command
    {
        public ShowAllTeamMembersCommand(IList<string> commandParameters)
         : base(commandParameters)
        {
        }

        public override string Execute()
        {
            string teamName;
            try
            {
                teamName = CommandParameters[0];
                var team = this.Database.Teams.Where(x => x.Name == teamName).FirstOrDefault();

                if (team == null)
                {
                    throw new ArgumentException("There is no such team!");
                }

                if (team.Members.Count < 1)
                {
                    return "There are no registered members.";
                }

                Console.WriteLine($"***TEAM: {teamName}*** \n***MEMBERS***");
                return string.Join(Environment.NewLine, team.Members.Select(x => x.Name)).Trim();
            }
            catch
            {
                throw new ArgumentException("Failed to parse ShowAllTeamMembers command parameters.");
            }
        }
    }
}
