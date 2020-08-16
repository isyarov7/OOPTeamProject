using System;
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
                throw new ArgumentException("You have to submit 5 parameters!");

            string title = this.CommandParameters[0];
            string description = this.CommandParameters[1];
            Enum.TryParse<Priority>(this.CommandParameters[2], true, out Priority priority);
            if (priority == Priority.High || priority == Priority.Low || priority == Priority.Medium)
            {
            }
            else
            {
                throw new ArgumentException("Please provide some of the following priorities: High, Medium, Low");
            }

            Enum.TryParse<Severity>(this.CommandParameters[3], true, out Severity severity);
            if (severity == Severity.Critical || severity == Severity.Major || severity == Severity.Minor)
            {
            }
            else
            {
                throw new ArgumentException("Please provide some of the following severities: Critical, Major, Minor");
            }

            List<string> stepsToProduce = this.CommandParameters[4].Split(' ').ToList();

            var bug = this.Factory.CreateBug(title, description, priority, severity, stepsToProduce);
            this.Database.Bugs.Add(bug);

            bug.History.Add($"Bug with title: {bug.Title} was created!");

            return $"Bug with ID {this.Database.Bugs.Count} was created.";
        }
    }
}
