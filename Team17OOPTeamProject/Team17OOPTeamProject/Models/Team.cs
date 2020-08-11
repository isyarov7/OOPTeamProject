using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;

namespace T17.Models.Models
{
    public class Team : ITeam
    {
        private  List<string> history;
        private  List<IMember> members;
        private  List<IBoard> boards;
        private string name;

        public Team(string name)
        {
            this.history = new List<string>();
            this.members = new List<IMember>();
            this.boards = new List<IBoard>();
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

        public List<IMember> Members => this.members;

        public List<IBoard> Boards 
        {
            get { return this.boards; }
            set { this.boards = value; }
        }

        public List<string> History => this.history;
        public string AddMember(Member member)
        {
            if (!members.Contains(member))
            {
                members.Add(member);
                history.Add($"Member with name: {member.Name} has been succesfully added!");
                return $"Member with name: {member.Name} has been succesfully added!";
            }
            return $"Member with name: {member.Name} already exists!";
        }

        public string RemoveMember(Member member)
        {
            if (members.Contains(member))
            {
                members.Remove(member);
                history.Add($"Member with name: {member.Name} has been succesfully removed!");
                return $"Member with name: {member.Name} has been succesfully removed!";
            }
            else
            {
                return $"Member with name: {member.Name} does not exists!";
            }
        }

        public string AddBoard(Board board)
        {
            if (!boards.Contains(board))
            {
                boards.Add(board);
                history.Add($"Board with name: {board.Name} has been succesfully added!");
                return $"Board with name: {board.Name} has been succesfully added!";
            }
            return $"Board with name: {board.Name} already exists!";
        }

        public string RemoveBoard(Board board)
        {
            if (boards.Contains(board))
            {
                boards.Remove(board);
                history.Add($"Board with name: {board.Name} has been succesfully removed!");
                return $"Board with name: {board.Name} has been succesfully removed!";
            }
            else
            {
                return $"Boardwith name: {board.Name} does not exist!";
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Team {this.name}");
            sb.AppendLine("Members:");
            if (members.Count < 1)
            {
                sb.AppendLine("No members are part of this team!");
            }
            else
            {
                sb.AppendLine(string.Join(Environment.NewLine, members));
            }

            sb.AppendLine("Boards:");
            if (boards.Count < 1)
            {
                sb.AppendLine("No boards are part of this team!");
            }
            else
            {
                sb.AppendLine(string.Join(Environment.NewLine, boards));
            }

            return sb.ToString().Trim();
        }
    }
}
