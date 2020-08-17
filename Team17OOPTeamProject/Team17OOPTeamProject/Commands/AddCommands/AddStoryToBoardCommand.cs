using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;

namespace WIM.T17.Commands.AddCommands
{
    public class AddStoryToBoardCommand : Command
    {
        public AddStoryToBoardCommand(IList<string> commandParameters)
              : base(commandParameters)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }

            string storyName = this.CommandParameters[0];
            var story = this.Database.Stories.FirstOrDefault(m => m.Title == storyName);
            if (story == null)
            {
                return "There is no such story!";
            }

            string boardName = this.CommandParameters[1];
            var board = this.Database.Boards.FirstOrDefault(t => t.Name == boardName);
            if (board == null)
            {
                return "There is no such team!";
            }

            board.WorkItems.Add(story);
            story.History.Add($"Story: {story.Title} successfully added to board: {board.Name}!");
            board.History.Add($"Story: {story.Title} was successfully added to board {board.Name}!");

            return $"Story: {story.Title} successfully added to board: {board.Name}!";
        }
    }
}
