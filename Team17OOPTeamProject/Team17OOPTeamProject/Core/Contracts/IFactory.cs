using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace T17.Models.Core.Contracts
{
    public interface IFactory
    {

        Team CreateTeam(string name);

        Member CreateMember(string name);

        Board CreateBoard(string name);

        Bug CreateBug(string title, string description, Priority priority, Severity severity, BugStatus bugStatus, List<string> stepsToProduce);

        Story CreateStory(string title, string description, Priority priority, Size size);

        Feedback CreateFeedback(string title, string description, int rating);
    }
}