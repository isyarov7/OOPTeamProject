﻿using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;

namespace T17.Models.Commands
{
    public class CreatePersonCommand : Command
    {
        public CreatePersonCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != 1)
            {
                throw new ArgumentException("You should have 1 parameters!");
            }

            string name = this.CommandParameters[0];

            IMember member = this.Factory.CreateMember(name);
            this.Database.Members.Add(member);
            member.History.Add($"Person with ID {this.Database.Members.Count} was created.");
            return $"Person with ID {this.Database.Members.Count} was created.";
        }
    }
}
