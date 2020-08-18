using System;
using System.Text;
using T17.Models.Core.Contracts;

namespace T17.Models.Core
{
    public class Engine : IEngine
    {
        private static Engine instance;
        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        private readonly ICommandManager commandManager;

        private Engine()
        {
            this.commandManager = new CommandManager();
        }

        public void Run()
        {
            Console.WriteLine(InitialMessage());
            Console.WriteLine("Please split your parameters with /");
            while (true)
            {
                // Read -> Process -> Print -> Repeat
                string input = this.Read();

                if (input == "exit")
                    break;

                string result = this.Process(input);

                this.Print(result);
            }
        }

        private string Read()
        {
            string input = Console.ReadLine();
            return input;
        }

        private string Process(string commandLine)
        {
            try
            {
                var command = this.commandManager.ParseCommand(commandLine);
                string result = command.Execute();

                return result.Trim();
            }
            catch (Exception e)
            {
                while (e.InnerException != null)
                {
                    e = e.InnerException;
                }

                return $"ERROR: {e.Message}";
            }
        }

        private void Print(string commandResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(commandResult);
            sb.AppendLine("####################");
            Console.WriteLine(sb.ToString().Trim());
        }
        private string InitialMessage()
        {
            var sb = new StringBuilder();
            sb.AppendLine("WIM - Team project of Nik Nikolov and Iliyan Syarov");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("Please type some of the following commands:");
            sb.AppendLine("***Create commands***");
            sb.AppendLine("1.  CreateTeam/[teamName]");
            sb.AppendLine("2.  CreatePerson/[personName]");
            sb.AppendLine("3.  CreateBoard/[boardName]");
            sb.AppendLine("4.  CreateBug/[bugTitle]/[DescriptionOfBug]/[StepsToProduce] => Bug have default status: Active/ priority: High/ severity: Critical");
            sb.AppendLine("5.  CreateStory/[StoryTitle]/[StoryDescription] = Story have default status: NotDone/ priority: High/ size: Large");
            sb.AppendLine("6.  CreateFeedback/[FeedbackTitle]/[rating] = Feedback have default status: New");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("***Add commands***");
            sb.AppendLine("1.  AddPersonToTeam/[personName]/[teamName]");
            sb.AppendLine("2.  AddBoardToTeam/[boardName]/[teamName]");
            sb.AppendLine("3.  AddBugToBoard/[bugName]/[boardName]");
            sb.AppendLine("4.  AddStoryToBoard/[storyName]/[boardName]");
            sb.AppendLine("5.  AddFeedbackToBoard/[feedbackName]/[boardName]");
            sb.AppendLine("6.  AddCommentToWorkItem/[WItype: Bug, Story, Feedback]/[bugName/storyName/feedbackName]/[Comment]");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("***Change enum commands***");
            sb.AppendLine("1.  ChangeBugStatus/[bugName]/[Fixed]");
            sb.AppendLine("2.  ChangeStoryStatus/[storyName]/[InProgress/Done]");
            sb.AppendLine("3.  ChangeFeedbackStatus/[feedbackTitle]/[Unscheduled/Scheduled/Done]");
            sb.AppendLine("4.  ChangeBugPriority/[bugName]/[Medium/Low]");
            sb.AppendLine("5.  ChangeStoryPriority/[storyName]/[Medium/Low]");
            sb.AppendLine("6.  ChangeBugSeverity/[bugName]/[Major/Minor]");
            sb.AppendLine("7.  ChangeStorySize/[storyName]/[Medium/Small]");
            sb.AppendLine("8.  ChangeFeedbackRating/[feedbackName]/[from 0-5]");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("***Assign work item to person commands***");
            sb.AppendLine("1.  AssignWorkItemToPerson/[TypeOfWI: Bug, Story]/[bugName/storyName]/[personName]");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("***Unassign work item from person commands***");
            sb.AppendLine("1.  UnassignWorkItemFromPerson/[TypeOfWI: Bug, Story]/[bugName/storyName]/[personName]");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("***Show commands***");
            sb.AppendLine("1.  ShowAllTeams");
            sb.AppendLine("2.  ShowAllMembers");
            sb.AppendLine("3.  ShowAllBoards");
            sb.AppendLine("4.  ShowAllBugs");
            sb.AppendLine("5.  ShowAllStories");
            sb.AppendLine("6.  ShowAllFeedbacks");
            sb.AppendLine("7.  ShowAllWorkItems");
            sb.AppendLine("8.  ShowPersonActivity/[personName]");
            sb.AppendLine("9.  ShowTeamsActivity/[teamName]");
            sb.AppendLine("10.  ShowTeamMembers/[teamName]");
            sb.AppendLine("11.  ShowTeamBoards/[teamName]");
            sb.AppendLine("12.  ShowBoardsActivity/[boardName]");
            sb.AppendLine("########################################");
            sb.AppendLine();
            sb.AppendLine("***Sort commands***");
            sb.AppendLine("1.  SortByTitle");
            sb.AppendLine("2.  SortByPriority");
            sb.AppendLine("3.  SortBySeverity");
            sb.AppendLine("4.  SortBySize");
            sb.AppendLine("5.  SortByRating");
            sb.AppendLine("########################################");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
