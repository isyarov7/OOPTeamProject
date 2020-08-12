using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using T17.Models.Commands;
using T17.Models.Core.Contracts;
using T17.Models.Commands.Contracts;
using WIM.T17.Commands;

namespace T17.Models.Core
{
    public class CommandManager : ICommandManager
    {
        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine
                .Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = lineParameters[0];
            List<string> commandParameters = lineParameters.Skip(1).ToList();

            return commandName switch
            {
            "createperson" => new CreatePersonCommand(commandParameters),
            "showallpeople" => new ShowAllPeopleCommand(commandParameters),
            "showpersonsactivity" => new ShowPersonsActivityCommand(commandParameters),
            "createnewteam" => new CreateANewTeamCommand(commandParameters),
            "showallteams" => new ShowAllTeamsCommand(commandParameters),
            "showteamsactivity" => new ShowTeamsActivityCommand(commandParameters),
            "addpersontoteam" => new AddPersonToTeamCommand(commandParameters),
            "showallteammembers" => new ShowAllTeamMembersCommand(commandParameters),
            "createnewboardinteam" => new CreateNewBoardInTeamCommand(commandParameters),
            "showallteamboards" => new ShowAllTeamBoardsCommand(commandParameters),
            //"showboardsactivity" => new ShowBoardsActivityCommand(commandParameters),
            "addbugtoboard" => new AddBugToBoardCommand(commandParameters),
            "createnewbug" => new CreateBugCommand(commandParameters),
            "createnewstory" => new CreateNewStoryCommand(commandParameters),
            "createnewfeedback" => new CreateNewFeedbackCommand(commandParameters),
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
            //"addcommenttoaworkitem" => new AddCommentToAWorkItemCommand(commandParameters),
            //TODO
            //     List work items with options:

            //o List all

            //o Filter bugs/ stories / feedback only o Filter by status and/ or assignee o Sort by title / priority / severity / size / rating

                _ => throw new InvalidOperationException("Command does not exist")
            };
    }
}
}
