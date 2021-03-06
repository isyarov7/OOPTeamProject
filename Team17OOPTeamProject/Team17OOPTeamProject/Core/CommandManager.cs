﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using T17.Models.Core.Contracts;
using T17.Models.Commands.Contracts;
using WIM.T17.Commands;
using WIM.T17.Commands.ShowCommands;
using WIM.T17.Commands.AddCommands;
using WIM.T17.Commands.SortCommands;

namespace T17.Models.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split("/", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
                "CreatePerson" => new CreatePersonCommand(commandParameters),
                "CreateTeam" => new CreateTeamCommand(commandParameters),
                "CreateBoard" => new CreateBoardCommand(commandParameters),
                "CreateBug" => new CreateBugCommand(commandParameters),
                "CreateStory" => new CreateStoryCommand(commandParameters),
                "CreateFeedback" => new CreateFeedbackCommand(commandParameters),
                "AddPersonToTeam" => new AddPersonToTeamCommand(commandParameters),
                "AddBoardToTeam" => new AddBoardToTeamCommand(commandParameters),
                "AddBugToBoard" => new AddBugToBoardCommand(commandParameters),
                "AddStoryToBoard" => new AddStoryToBoardCommand(commandParameters),
                "AddFeedbackToBoard" => new AddFeedbackToBoardCommand(commandParameters),
                "AddCommentToWorkItem" => new AddCommentToWorkItemCommand(commandParameters),
                "ChangeBugPriority" => new ChangeBugPriorityCommand(commandParameters),
                "ChangeStoryPriority" => new ChangeStoryPriorityCommand(commandParameters),
                "ChangeBugSeverity" => new ChangeBugSeverityCommand(commandParameters),
                "ChangeBugStatus" => new ChangeBugStatusCommand(commandParameters),
                "ChangeStorySize" => new ChangeStorySizeCommand(commandParameters),
                "ChangeStoryStatus" => new ChangeStoryStatusCommand(commandParameters),
                "ChangeFeedbackRating" => new ChangeFeedbackRatingCommand(commandParameters),
                "ChangeFeedbackStatus" => new ChangeFeedbackStatusCommand(commandParameters),
                "ShowAllMembers" => new ShowAllMembersCommand(commandParameters),
                "ShowPersonActivity" => new ShowPersonActivityCommand(commandParameters),
                "ShowAllTeams" => new ShowAllTeamsCommand(commandParameters),
                "ShowAllBoards" => new ShowAllBoardsCommand(commandParameters),
                "ShowAllWorkItems" => new ShowAllWorkItemsCommand(commandParameters),
                "ShowAllBugs" => new ShowAllBugsCommand(commandParameters),
                "ShowAllStories" => new ShowAllStoriesCommand(commandParameters),
                "ShowAllFeedbacks" => new ShowAllFeedbacksCommand(commandParameters),
                "ShowTeamsActivity" => new ShowTeamActivityCommand(commandParameters),
                "ShowTeamMembers" => new ShowAllTeamMembersCommand(commandParameters),
                "ShowTeamBoards" => new ShowAllTeamBoardsCommand(commandParameters),
                "ShowBoardsActivity" => new ShowBoardActivityCommand(commandParameters),
                "AssignWorkItemToPerson" => new AssignWorkItemToPersonCommand(commandParameters),
                "UnassignWorkItemFromPerson" => new UnassignWorkItemFromPersonCommand(commandParameters),
                "SortByTitle" => new SortByTitleCommand(commandParameters),
                "SortByPriority" => new SortByPriorityCommand(commandParameters),
                "SortBySeverity" => new SortBySeverityCommand(commandParameters),
                "SortBySize" => new SortBySizeCommand(commandParameters),
                "SortByRating" => new SortByRatingCommand(commandParameters),
                _ => throw new InvalidOperationException("Command does not exist")
            };
        }
    }
}
