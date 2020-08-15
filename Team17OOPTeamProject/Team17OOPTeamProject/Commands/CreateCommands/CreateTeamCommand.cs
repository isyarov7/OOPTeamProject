﻿using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Abstracts;
using T17.Models.Models.Contracts;

namespace T17.Models.Commands
{
    public class CreateTeamCommand : Command
    {
        public CreateTeamCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }

        public override string Execute()
        {
            try
            {
                if (CommandParameters.Count > 2)
                    throw new ArgumentException("You should have 1 parameter!");
                if (CommandParameters.Count < 2)
                    throw new ArgumentException("You should have 1 parameter!");

                string name = this.CommandParameters[0];
                ITeam team = this.Factory.CreateTeam(name);
                this.Database.Teams.Add(team);
                team.History.Add($"Team with ID {this.Database.Teams.Count} was created.");
                return $"Team with ID {this.Database.Teams.Count} was created.";
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTeam command parameters.");
            }            
        }
    }
}
