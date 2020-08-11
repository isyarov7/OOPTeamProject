using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

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
            string bugName;
            string teamName;

            try
            {
                bugName = this.CommandParameters[0];
                var bug = this.Database.Bugs.Where(m => m.Title == bugName).FirstOrDefault();
                if (bug == null)
                {
                    return "There is no such bug!";
                }
                teamName = this.CommandParameters[1];
                var team = this.Database.Teams.Where(t => t.Name == teamName).FirstOrDefault();
                if (team == null)
                {
                    return "There is no such team!";
                }
                team.Boards.Add(bug);
                return $"Member: {name} was added to team: {teamName}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }
        }
    }
}
