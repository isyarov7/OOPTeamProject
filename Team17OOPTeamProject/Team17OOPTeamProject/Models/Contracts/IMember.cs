using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Models.Contracts
{
    public interface IMember
    {
        public IReadOnlyList<IAbstract> Stories { get; }
        public IReadOnlyList<IAbstract> Bugs { get; }
        public IReadOnlyList<IAbstract> Feedbacks { get; }
        public IReadOnlyCollection<string> History { get; }
        public string Name { get; }
    }
}
