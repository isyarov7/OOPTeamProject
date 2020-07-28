using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models
{
    public class Bug : Abstract.Abstract
    {
        //Fields 
        private List<string> steps;
        private Priority priority;
        private Severity severity;
        private BugStatus bugStatus;
        //Assignee
        private List<string> comments;
        private List<string> history;

        //Constructor
        public Bug(string title, string description)
            : base(title, description)
        {
            this.Steps = steps;
            this.Priority = priority;
            this.Severity = severity;
            this.BugStatus = bugStatus;
            comments = new List<string>();
            this.Comments = comments;
            history = new List<string>();
            this.History = history;
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
