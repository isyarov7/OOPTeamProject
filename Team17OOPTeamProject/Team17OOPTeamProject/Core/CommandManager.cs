using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using T17.Models.Core.Contracts;
using T17.Models.Commands.Contracts;
using WIM.T17.Commands;
using WIM.T17.Commands.ShowCommands;
using WIM.T17.Commands.AddCommands;

namespace T17.Models.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
            "CreatePerson" => new CreatePersonCommand(commandParameters),
            "ShowAllMembers" => new ShowAllMembersCommand(commandParameters),
            "ShowPeopleActivity" => new ShowPersonActivityCommand(commandParameters),
            "CreateTeam" => new CreateTeamCommand(commandParameters),
            "ShowAllTeams" => new ShowAllTeamsCommand(commandParameters),
            "ShowAllBoardsTeams" => new ShowAllBoardsCommand(commandParameters),
            "ShowAllWorkItems" => new ShowAllWorkItemsCommand(commandParameters),
            "ShowAllBugs" => new ShowAllBugsCommand(commandParameters),
            "ShowAllStories" => new ShowAllStoriesCommand(commandParameters),
            "ShowAllFeedbacks" => new ShowAllFeedbacksCommand(commandParameters),
            "ShowTeamsActivity" => new ShowTeamActivityCommand(commandParameters),
            "AddPersonToTeam" => new AddPersonToTeamCommand(commandParameters),
            "ShowTeamMembers" => new ShowAllTeamMembersCommand(commandParameters),
            "CreateBoardInTeam" => new CreateBoardInTeamCommand(commandParameters),
            "ShowTeamBoards" => new ShowAllTeamBoardsCommand(commandParameters),
            "ShowBoardsActivity" => new ShowBoardActivityCommand(commandParameters),
            "AddBugToBoard" => new AddBugToBoardCommand(commandParameters),
            "AddStoryToBoard" => new AddStoryToBoardCommand(commandParameters),
            "AddFeedbackToBoard" => new AddFeedbackToBoardCommand(commandParameters),
            "CreateBug" => new CreateBugCommand(commandParameters),
            "CreateStory" => new CreateStoryCommand(commandParameters),
            "CreateFeedback" => new CreateFeedbackCommand(commandParameters),
            "ChangeBugPriority" => new ChangeBugPriorityCommand(commandParameters),
            "ChangeStoryPriority" => new ChangeStoryPriorityCommand(commandParameters),
            "ChangeBugSeverity" => new ChangeBugSeverityCommand(commandParameters),
            "ChangeBugStatus" => new ChangeBugStatusCommand(commandParameters),
            "ChangeStorySize" => new ChangeStorySizeCommand(commandParameters),
            "ChangeStoryStatus" => new ChangeStoryStatusCommand(commandParameters),
            "ChangeFeedbackRating" => new ChangeFeedbackRatingCommand(commandParameters),
            "ChangeFeedbackStatus" => new ChangeFeedbackStatusCommand(commandParameters),
            "AssignWorkItemToPerson" => new AssignWorkItemToPersonCommand(commandParameters),
            "UnassingWorkItemFromPerson" => new UnassignWorkItemFromPersonCommand(commandParameters),
            "AddCommentToWorkItem" => new AddCommentToWorkItemCommand(commandParameters),
            //TODO
            //     List work items with options:

            //o List all

            //o Filter bugs/ stories / feedback only o Filter by status and/ or assignee o Sort by title / priority / severity / size / rating

                _ => throw new InvalidOperationException("Command does not exist")
            };
    }
}
}
