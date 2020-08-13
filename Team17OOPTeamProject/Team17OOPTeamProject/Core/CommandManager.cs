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
            "ShowAllMembers" => new ShowAllPeopleCommand(commandParameters),
            "ShowPeopleActivity" => new ShowPersonsActivityCommand(commandParameters),
            "CreateTeam" => new CreateTeamCommand(commandParameters),
            "ShowAllTeams" => new ShowAllTeamsCommand(commandParameters),
            "ShowTeamsActivity" => new ShowTeamsActivityCommand(commandParameters),
            "AddPersonToTeam" => new AddPersonToTeamCommand(commandParameters),
            "ShowTeamMembers" => new ShowAllTeamMembersCommand(commandParameters),
            "CreateBoardInTeam" => new CreateBoardInTeamCommand(commandParameters),
            "ShowTeamBoards" => new ShowAllTeamBoardsCommand(commandParameters),
            "ShowBoardsActivity" => new ShowBoardsActivityCommand(commandParameters),
            "AddBugToBoard" => new AddBugToBoardCommand(commandParameters),
            "AddStoryToBoard" => new AddStoryToBoardCommand(commandParameters),
            "AddFeedbackToBoard" => new AddFeedbackToBoardCommand(commandParameters),
            "CreateBug" => new CreateBugCommand(commandParameters),
            "CreateStory" => new CreateStoryCommand(commandParameters),
            "CreateFeedback" => new CreateFeedbackCommand(commandParameters),
            "changebugpriority" => new ChangeBugPriorityCommand(commandParameters),
            "changestorypriority" => new ChangeStoryPriorityCommand(commandParameters),
            "changeseverityofabug" => new ChangeSeverityOfABugCommand(commandParameters),
            "changestatusofabug" => new ChangeStatusOfABugCommand(commandParameters),
            "changestorysize" => new ChangeStorySizeCommand(commandParameters),
            "changestorystatus" => new ChangeStoryStatusCommand(commandParameters),
            "changefeedbackrating" => new ChangeFeedbackRatingCommand(commandParameters),
            "changefeedbackstatus" => new ChangeFeedbackStatusCommand(commandParameters),
            "assignworkitemtoaperson" => new AssignWorkItemToAPersonCommand(commandParameters),
            //"unassignworkitemtoaperson" => new UnassignWorkItemToAPersonCommand(commandParameters),
            //"AddCommentToWorkItem" => new AddCommentToAWorkItemCommand(commandParameters),
            //TODO
            //     List work items with options:

            //o List all

            //o Filter bugs/ stories / feedback only o Filter by status and/ or assignee o Sort by title / priority / severity / size / rating

                _ => throw new InvalidOperationException("Command does not exist")
            };
    }
}
}
