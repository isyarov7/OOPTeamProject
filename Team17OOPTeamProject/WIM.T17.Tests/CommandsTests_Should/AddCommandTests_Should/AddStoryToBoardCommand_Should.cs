﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Models;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;
using WIM.T17.Commands;
using WIM.T17.Commands.AddCommands;

namespace WIM.T17.Tests.CommandsTests_Should.AddCommandTests_Should
{
    [TestClass]
    public class AddStoryToBoardCommand_Should : BaseTestClass
    {
        [TestMethod]
        public void AddsStoryToBoardCommand_Should()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string storyTitle = "StoryTitle";
            string description = "Story description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IStory story = new Story(storyTitle, description);

            database.Boards.Add(board);
            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyTitle,
                boardName
            };

            AddStoryToBoardCommand command = new AddStoryToBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(board.WorkItems.Any(x => x.Title == storyTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenBoardNameIsNull()
        {
            string boardName = null;
            IBoard board = new Board(boardName);

            string storyTitle = "StoryTitle";
            string description = "Story description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IStory story = new Story(storyTitle, description);

            database.Boards.Add(board);
            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyTitle,
                boardName
            };

            AddStoryToBoardCommand command = new AddStoryToBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(board.WorkItems.Any(x => x.Title == storyTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenStoryTitleIsNull()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string storyTitle = null;
            string description = "Story description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IStory story = new Story(storyTitle, description);

            database.Boards.Add(board);
            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyTitle,
                boardName
            };

            AddStoryToBoardCommand command = new AddStoryToBoardCommand(parameters);
            command.Execute();
            Assert.IsTrue(board.WorkItems.Any(x => x.Title == storyTitle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreLessThanItShould()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string storyTitle = "StoryTitle";
            string description = "Story description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IStory story = new Story(storyTitle, description);

            database.Boards.Add(board);
            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyTitle
            };

            AddStoryToBoardCommand command = new AddStoryToBoardCommand(parameters);
            command.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowExeptionWhenCommandParametersAreMoreThanItShouldCorrectly()
        {
            string boardName = "Board";
            IBoard board = new Board(boardName);

            string storyTitle = "StoryTitle";
            string description = "Story description";
            List<string> stepsToProduce = new List<string> { "Noting", "to", "produce." };
            IStory story = new Story(storyTitle, description);

            database.Boards.Add(board);
            database.Stories.Add(story);

            List<string> parameters = new List<string>
            {
                storyTitle,
                boardName,
                storyTitle
            };

            AddStoryToBoardCommand command = new AddStoryToBoardCommand(parameters);
            command.Execute();
        }
    }
}
