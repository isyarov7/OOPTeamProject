using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;
using WIM.T17.Commands.AddCommands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddFeedbackToBoardCommand_Should : BaseTestClass
    {

        [TestMethod]
        public void AddsFeedbackToBoardCommand_Should()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Boards.Add(board);
            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
            {
                feedbackTitle,
                boardName
            };

            AddFeedbackToBoardCommand command = new AddFeedbackToBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(board.WorkItems.Any(x => x.Title == feedbackTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenBoardNameIsNull()
        {
            string boardName = null;
            IBoard board = new Board(boardName);

            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Boards.Add(board);
            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
            {
                feedbackTitle,
                boardName
            };

            AddFeedbackToBoardCommand command = new AddFeedbackToBoardCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenFeedbackTitleIsNull()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string feedbackTitle = null;
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Boards.Add(board);
            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
            {
                feedbackTitle,
                boardName
            };

            AddFeedbackToBoardCommand command = new AddFeedbackToBoardCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Boards.Add(board);
            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
            {
                feedbackTitle
            };

            AddFeedbackToBoardCommand command = new AddFeedbackToBoardCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShould()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string feedbackTitle = "feedbackTitle";
            string description = "Feedback description";
            int rating = 4;
            IFeedback feedback = new Feedback(feedbackTitle, description, rating);

            database.Boards.Add(board);
            database.Feedbacks.Add(feedback);

            List<string> parameters = new List<string>
            {
                feedbackTitle,
                boardName,
                feedbackTitle
            };

            AddFeedbackToBoardCommand command = new AddFeedbackToBoardCommand(parameters);
            command.Execute();
        }
    }
}