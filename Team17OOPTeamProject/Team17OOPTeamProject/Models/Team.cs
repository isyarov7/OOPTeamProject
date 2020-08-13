using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;

namespace T17.Models.Models
{
    public class Team : ITeam
    {
        private string name;

        public Team(string name)
        {
            this.History = new List<string>();
            this.Members = new List<IMember>();
            this.Boards = new List<IBoard>();
            this.Name = name;
        }

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
                    throw new ArgumentException("Name can't be null.");
                }

                this.name = value;
            }
        }

        public List<IMember> Members { get; set; }

        public List<IBoard> Boards { get; set; }

        public List<string> History { get; set; }
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

            sb.AppendLine($"Team: {this.Name}");
            foreach (var item in this.Members)
            {
                sb.AppendLine($"{item.PrintDetails()}");
            }
            foreach (var item in this.Boards)
            {
                sb.AppendLine($"{item.PrintDetails()}");
            }
            return sb.ToString();
        }
    }
}
