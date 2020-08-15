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
            try
            {
                if (CommandParameters.Count < 2) 
                    throw new ArgumentException("You should have 2 parameters!");

                string bugName = this.CommandParameters[0];
                var bug = this.Database.Bugs.Where(m => m.Title == bugName).FirstOrDefault();
                if (bug == null)
                {
                    return "There is no such bug!";
                }

                string boardName = this.CommandParameters[1];
                var board = this.Database.Boards.Where(t => t.Name == boardName).FirstOrDefault();
                if (board == null)
                {
                    return "There is no such board!";
                }

                board.WorkItems.Add(bug);

                bug.History.Add($"Bug: {bug.Title} successfully added to board: {board.Name}!");
                board.History.Add($"Bug: {bug.Title} was successfully added to board {board.Name}!");

                return $"Bug: {bug.Title} successfully added to board: {board.Name}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddBugToBoard command parameters.");
            }
        }
    }
}
