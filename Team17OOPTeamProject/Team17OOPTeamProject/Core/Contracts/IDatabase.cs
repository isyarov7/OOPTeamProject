using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Core.Contracts
{
    public interface IDatabase
    {
        List<IBug> Bugs { get; }
        List<IFeedback> Feedbacks { get; }
        List<IStory> Stories { get; }
        List<ITeam> Teams { get; }
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }
    }
}
