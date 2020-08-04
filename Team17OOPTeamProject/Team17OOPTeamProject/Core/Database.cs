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

        private readonly List<IAbstract> boardItems = new List<IAbstract>();
        public IList<IAbstract> BoardItems
        {
            get => this.boardItems;
        }

        private readonly List<ITeam> teams = new List<ITeam>();
        public IList<ITeam> Teams
        {
            get => this.teams;
        }

        private readonly List<IMember> member = new List<IMember>();
        public IList<IMember> Member
        {
            get => this.member;
        }
    }
}