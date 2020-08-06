using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Core.Contracts;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace T17.Models.Core
{
    public class Factory : IFactory
    {
        private static IFactory instance;
        public static IFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Factory();
                }

                return instance;
            }
        }

        public ITeam CreateTeam(string name)
        {
            Team team = new Team(name);
            return team;
        }
        public IMember CreateMember(string name)
        {
            Member member = new Member(name);
            return member;
        }
        public IBoard CreateBoard(string name)
        {
            Board board = new Board(name);
            return board;
        }
        public IBug CreateBug(string title, List<string> description, Priority priority, Severity severity, BugStatus bugStatus, List<string> stepsToProduce)
        {
            Bug bug = new Bug(title, description, priority, severity, bugStatus, stepsToProduce);
            return bug;
        }
        public IStory CreateStory(string title, List<string> description, Priority priority, Size size)
        {
            Story story = new Story(title, description, priority, size);
            return story;
        }
        public IFeedback CreateFeedback(string title, List<string> description, int rating)
        {
            Feedback feedback = new Feedback(title, description, rating);
            return feedback;
        }
    }
}
