using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;

namespace T17.Models.Commands
{
    public class CreateANewPersonCommand : Command
    {
        public CreateANewPersonCommand(IList<string> commandParameters)
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
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }

            IMember member = this.Factory.CreateMember(name);
            this.Database.Member.Add(member);

            return $"Team with ID {this.Database.Member.Count - 1} was created.";
        }
    }
}
