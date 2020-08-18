# Team 17 Project

Team 17 Project (Iliyan Syarov/Nik Nikolov).

Access to trello - https://trello.com/b/EyJI0JiR/tigers-board

OOP Teamwork Assignment

Project Description

Design and implement a Work Item Management (WIM) Console Application.

Functional Requirements

Application should support multiple teams. Each team has name, members, and boards.

Member has name, list of work items and activity history.

 Name should be unique in the application

 Name is a string between 5 and 15 symbols.

Board has name, list of work items and activity history.

 Name should be unique in the team

 Name is a string between 5 and 10 symbols.

There are 3 types of work items: bug, story, and feedback.

Bug

Bug has ID, title, description, steps to reproduce, priority, severity, status, assignee, comments, and history.

 Title is a string between 10 and 50 symbols.

 Description is a string between 10 and 500 symbols.

 Steps to reproduce is a list of strings.

 Priority is one of the following: High, Medium, Low

 Severity is one of the following: Critical, Major, Minor  Status is one of the following: Active, Fixed  Assignee is a member from the team.

 Comments is a list of comments (string messages with author).

 History is a list of all changes (string messages) that were done to the bug.

Story

Story has ID, title, description, priority, size, status, assignee, comments, and history.

 Title is a string between 10 and 50 symbols.

 Description is a string between 10 and 500 symbols.

 Priority is one of the following: High, Medium, Low

 Size is one of the following: Large, Medium, Small

 Status is one of the following: NotDone, InProgress, Done

 Assignee is a member from the team.

 Comments is a list of comments (string messages with author).

 History is a list of all changes (string messages) that were done to the story.

Feedback

Feedback has ID, title, description, rating, status, comments, and history.

 Title is a string between 10 and 50 symbols.

 Description is a string between 10 and 500 symbols.

 Rating is an integer.

 Status is one of the following: New, Unscheduled, Scheduled, Done  Comments is a list of comments (string messages with author).

 History is a list of all changes (string messages) that were done to the feedback.

Note: IDs of work items should be unique in the application i.e. if we have a bug with ID X then we cannot have Story of Feedback with ID X.

Operations

Application should support the following operations:

 Create a new person

 Show all people

 Show person's activity

 Create a new team

 Show all teams

 Show team's activity

 Add person to team

 Show all team members

 Create a new board in a team

 Show all team boards

 Show board's activity

 Create a new Bug/Story/Feedback in a board

 Change Priority/Severity/Status of a bug

 Change Priority/Size/Status of a story

 Change Rating/Status of a feedback

 Assign/Unassign work item to a person  Add comment to a work item  List work items with options:

o List all

o Filter bugs/stories/feedback only o Filter by status and/or assignee o Sort by title/priority/severity/size/rating

General Requirements

 Follow the OOP best practices:

o Proper use data encapsulation o Proper use of inheritance and polymorphism o Proper use of interfaces and abstract classes o Proper use of static members o Proper use enumerations

o Follow the principles of strong cohesion and loose coupling

 Use LINQ

 Implement proper user input validation and display meaningful user messages

 Implement proper exception handling

 Cover functionality with unit tests (80% code coverage)

 Use Git to keep your source code and for team collaboration

Commands list:

INPUT:
CreateTeam/Tigrite
CreatePerson/Tigara
CreateBoard/Board
CreateBug/BadBugTitle/DescriptionOfBug/Turn on the computer
CreateStory/StoryTitle/StoryDescription
CreateFeedback/FeedbackTitle/FeedbackDescription/5
AddPersonToTeam/Tigara/Tigrite
AddBoardToTeam/Board/Tigrite
AddBugToBoard/BadBugTitle/Board
AddStoryToBoard/StoryTitle/Board
AddFeedbackToBoard/FeedbackTitle/Board
AddCommentToWorkItem/Bug/BadBugTitle/Comment for bad bug
AddCommentToWorkItem/Story/StoryTitle/Comment for the story
AddCommentToWorkItem/Feedback/FeedbackTitle/Comment for the feedback
ChangeBugStatus/BadBugTitle/Fixed
ChangeStoryStatus/StoryTitle/InProgress
ChangeFeedbackStatus/FeedbackTitle/Done
ChangeBugPriority/BadBugTitle/Low
ChangeStoryPriority/StoryTitle/Low
ChangeBugSeverity/BadBugTitle/Minor
ChangeStorySize/StoryTitle/Small
ChangeFeedbackRating/FeedbackTitle/3
AssignWorkItemToPerson/Bug/BadBugTitle/Tigara
AssignWorkItemToPerson/Story/StoryTitle/Tigara
ShowAllTeams
ShowAllMembers
ShowAllBoards
ShowAllBugs
ShowAllStories
ShowAllFeedbacks
ShowAllWorkItems
ShowPersonActivity/Tigara
ShowTeamsActivity/Tigrite
ShowTeamMembers/Tigrite
ShowTeamBoards/Tigrite
ShowBoardsActivity/Board
SortByTitle
SortByPriority
SortBySeverity
SortBySize
SortByRating
UnassignWorkItemFromPerson/Story/StoryTitle/Tigara
ShowPersonActivity/Tigara

OUTPUT:
CreateTeam/Tigrite
Team with ID 1 was created.
####################
CreatePerson/Tigara
Person with ID 1 was created.
####################
CreateBoard/Board
Board with ID 1 was created.
####################
CreateBug/BadBugTitle/DescriptionOfBug/Turn on the computer
Bug with ID 1 was created.
####################
CreateStory/StoryTitle/StoryDescription
Story with ID 1 was created.
####################
CreateFeedback/FeedbackTitle/FeedbackDescription/5
Feedback with ID 1 was created.
####################
AddPersonToTeam/Tigara/Tigrite
Member: Tigara was added to team: Tigrite!
####################
AddBoardToTeam/Board/Tigrite
Board: Board successfully added to team: Tigrite!
####################
AddBugToBoard/BadBugTitle/Board
Bug: BadBugTitle successfully added to board: Board!
####################
AddStoryToBoard/StoryTitle/Board
Story: StoryTitle successfully added to board: Board!
####################
AddFeedbackToBoard/FeedbackTitle/Board
Feedback: FeedbackTitle successfully added to board: Board!
####################
AddCommentToWorkItem/Bug/BadBugTitle/Comment for bad bug
Bug BadBugTitle has new comment: Comment for bad bug
####################
AddCommentToWorkItem/Story/StoryTitle/Comment for the story
Story StoryTitle has new comment: Comment for the story
####################
AddCommentToWorkItem/Feedback/FeedbackTitle/Comment for the feedback
Feedback FeedbackTitle has new comment: Comment for the feedback
####################
ChangeBugStatus/BadBugTitle/Fixed
This bug BadBugTitle status was changed to: Fixed!
####################
ChangeStoryStatus/StoryTitle/InProgress
This story StoryTitle status was changed to:InProgress!
####################
ChangeFeedbackStatus/FeedbackTitle/Done
This feedback FeedbackTitle status was changed to: Done!
####################
ChangeBugPriority/BadBugTitle/Low
This bug BadBugTitle priority was changed to: Low!
####################
ChangeStoryPriority/StoryTitle/Low
This story StoryTitle priority was changed to:Low!
####################
ChangeBugSeverity/BadBugTitle/Minor
This bug BadBugTitle severity was changed to: Minor!
####################
ChangeStorySize/StoryTitle/Small
This story StoryTitle size was changed to:Small!
####################
ChangeFeedbackRating/FeedbackTitle/3
This feedback FeedbackTitle rating was changed to: 3!
####################
AssignWorkItemToPerson/Bug/BadBugTitle/Tigara
Item BadBugTitle has been successfully assigned to Tigara.
####################
AssignWorkItemToPerson/Story/StoryTitle/Tigara
Item StoryTitle has been successfully assigned to Tigara.
####################
ShowAllTeams
***All Teams***
Team: Tigrite
Member Tigara
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress
Board: Board
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress

Type of WorkItem: Feedback
Title: FeedbackTitle
Description: FeedbackDescription
Activity history:
1. Feedback with title: FeedbackTitle was created!
2. Feedback: FeedbackTitle successfully added to board: Board!
3. Feedback FeedbackTitle has new comment: Comment for the feedback
4. This feedback FeedbackTitle status was changed to: Done!
5. This feedback FeedbackTitle rating was changed to: 3!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the feedback

Feedback status: Done
Feedback rating: 3
####################
ShowAllMembers
***All People***
Member Tigara
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress
####################
ShowAllBoards
***All Boards***
Board: Board
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress

Type of WorkItem: Feedback
Title: FeedbackTitle
Description: FeedbackDescription
Activity history:
1. Feedback with title: FeedbackTitle was created!
2. Feedback: FeedbackTitle successfully added to board: Board!
3. Feedback FeedbackTitle has new comment: Comment for the feedback
4. This feedback FeedbackTitle status was changed to: Done!
5. This feedback FeedbackTitle rating was changed to: 3!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the feedback

Feedback status: Done
Feedback rating: 3
####################
ShowAllBugs
***All Bugs***
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer
####################
ShowAllStories
***All Stories***
Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress
####################
ShowAllFeedbacks
***All Feedbacks***
Type of WorkItem: Feedback
Title: FeedbackTitle
Description: FeedbackDescription
Activity history:
1. Feedback with title: FeedbackTitle was created!
2. Feedback: FeedbackTitle successfully added to board: Board!
3. Feedback FeedbackTitle has new comment: Comment for the feedback
4. This feedback FeedbackTitle status was changed to: Done!
5. This feedback FeedbackTitle rating was changed to: 3!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the feedback

Feedback status: Done
Feedback rating: 3
####################
ShowAllWorkItems
***All Bugs***
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

***All Stories***
Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress

***All Feedbacks***
Type of WorkItem: Feedback
Title: FeedbackTitle
Description: FeedbackDescription
Activity history:
1. Feedback with title: FeedbackTitle was created!
2. Feedback: FeedbackTitle successfully added to board: Board!
3. Feedback FeedbackTitle has new comment: Comment for the feedback
4. This feedback FeedbackTitle status was changed to: Done!
5. This feedback FeedbackTitle rating was changed to: 3!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the feedback

Feedback status: Done
Feedback rating: 3
####################
ShowPersonActivity/Tigara
***MEMBER: Tigara***
History:
Person with ID 1 was created.
Member: Tigara was added to team: Tigrite!
Bug BadBugTitle added to person: Tigara
Story StoryTitle added to person: Tigara
####################
ShowTeamsActivity/Tigrite
***TEAM: Tigrite***
History:
Team with ID 1 was created.
Member: Tigara was added to team: Tigrite!
Board: Board successfully added to team: Tigrite!
####################
ShowTeamMembers/Tigrite
***TEAM: Tigrite***
***MEMBERS***
Member Tigara
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress
####################
ShowTeamBoards/Tigrite
***TEAM: Tigrite***
***BOARDS***
Board: Board
Type of WorkItem: Bug
Title: BadBugTitle
Description: DescriptionOfBug
Activity history:
1. Bug with title: BadBugTitle was created!
2. Bug: BadBugTitle successfully added to board: Board!
3. Bug BadBugTitle has new comment: Comment for bad bug
4. This bug BadBugTitle status was changed to: Fixed!
5. This bug BadBugTitle priority was changed to: Low!
6. This bug BadBugTitle severity was changed to: Minor!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for bad bug

Priority: Low
Severity: Minor
Status: Fixed
Steps to produce:
1. Turn
2. on
3. the
4. computer

Type of WorkItem: Story
Title: StoryTitle
Description: StoryDescription
Activity history:
1. Story with title: StoryTitle was created!
2. Story: StoryTitle successfully added to board: Board!
3. Story StoryTitle has new comment: Comment for the story
4. This story StoryTitle status was changed to: InProgress!
5. This story StoryTitle priority was changed to: Low!
6. This story StoryTitle size was changed to: Small!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the story

Story size: Small
Story priority: Low
Story status: InProgress

Type of WorkItem: Feedback
Title: FeedbackTitle
Description: FeedbackDescription
Activity history:
1. Feedback with title: FeedbackTitle was created!
2. Feedback: FeedbackTitle successfully added to board: Board!
3. Feedback FeedbackTitle has new comment: Comment for the feedback
4. This feedback FeedbackTitle status was changed to: Done!
5. This feedback FeedbackTitle rating was changed to: 3!
Comments:
1. 18.8.2020 г. 15:50:45 Comment for the feedback

Feedback status: Done
Feedback rating: 3
####################
ShowBoardsActivity/Board
***BOARD: Board***
History:
Board with ID 1 was created.
Board: Board successfully added to team: Tigrite!
Bug: BadBugTitle was successfully added to board Board!
Story: StoryTitle was successfully added to board Board!
Feedback: FeedbackTitle was successfully added to board Board!
####################
SortByTitle
***SORT BY TITLES***
BadBugTitle
FeedbackTitle
StoryTitle
####################
SortByPriority
***SORT BY PRIORITY***
BadBugTitle: Low
StoryTitle: Low
####################
SortBySeverity
***SORT BY SEVERITY***
BadBugTitle: Minor
####################
SortBySize
***SORT BY SIZE***
StoryTitle: Small
####################
SortByRating
***SORT BY RATING***
FeedbackTitle: 3
####################
UnassignWorkItemFromPerson/Story/StoryTitle/Tigara
Item StoryTitle has been successfully unassigned from Tigara.
####################
ShowPersonActivity/Tigara
***MEMBER: Tigara***
History:
Person with ID 1 was created.
Member: Tigara was added to team: Tigrite!
Bug BadBugTitle added to person: Tigara
Story StoryTitle added to person: Tigara
Story StoryTitle removed from person: Tigara
####################
