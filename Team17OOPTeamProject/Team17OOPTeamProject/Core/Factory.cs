using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Core.Contracts;
using T17.Models.Models;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
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

        public Team CreateTeam(string name)
        {
            Team team = new Team(name);
            return team;
        }
        public Member CreateMember(string name)
        {
            Member member = new Member(name);
            return member;
        }
        public Board CreateBoard(string name)
        {
            Board board = new Board(name);
            return board;
        }
        public Bug CreateBug(string title, string description, List<string> stepsToProduce)
        {
            Bug bug = new Bug(title, description,stepsToProduce);
            return bug;
        }
        public Story CreateStory(string title, string description)
        {
            Story story = new Story(title, description);
            return story;
        }
        public Feedback CreateFeedback(string title, string description, int rating)
        {
            Feedback feedback = new Feedback(title, description, rating);
            return feedback;
        }
    }
}
