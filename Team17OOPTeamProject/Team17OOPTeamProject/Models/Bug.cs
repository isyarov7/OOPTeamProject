using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Bug : Abstract.Abstract, IBug
    {
        //Fields 
        private List<string> steps;
        private Priority priority;
        private Severity severity;
        private BugStatus bugStatus;
        //Assignee

        //Constructor
        public Bug(string title, string description, List<string> comments, List<string> history)
            : base(title, description, comments, history)
        {
            this.Steps = steps;
            this.Priority = priority;
            this.Severity = severity;
            this.BugStatus = bugStatus;
            
        }

        //Properties
        public List<string> Steps { get => steps; set => steps = value; }
        public Priority Priority { get => priority; set => priority = value; }
        public Severity Severity { get => severity; set => severity = value; }
        public BugStatus BugStatus { get => bugStatus; set => bugStatus = value; }
        //Get from BASE ? 
        public override List<string> Comments { get => base.Comments; set => base.Comments = value; }
        public override List<string> History { get => base.History; set => base.History = value; }
    }
}
