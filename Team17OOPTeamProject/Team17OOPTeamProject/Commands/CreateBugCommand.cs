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

            if (CommandParameters.Count < 7)
                throw new ArgumentException("You have to submit 8 parameters!");

            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            string title = this.CommandParameters[2];
            List<string> description = this.CommandParameters[3].Trim().Split(',').ToList();
            Enum.TryParse<Priority>(this.CommandParameters[4], true, out Priority priority);
            Enum.TryParse<Severity>(this.CommandParameters[5], true, out Severity severity);
            Enum.TryParse<BugStatus>(this.CommandParameters[6], true, out BugStatus bugStatus);
            List<string> stepsToProduce = this.CommandParameters[7].Trim().Split(',').ToList();

            var bug = this.Factory.CreateBug(title, description, priority, severity, bugStatus, stepsToProduce);
            this.Database.BoardItems.Add(bug);

            bug.History.Add($"Bug with title: {title} was created!");

            Board foundBoard = (Board)Database.Teams.Where(team => team.Name == teamName)
                .Select(team => team.Boards.Where(board => board.Name == teamName));

            //TODO
            return $"Team with ID {this.Database.Teams.Count - 1} was created.";
        }
    }
}
