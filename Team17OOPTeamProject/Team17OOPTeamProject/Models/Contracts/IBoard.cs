using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Models.Contracts
{
    public interface IBoard
    {
        public string Name { get; }
        public List<string> History { get; set; }
        public List<IWorkItem> WorkItems { get; set; }
        public string PrintDetails();
        public string PrintHistory();
    }
}
