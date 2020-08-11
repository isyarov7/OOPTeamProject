using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace T17.Models.Commands
{
    public class ShowAllTeamsCommand : Command
    {
        public ShowAllTeamsCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            return this.Database.Teams.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Teams.Select(x => x.Name)).Trim()
                : "There are no registered teams.";
        }
    }
}
