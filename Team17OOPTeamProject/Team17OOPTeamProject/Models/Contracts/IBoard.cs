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

        public List<IWorkItem> Bugs { get; }

        public List<IWorkItem> Stories { get; }

        public List<IWorkItem> Feedbacks { get; }

        public List<string> History { get; }
        public List<IWorkItem> WorkItems { get; set; }
        public void AddWorkItemToBoadrd(IWorkItem workItem);
        
    }
}
