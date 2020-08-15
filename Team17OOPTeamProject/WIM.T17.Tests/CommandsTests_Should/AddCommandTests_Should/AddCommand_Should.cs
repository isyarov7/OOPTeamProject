using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using T17.Models.Core;
using T17.Models.Core.Contracts;
using T17.Models.Models;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddCommand_Should
    {
        [TestMethod]
        public void AddsBugToBoardCommand_Should() 
        {
            IDatabase database = new Database();
            IFactory factory = new Factory();

            string boardName = "Board";
            var board = new Board(boardName);

            string bugTitle = "MnogoLoshBug";
            string description = "Bug description";
            string stepsToProduce = "steps to produce";
            Priority priority = Priority.High;
            Severity severity = Severity.Critical;
            var bug = new Bug(bugTitle, description, priority, severity, stepsToProduce);
            database.Boards.Add(board);
            database.Bugs.Add(bug);
            List<string> parameters = new List<string>
            {                
                bugTitle,
                boardName
            };
            AddBugToBoardCommand command = new AddBugToBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(board.WorkItems.Contains(bug));
            
            
        }
    }
}
