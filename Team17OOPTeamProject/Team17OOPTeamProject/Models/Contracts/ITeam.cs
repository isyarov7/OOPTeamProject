using System;
using System.Collections.Generic;
using System.Text;

namespace T17.Models.Models.Contracts
{
    public interface ITeam
    {
        public string Name { get; }
        public IReadOnlyList<IMember> Members { get; }
        public IReadOnlyList<IBoard> Boards { get; }
        public IReadOnlyCollection<string> History { get; }
    }
}
