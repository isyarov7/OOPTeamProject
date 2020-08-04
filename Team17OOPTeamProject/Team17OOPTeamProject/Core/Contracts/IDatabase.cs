using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Core.Contracts
{
    public interface IDatabase
    {
        IList<IAbstract> BoardItems { get; }
        IList<ITeam> Teams { get; }
        IList<IMember> Member { get; }
    }
}
