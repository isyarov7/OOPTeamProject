using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IWorkItem
    {
        public string Title { get; }

        public string Description { get; }
        
        public IReadOnlyDictionary<string, string> Comment { get; }

        public List<string> History { get; }



    }
}
