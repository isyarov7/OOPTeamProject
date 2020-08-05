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
            string team;

            try
            {
                name = this.CommandParameters[0];
                team = this.CommandParameters[1];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }

            

            return $"Team with ID {this.Database.Member.Count - 1} was created.";
        }
    }
}
