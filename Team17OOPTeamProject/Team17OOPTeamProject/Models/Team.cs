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
        //public string AddMember(Member member)
        //{
        //    if (!members.Contains(member))
        //    {
        //        members.Add(member);
        //        history.Add($"Member with name: {member.Name} has been succesfully added!");
        //        return $"Member with name: {member.Name} has been succesfully added!";
        //    }
        //    return $"Member with name: {member.Name} already exists!";
        //}

        //public string RemoveMember(Member member)
        //{
        //    if (members.Contains(member))
        //    {
        //        members.Remove(member);
        //        history.Add($"Member with name: {member.Name} has been succesfully removed!");
        //        return $"Member with name: {member.Name} has been succesfully removed!";
        //    }
        //    else
        //    {
        //        return $"Member with name: {member.Name} does not exists!";
        //    }
        //}

        //public string AddBoard(Board board)
        //{
        //    if (!boards.Contains(board))
        //    {
        //        boards.Add(board);
        //        history.Add($"Board with name: {board.Name} has been succesfully added!");
        //        return $"Board with name: {board.Name} has been succesfully added!";
        //    }
        //    return $"Board with name: {board.Name} already exists!";
        //}

        //public string RemoveBoard(Board board)
        //{
        //    if (boards.Contains(board))
        //    {
        //        boards.Remove(board);
        //        history.Add($"Board with name: {board.Name} has been succesfully removed!");
        //        return $"Board with name: {board.Name} has been succesfully removed!";
        //    }
        //    else
        //    {
        //        return $"Board with name: {board.Name} does not exist!";
        //    }
        //}

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
