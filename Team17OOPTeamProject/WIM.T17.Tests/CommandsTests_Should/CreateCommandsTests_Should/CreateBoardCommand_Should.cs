using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using WIM.T17.Commands;

namespace WIM.T17.Tests.CommandsTests_Should.CreateCommandsTests_Should
{
    [TestClass]
    public class CreateBoardCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void CreateBoardCommand()
        {
            string name = "BoardName";
            IBoard board = new Board(name);

            database.Boards.Add(board);

            List<string> parameters = new List<string>
                {
                    name
                };

            CreateBoardCommand command = new CreateBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Boards.Any(x => x.Name == name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShoul()
        {
            string name = "BoardName";
            IBoard board = new Board(name);

            database.Boards.Add(board);

            List<string> parameters = new List<string>
            {
            };

            CreateBoardCommand command = new CreateBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Boards.Any(x => x.Name == name));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string name = "BoardName";
            IBoard board = new Board(name);

            database.Boards.Add(board);

            List<string> parameters = new List<string>
                {
                name,
                name
                };

            CreateBoardCommand command = new CreateBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(database.Boards.Any(x => x.Name == name));
        }
    }
}
