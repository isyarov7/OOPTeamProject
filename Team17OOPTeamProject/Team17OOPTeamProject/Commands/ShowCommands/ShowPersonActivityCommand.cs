﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace T17.Models.Commands
{
    public class ShowPersonActivityCommand : Command
    {
        public ShowPersonActivityCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string memberName = CommandParameters[0];
            var member = this.Database.Members.Where(x => x.Name == memberName).FirstOrDefault();
            if (member == null)
            {
                throw new ArgumentException("There is no such board!");
            }

            var sb = new StringBuilder();
            sb.AppendLine($"***MEMBER: {memberName}***");
            sb.AppendLine(member.PrintHistory());
            return sb.ToString();
        }
    }
}
