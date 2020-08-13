using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Models.Contracts
{
    public interface IMember
    {
        public List<IWorkItem> WorkItems { get; set; }
        public List<string> History { get; }
        public string Name { get; }
        public string PrintHistory();
        public string PrintDetails();
    }
}
