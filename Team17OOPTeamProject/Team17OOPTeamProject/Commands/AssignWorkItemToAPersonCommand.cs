using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject.Models.Contracts;

namespace WIM.T17.Commands
{
    class AssignWorkItemToAPersonCommand : Command
    {
        public AssignWorkItemToAPersonCommand(IList<string> commandParameters)
              : base(commandParameters)
        {
        }
        public override string Execute()
        {
            
            string boardName;
            string memberName;

            try
            {
                boardName = this.CommandParameters[0];
                var board = this.Database.Boards.Where(m => m.Name == boardName).FirstOrDefault();
                if (board == null)
                {
                    return "There is no such board!";
                }

                var item = this.Database.GetName(CommandParameters[1]);
                if (item == null) { throw new ArgumentException($"There is no such item: {item}"); }
                memberName = this.CommandParameters[2];
                if (memberName == null) { throw new ArgumentException($"There is no such item: {memberName}"); }
                var member = this.Database.Member.Where(m => m.Name == memberName).FirstOrDefault();


                if (item is IStory)
                {
                    IStory story = (IStory)item;
                    member.Stories.Add(item);
                    story.Assignee = member;
                }
                else if (item is IBug)
                {
                    IBug story = (IBug)item;
                    member.Bugs.Add(item);
                    story.Assignee = member;
                }
                else
                {
                    return "There is no feedback with such name!";
                }

                board.History.Add($"{board.Name} with {item.Title} has been assigned to {member.Name}.");
                item.History.Add($"{item.Title} with {board.Name} has been assigned to {member.Name}.");
                member.History.Add($"{member.Name} from {board.Name} has recieved an item: {item.Title}.");

                return $"Item {item.Title} has been successfully assigned to {member.Name} from board {board.Name}.";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateMember command parameters.");
            }
        }
    }
}
