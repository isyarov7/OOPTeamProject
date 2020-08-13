using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("***All people***");
            return this.Database.Member.Count > 0
                ? string.Join(Environment.NewLine, this.Database.Member.Select(x => x.Name)).Trim()
                : "There are no registered members.";
        }
    }
}