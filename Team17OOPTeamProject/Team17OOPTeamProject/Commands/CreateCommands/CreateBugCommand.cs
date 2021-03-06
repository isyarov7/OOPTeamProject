﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace T17.Models.Commands
{
    public class CreateBugCommand : Command
    {
        public CreateBugCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != 3)
            {
                throw new ArgumentException("You have to submit 3 parameters!");
            }

            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            List<string> stepsToProduce = this.CommandParameters[2].Split(' ').ToList();

            var bug = this.Factory.CreateBug(title, description, stepsToProduce);
            this.Database.Bugs.Add(bug);

            bug.History.Add($"Bug with title: {bug.Title} was created!");

            return $"Bug with ID {this.Database.Bugs.Count} was created.";
        }
    }
}
