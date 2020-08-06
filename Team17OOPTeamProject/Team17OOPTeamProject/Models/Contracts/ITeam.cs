using System;
using System.Collections.Generic;
using System.Text;

namespace T17.Models.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; }
        public List<IMember> Members { get; }
        public List<IBoard> Boards { get; }
        public List<string> History { get; }
    }
}
