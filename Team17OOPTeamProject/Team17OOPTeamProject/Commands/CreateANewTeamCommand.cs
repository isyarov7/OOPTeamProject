using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;

namespace T17.Models.Commands
{
    public class CreateANewTeamCommand : Command
    {
        public CreateANewTeamCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            string name;

            try
            {
                name = this.CommandParameters[0];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTeam command parameters.");
            }

            ITeam team = this.Factory.CreateTeam(name);
            this.Database.Teams.Add(team);

            return $"Team with ID {this.Database.Teams.Count - 1} was created.";
        }
    }
}
