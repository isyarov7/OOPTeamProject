using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace T17.Models.Core.Contracts
{
    public interface IFactory
    {

        ITeam CreateTeam(string name);

        IMember CreateMember(string name);

        IBoard CreateBoard(string name);

        IBug CreateBug(string title, List<string> description, Priority priority, Severity severity, BugStatus bugStatus, List<string> stepsToProduce);

        IStory CreateStory(string title, List<string> description, Priority priority, Size size);

        IFeedback CreateFeedback(string title, List<string> description, int rating);
        object CreateBug(string title, List<string> description, object priority, object severity, object bugStatus, List<string> stepsToProduce);
    }
}
