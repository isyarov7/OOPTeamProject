using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks.Sources;
using T17.Models.Core;
using T17.Models.Core.Contracts;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void AddsBugToBoardCommand_Should()
        {
            string teamName = "Tigrite";
            ITeam team = new Team(teamName);

            string boardName = "Board";
            IBoard board = new Board(boardName);

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            string stepsToProduce = "steps to produce";
            IBug bug = new Bug(bugTitle, description, priority, severity, stepsToProduce);

            database.Teams.Add(team);
            database.Boards.Add(board);
            team.Boards.Add(board);
            database.Bugs.Add(bug);

            List<string> parameters = new List<string>
            {
                bugTitle,
                boardName
            };

            AddBugToBoardCommand command = new AddBugToBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(board.WorkItems.Any(x => x.Title == bugTitle));
        }
    }
}
