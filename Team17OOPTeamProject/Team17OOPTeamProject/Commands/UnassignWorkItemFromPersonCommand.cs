using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    public class UnassignWorkItemFromPersonCommand : Command
    {
        public UnassignWorkItemFromPersonCommand(IList<string> commandParameters)
                : base(commandParameters)
        {
        }
        public override string Execute()
        {
            try
            {
                if (CommandParameters.Count < 3)
                    throw new ArgumentException("You should have 3 parameters!");

                string workItemType = this.CommandParameters[0];
                string currenteWorkItem = this.CommandParameters[1];

                var person = this.Database.Members.Where(x => x.Name == CommandParameters[2]).FirstOrDefault();
                if (person == null) { throw new ArgumentException($"There is no such person: {person.Name}"); }

                if (workItemType == "Bug")
                {
                    var bug = this.Database.Bugs.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    person.WorkItems.Remove(bug);
                    person.History.Add($"Bug {bug.Title} removed from person: {person.Name}");
                    return $"Item {bug.Title} has been successfully unassigned from {person.Name}.";
                }
                else if (workItemType == "Story")
                {
                    var story = this.Database.Stories.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    person.WorkItems.Remove(story);
                    person.History.Add($"Bug {story.Title} removed from person: {person.Name}");
                    return $"Item {story.Title} has been successfully unassigned from {person.Name}.";
                }
                else
                {
                    return "There is no feedback with such name!";
                }
            }
            catch
            {
                throw new ArgumentException("Failed to parse UnassignWorkItemToPerson command parameters.");
            }
        }
    }
}