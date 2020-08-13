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
            string storyName;
            string teamName;
            string boardName;

            try
            {
                storyName = this.CommandParameters[0];
                var story = this.Database.Story.Where(m => m.Title == storyName).FirstOrDefault();
                if (story == null)
                {
                    return "There is no such story!";
                }

                teamName = this.CommandParameters[1];
                var team = this.Database.Teams.Where(t => t.Name == teamName).FirstOrDefault();
                if (team == null)
                {
                    return "There is no such team!";
                }

                boardName = this.CommandParameters[2];
                var board = this.Database.Boards.Where(t => t.Name == boardName).FirstOrDefault();
                if (board == null)
                {
                    return "There is no such team!";
                }



                board.AddWorkItemToBoadrd(story);

                story.History.Add($"Story: {story.Title} successfully added to board: {board.Name}!");
                board.History.Add($"Story: {story.Title} was successfully added to board {board.Name}!");

                return $"Story: {story.Title} successfully added to board: {board.Name}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddStoryToBoard command parameters.");
            }
        }
    }
}
