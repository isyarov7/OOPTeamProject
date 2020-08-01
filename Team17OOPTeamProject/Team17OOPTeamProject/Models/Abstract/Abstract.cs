using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Abstract
{
    public class Abstract : IAbstract
    {
        //Fields
        protected string title;
        protected string description;
        protected Dictionary<string, string> comment;
        protected List<string> history;

        //Constructor
       public Abstract(string title, string id)
        {
            this.history = new List<string>();
            this.Title = title;
            this.ID = id;
        }

        public Abstract(string title, string description, string id) :this(title, id)
        {
            this.Description = description;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description can't be null.");
                }
                if (value.Length < 10 || value.Length > 500)
                {
                    throw new ArgumentException("Description should be between 10 and 500 symbols!");
                }
                this.description = value;
            }
        }
        public string ID
        {
            get;
            private set;
        }

        public BugStatus BugStatus { get; }       

        public StoryStatus StortyStatus { get; }

        public FeedbackStatus FeedbackStatus { get; }

        public IReadOnlyDictionary<string, string> Comment => this.comment;

        public IReadOnlyCollection<string> History => this.history;

        //Methods 
        public string PrintHistory()
        {
            if (history.Count == 0)
            {
                Console.WriteLine($"The history of {this.Title} is empty!");
            }
            var sb = new StringBuilder();
            sb.AppendLine("History:");
            foreach (var item in this.history)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }      
    }
}
