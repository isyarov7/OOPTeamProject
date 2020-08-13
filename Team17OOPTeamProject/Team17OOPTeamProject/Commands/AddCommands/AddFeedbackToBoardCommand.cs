using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands.Abstracts;
using Team17OOPTeamProject;

namespace WIM.T17.Commands.AddCommands
{
    public class AddFeedbackToBoardCommand : Command
    {
        public AddFeedbackToBoardCommand(IList<string> commandParameters)
              : base(commandParameters)
        {
        }
        public override string Execute()
        {
            string feedbackName;
            string teamName;
            string boardName;

            try
            {
                feedbackName = this.CommandParameters[0];
                var feedback = this.Database.Feedback.Where(m => m.Title == feedbackName).FirstOrDefault();
                if (feedback == null)
                {
                    return "There is no such feedback!";
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



                //board.AddWorkItemToBoadrd(feedback);

                feedback.History.Add($"Feedback: {feedback.Title} successfully added to board: {board.Name}!");
                board.History.Add($"Feedback: {feedback.Title} was successfully added to board {board.Name}!");

                return $"Feedback: {feedback.Title} successfully added to board: {board.Name}!";
            }
            catch
            {
                throw new ArgumentException("Failed to parse AddFeedbackToBoard command parameters.");
            }
        }
    }
}
