using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands
{
    public class AssignWorkItemToPersonCommand : Command
    {
        public AssignWorkItemToPersonCommand(IList<string> commandParameters)
              : base(commandParameters)
        {
        }
        public override string Execute()
        {
                if (CommandParameters.Count != 3)
                    throw new ArgumentException("You should have 3 parameters!");

                string workItemType = this.CommandParameters[0];
                string currenteWorkItem = this.CommandParameters[1];

                var person = this.Database.Members.Where(x => x.Name == CommandParameters[2]).FirstOrDefault();
                if (person == null) { throw new ArgumentException($"There is no such person: {person.Name}"); }

                if (workItemType == "Bug")
                {
                    var bug = this.Database.Bugs.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    person.WorkItems.Add(bug);
                    person.History.Add($"Bug {bug.Title} added to person: {person.Name}");
                    return $"Item {bug.Title} has been successfully assigned to {person.Name}.";
                }
                else if (workItemType == "Story")
                {
                    var story = this.Database.Stories.Where(x => x.Title == currenteWorkItem).FirstOrDefault();
                    person.WorkItems.Add(story);
                    person.History.Add($"Bug {story.Title} added to person: {person.Name}");
                    return $"Item {story.Title} has been successfully assigned to {person.Name}.";
                }
                else
                {
                    return "There is no feedback with such name!";
                }
        }
    }
}
