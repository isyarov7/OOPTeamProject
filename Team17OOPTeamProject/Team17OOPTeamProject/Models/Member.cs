using System;
using System.Collections.Generic;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;
using System.Text;

namespace T17.Models.Models
{
    public class Member : IMember
    {
        //Fields
        private string name;

        //Constructor
        public Member(string name)
        {
            this.Name = name;
            this.History = new List<string>();
            this.WorkItems = new List<IWorkItem>();
        }
        //Properties
        public List<IWorkItem> WorkItems { get; set; }
        public List<string> History { get; set; }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be null!");

                if (value.Length < 5 || value.Length > 15)
                    throw new ArgumentException("Name should be between 5 and 15 symbols.");

                this.name = value;
            }
        }

        //Methods
        public string PrintHistory()
        {
            if (this.History.Count == 0)
            {
                return $"The history of: {this.Name} is empty!";
            }

            var sb = new StringBuilder();

            sb.AppendLine("History:");

            foreach (string item in this.History)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
        public string PrintDetails()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Member {this.Name}");
            foreach (var item in this.WorkItems)
            {
                sb.AppendLine($"{item.PrintDetails()}");
            }
            return sb.ToString().Trim();
        }
    }
}