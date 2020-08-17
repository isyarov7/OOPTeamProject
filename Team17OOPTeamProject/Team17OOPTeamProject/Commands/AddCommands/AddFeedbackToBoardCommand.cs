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
            if (CommandParameters.Count != 2)
            {
                throw new ArgumentException("You should have 2 parameters!");
            }

            string feedbackName = this.CommandParameters[0];
            var feedback = this.Database.Feedbacks.FirstOrDefault(m => m.Title == feedbackName);
            if (feedback == null)
            {
                return "There is no such feedback!";
            }

            string boardName = this.CommandParameters[1];
            var board = this.Database.Boards.FirstOrDefault(t => t.Name == boardName);
            if (board == null)
            {
                return "There is no such team!";
            }

            board.WorkItems.Add(feedback);

            feedback.History.Add($"Feedback: {feedback.Title} successfully added to board: {board.Name}!");
            board.History.Add($"Feedback: {feedback.Title} was successfully added to board {board.Name}!");

            return $"Feedback: {feedback.Title} successfully added to board: {board.Name}!";
        }
    }
}
