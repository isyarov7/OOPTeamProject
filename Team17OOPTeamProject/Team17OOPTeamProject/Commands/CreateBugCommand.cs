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

            if (CommandParameters.Count < 5)
                throw new ArgumentException("You have to submit 6 parameters!");

            string title = this.CommandParameters[0];
            List<string> description = this.CommandParameters[1].Trim().Split(',').ToList();
            Enum.TryParse<Priority>(this.CommandParameters[2], true, out Priority priority);
            Enum.TryParse<Severity>(this.CommandParameters[3], true, out Severity severity);
            Enum.TryParse<BugStatus>(this.CommandParameters[4], true, out BugStatus bugStatus);
            List<string> stepsToProduce = this.CommandParameters[5].Trim().Split(',').ToList();

            var bug = this.Factory.CreateBug(title, description, priority, severity, bugStatus, stepsToProduce);
            this.Database.Bugs.Add(bug);

            bug.History.Add($"Bug with title: {title} was created!");
           
            return $"Bug with ID {this.Database.Bugs.Count} was created.";
        }
    }
}
