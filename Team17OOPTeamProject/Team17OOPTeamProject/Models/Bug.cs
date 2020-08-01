using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Bug : Abstract.Abstract, IBug
    {
        //Fields 
        private readonly List<Member> assignee;
        private readonly BugStatus bugStatus = BugStatus.Active;

        //Constructor
        public Bug(string title, string id, string stepsToProduce, Priority priority, Severity severity)
            : base(title, id)
        {
            this.BugStatus = bugStatus;
            this.StepsToProduce = stepsToProduce;
            this.Priority = priority;
            this.Severity = severity;
            this.assignee = new List<Member>();
        }

        public Bug(string title, string description, string id, string stepsToProduce, Priority priority, Severity severity)
            : this(title, id, stepsToProduce, priority, severity)
        {
            this.Description = description;
        }

        //Properties
        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public IReadOnlyList<Member> Assignee => this.assignee;
        public BugStatus BugStatus { get; private set; }

        public string StepsToProduce
        {
            get;
            private set;
        }

        //Methods
        public string AddAssignee(Member member)
        {
            if (!assignee.Contains(member))
            {
                assignee.Add(member);
                this.history.Add($"Member: {member.Name} is succesfully added!");
                return $"Member: { member.Name} is succesfully added!";
            }
            return $"Member {member.Name} is already on the list!";
        }

        public string RemoveAssignee(Member member)
        {
            if (assignee.Contains(member))
            {
                assignee.Remove(member);
                this.history.Add($"Member: {member.Name} is succesfully removed!");
                return $"Member: {member.Name} Is succesfully removed!";
            }
            else
            return $"There is no member with name {member.Name} on the list!";
        }

        public void ChangeBugStatusToFixed()
        {
            if (BugStatus != BugStatus.Fixed)
            {
                this.history.Add($"The status of the Bug: { this.BugStatus} is changed to {++this.BugStatus}!");
            }
        }

        public void ChangeBugStatusToActive()
        {
            if (BugStatus != BugStatus.Active)
            {
                this.history.Add($"The status of the Bug: {this.BugStatus} is changed to {--this.BugStatus}!");
            }
        }
    }
}
