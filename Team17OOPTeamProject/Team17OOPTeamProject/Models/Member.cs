using System;
using System.Collections.Generic;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject;
using System.Text;

namespace T17.Models.Models
{
    public class Member : IMember
    {
        //Fields
        private readonly List<IAbstract> stories;
        private readonly List<IAbstract> bugs;
        private readonly List<IAbstract> feedbacks;
        private readonly List<string> history;
        private string name;

        //Constructor
        public Member(string name)
        {
            this.history = new List<string>();
            this.stories = new List<IAbstract>();
            this.feedbacks = new List<IAbstract>();
            this.bugs = new List<IAbstract>();
            this.Name = name;
        }
        //Properties
        public IReadOnlyList<IAbstract> Stories => this.stories;

        public IReadOnlyList<IAbstract> Bugs => this.bugs;

        public IReadOnlyList<IAbstract> Feedbacks => this.feedbacks;

        public IReadOnlyCollection<string> History => this.history;

        public string Name 
        { 
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))             
                    throw new ArgumentException("Name cannot be null!");
                
                if (value.Length < 5 || value.Length > 15)
                    throw new ArgumentException("Name should be between 5 and 15 symbols.");

                    this.name = value;
            }
        }

        //Methods

        public string AddBug(Bug bug)
        {
            if (!bugs.Contains(bug))
            {
                bugs.Add(bug);
                this.history.Add($"Bug {bug.Title} has been succesfully added!");
                return $"Bug {bug.Title} has been succesfully added!";
            }
            return $"Bug with title: {bug.Title} is already exist!";
        }

        public string RemoveBug(Bug bug)
        {
            if (bugs.Contains(bug))
            {
                bugs.Remove(bug);
                this.history.Add($"Bug {bug.Title} has been successfully removed!");
                return $"Bug {bug.Title} has been succesfully removed!";
            }
            else
            {
                return $"Bug with this title: {bug.Title} does not exist!";
            }
        }
        public string AddStory(Story story)
        {
            if (!stories.Contains(story))
            {
                stories.Add(story);
                this.history.Add($"Story {story.Title} has been succesfully added!");
                return $"Story with title: {story.Title} has been succesfully added!";
            }
            return $"Story with title: {story.Title} is already exist!";
        }

        public string RemoveStory(Story story)
        {
            if (stories.Contains(story))
            {
                stories.Remove(story);
                this.history.Add($"Story with title: {story.Title} has been succesfully removed!");
                return $"Story with title: {story.Title} has been succesfully removed!";
            }
            else
            {
                return $"Story with title: {story.Title} does not exist!";
            }
        }

        public string AddFeedback(Feedback feedback)
        {
            if (!feedbacks.Contains(feedback))
            {
                feedbacks.Add(feedback);
                this.history.Add($"Feedback with title: {feedback.Title} has been succesfully added!");
                return $"Feedback with title: {feedback.Title} has been succesfully added!";
            }
            return $"Feedback with title: {feedback.Title} is already exist!";
        }

        public string RemoveFeedback(Feedback feedback)
        {
            if (feedbacks.Contains(feedback))
            {
                feedbacks.Remove(feedback);
                this.history.Add($"Feedback with title: {feedback.Title} has been succesfully removed!");
                return $"Feedback with title: {feedback.Title} has been succesfully removed!";
            }
            else
            {
                return $"Feedback with title: {feedback.Title} does not exist!";
            }
        }
        public string PrintHistory()
        {
            if (history.Count == 0)
            {
                return $"The history of: {this.Name} is empty!";
            }

            var sb = new StringBuilder();

            sb.AppendLine("History:");

            foreach (string item in this.history)
            {
                sb.AppendLine(item);
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Member {this.name}");
            sb.AppendLine("Stories:");
            if (stories.Count < 1)
            {
                sb.AppendLine("No members are part of this team!");
            }
            else
            {
                sb.AppendLine(string.Join(Environment.NewLine, stories));
            }

            sb.AppendLine("Bugs:");
            if (bugs.Count < 1)
            {
                sb.AppendLine("No boards are part of this team!");
            }
            else
            {
                sb.AppendLine(string.Join(Environment.NewLine, bugs));
            }

            sb.AppendLine("Feedback:");
            if (feedbacks.Count < 1)
            {
                sb.AppendLine("No members are part of this team!");
            }
            else
            {
                sb.AppendLine(string.Join(Environment.NewLine, feedbacks));
            }

            return sb.ToString().Trim();
        }
    }
}