using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Bug : WorkItem, IBug
    {
        //Constructor
        public Bug(string title, string description, List<string> stepsToProduce)
            : base(title, description)
        {
            this.BugStatus = BugStatus.Active;
            this.Priority = Priority.High;
            this.Severity = Severity.Critical;
            this.StepsToProduce = stepsToProduce;
        }
        //Properties
        public Priority Priority { get; set; }
        public Severity Severity { get; set; }
        public BugStatus BugStatus { get; set; }
        public List<string> StepsToProduce { get; set; }
        //Methods
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
    }
}
