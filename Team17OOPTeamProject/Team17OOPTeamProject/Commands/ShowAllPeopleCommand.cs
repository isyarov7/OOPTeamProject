using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace T17.Models.Commands
{
    public class ShowAllPeopleCommand : Command
    {
        public ShowAllPeopleCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            return this.Database.Member.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Member).Trim()
                : "There are no registered members.";
        }
    }
}
