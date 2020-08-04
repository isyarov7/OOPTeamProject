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

        IBug CreateBug(string title, string description, string id, string stepsToProduce, Priority priority, Severity severity);

        IStory CreateStory(string title, string description, string id, Priority priority, Size size);

        IFeedback CreateFeedback(string title, string description, string id, int rating);
    }
}
