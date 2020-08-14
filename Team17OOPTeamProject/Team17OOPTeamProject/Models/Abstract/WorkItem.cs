using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;

namespace Team17OOPTeamProject.Models.Abstract
{
    public abstract class WorkItem : IWorkItem
    {
        //Fields
        private string title;
        private string description;
        private Dictionary<DateTime, string> comments;
        private List<string> history;
        private IMember assignee;

        //Constructor
        public WorkItem(string title, string description)
        {
            this.comments = new Dictionary<DateTime, string>();
            this.Comments = comments;
            this.history = new List<string>();
            this.History = history;
            this.Title = title;
            this.Description = description;
            this.Assignee = Assignee;
        }

        //Properties
        public string Title
        {
            get => this.title;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title can't be null.");
                }
                if (value.Length < 10 || value.Length > 50)
                {
                    throw new ArgumentException("Title should be between 10 and 50 symbols!");
                }
                this.title = value;
            }
        }
        public string Description
        {
            get => this.description;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Description can't be empty.");
                }
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException("Description should be between 10 and 500 symbols!");
                }
                this.description = value;
            }
        }
        public Dictionary<DateTime, string> Comments 
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public List<string> History
        {
            get { return this.history; }
            set { this.history = value; }
        }

        public IMember Assignee
        {
            get { return this.assignee; }
            set { this.assignee = value; }
        }

        //Methods 
        public string PrintHistory()
        {
            var sb = new StringBuilder();
            if (history.Count == 0)
            {
                sb.AppendLine($"The history of {this.Title} is empty!");
            }
            else
            {
                
                sb.AppendLine("History:");
                foreach (var item in this.history)
                {
                    sb.AppendLine(item);
                }
            }
            return sb.ToString();
        }

        public virtual string PrintDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Title: {this.Title}");
            sb.AppendLine($"Description: {this.Description}");
            if (this.History.Count > 0)
            {
                sb.AppendLine("Activity history:");
                int counter = 1;
                foreach (var item in this.History)
                {
                    sb.AppendLine($"{counter}. {item}");
                    counter++;
                }
            }
            else
            {
                sb.AppendLine("There is no activity history.");
            }
            if (this.Comments.Count > 0)
            {
                sb.AppendLine("Comments:");
                int counter = 1;
                foreach (var item in this.Comments)
                {
                    sb.AppendLine($"{counter}. {item.Key} {item.Value}");
                        counter++;
                }
            }
            else
            {
                sb.AppendLine("There is no comments.");
            }
            return sb.ToString();
        }
    }
}