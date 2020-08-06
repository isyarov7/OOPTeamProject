using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Bug : WorkItem, IBug
    {
        //Fields 
        private readonly List<Member> assignee;
        private readonly BugStatus bugStatus = BugStatus.Active;

        //Constructor
        public Bug(string title, List<string> stepsToProduce, Priority priority, Severity severity)
            : base(title)
        {
            this.BugStatus = bugStatus;
            this.StepsToProduce = stepsToProduce;
            this.Priority = priority;
            this.Severity = severity;
            this.assignee = new List<Member>();
        }

        public Bug(string title, List<string> description, Priority priority, Severity severity, BugStatus bugStatus, List<string> stepsToProduce)
            : this(title, description, priority, severity)
        {
            this.description = new List<string>();
            this.Description = description;
        }

        //Properties
        public Priority Priority { get; private set; }

        public Severity Severity { get; private set; }

        public IReadOnlyList<Member> Assignee => this.assignee;
        public BugStatus BugStatus { get; private set; }

        public List<string> StepsToProduce
        {
            get;
            private set;
        }

      //TODO :  //Move to Commands!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11111 //
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
