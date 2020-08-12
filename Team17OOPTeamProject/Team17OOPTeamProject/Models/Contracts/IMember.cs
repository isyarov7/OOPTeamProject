using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Models.Contracts
{
    public interface IMember
    {
        public List<IWorkItem> Stories { get; set; }
        public List<IWorkItem> Bugs { get; set; }
        public List<IWorkItem> Feedbacks { get; set; }
        public List<string> History { get; }
        public string Name { get; }
    }
}
