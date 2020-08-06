using System;
using System.Collections.Generic;
using System.Text;
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
        public List<IBug> Bugs { get; set; } = new List<IBug>();
        public List<IFeedback> Feedback { get; set; } = new List<IFeedback>();
        public List<IStory> Story { get; set; } = new List<IStory>();
        public List<ITeam> Teams { get; set; } = new List<ITeam>();
        public List<IMember> Member { get; set; } = new List<IMember>();
    }
}