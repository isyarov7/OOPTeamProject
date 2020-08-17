using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Commands
{
    public class AddBugToBoardCommand : Command
    {
        public AddBugToBoardCommand(IList<string> commandParameters)
               : base(commandParameters)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }

            string bugName = this.CommandParameters[0];
            var bug = this.Database.Bugs.FirstOrDefault(m => m.Title == bugName);
            if (bug == null)
            {
                return "There is no such bug!";
            }

            string boardName = this.CommandParameters[1];
            var board = this.Database.Boards.FirstOrDefault(t => t.Name == boardName);
            if (board == null)
            {
                return "There is no such board!";
            }

            board.WorkItems.Add(bug);

            bug.History.Add($"Bug: {bug.Title} successfully added to board: {board.Name}!");
            board.History.Add($"Bug: {bug.Title} was successfully added to board {board.Name}!");

            return $"Bug: {bug.Title} successfully added to board: {board.Name}!";
        }
    }
}
