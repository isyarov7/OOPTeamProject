using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Models.Contracts
{
    public interface IMember
    {
        public IReadOnlyList<IWorkItem> Stories { get; }
        public IReadOnlyList<IWorkItem> Bugs { get; }
        public IReadOnlyList<IWorkItem> Feedbacks { get; }
        public IReadOnlyCollection<string> History { get; }
        public string Name { get; }
    }
}
