using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;
using T17.Models.Models.Contracts;

namespace T17.Models.Models
{
    public class Board : IBoard
    {
        //Fields
        private string name;
        //Constructor
        public Board(string name)
        {
            this.Name = name;
            this.History = new List<string>();
            this.WorkItems = new List<IWorkItem>();
        }

        //Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null.");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Name should be between 5 and 10 symbols.");
                }
                this.name = value;
            }
        }
        public List<string> History { get; set; }
        public List<IWorkItem> WorkItems { get; set; }

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

            sb.AppendLine($"Board: {this.Name}");
            foreach (var item in this.WorkItems)
            {
                sb.AppendLine($"{item.PrintDetails()}");
            }
            return sb.ToString().Trim();
        }
    }
}
