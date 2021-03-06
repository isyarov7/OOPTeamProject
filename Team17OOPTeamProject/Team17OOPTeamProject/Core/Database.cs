﻿using System;
using System.Collections.Generic;
using T17.Models.Core.Contracts;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Core
{
    public class Database : IDatabase
    {
        private static IDatabase instance = null;
        public static IDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }
        public List<IBug> Bugs { get; } = new List<IBug>();
        public List<IFeedback> Feedbacks { get; } = new List<IFeedback>();
        public List<IStory> Stories { get; } = new List<IStory>();
        public List<ITeam> Teams { get; } = new List<ITeam>();
        public List<IMember> Members { get; } = new List<IMember>();
        public List<IBoard> Boards { get;  } = new List<IBoard>();     
    }
}