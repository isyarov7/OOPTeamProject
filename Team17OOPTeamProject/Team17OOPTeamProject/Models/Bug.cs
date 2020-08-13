using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Bug : WorkItem, IBug
    {
        //Fields 
        private BugStatus bugStatus;

        //Constructor
        public Bug(string title, string description, Priority priority, Severity severity, List<string> stepsToProduce)
            : base(title, description)
        {
            this.BugStatus = BugStatus.Active;
            this.BugStatus = bugStatus;
            this.StepsToProduce = stepsToProduce;
            this.Priority = priority;
            this.Severity = severity;
        }

        //Properties
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
        public BugStatus BugStatus { get; set; }
        public List<string> StepsToProduce { get; set; }
        public override string PrintDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Type of WorkItem: Bug");
            sb.AppendLine(base.PrintDetails());
            sb.AppendLine($"Priority: {this.Priority}");
            sb.AppendLine($"Severity: {this.Severity}");
            sb.AppendLine($"Status: {this.BugStatus}");
            sb.AppendLine("Steps to produce:");
            int counter = 1;
            foreach (var item in this.StepsToProduce)
            {
                sb.AppendLine($"{counter}. {item}");
                counter++;
            }
            return sb.ToString();
        }

        //TODO :  //Move to Commands!!!!!!!!!!!!!!!!!!!!!!!!!!!!!11111 //
        //public string AddAssignee(Member member)
        //{
        //    if (!assignee.Contains(member))
        //    {
        //        assignee.Add(member);
        //        this.history.Add($"Member: {member.Name} is succesfully added!");
        //        return $"Member: { member.Name} is succesfully added!";
        //    }
        //    return $"Member {member.Name} is already on the list!";
        //}

        //public string RemoveAssignee(Member member)
        //{
        //    if (assignee.Contains(member))
        //    {
        //        assignee.Remove(member);
        //        this.history.Add($"Member: {member.Name} is succesfully removed!");
        //        return $"Member: {member.Name} Is succesfully removed!";
        //    }
        //    else
        //        return $"There is no member with name {member.Name} on the list!";
        //}
    }
}
