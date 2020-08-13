using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Models.Contracts;
using Team17OOPTeamProject;
using Team17OOPTeamProject.Models;
using Team17OOPTeamProject.Models.Contracts;

namespace T17.Models.Models
{
    public class Board : IBoard
    {
        //Fields
        private string name;
        private List<string> history;
        private List<IWorkItem> workItems;

        //Constructor
        public Board(string name)
        {
            this.Name = name;
            this.history = new List<string>();
            this.WorkItems = new List<IWorkItem>();
        }

        //Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null.");
                }
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Name should be between 5 and 10 symbols.");
                }
                this.name = value;
            }
        }
        public List<string> History
        {
            get { return this.history; }
            set { this.history = value; }
        }

        public List<IWorkItem> WorkItems
        {
            get { return this.workItems; }
            set { this.workItems = value; }
        }
        //Methods   
        //public string AddBug(Bug bug)
        //{
        //    if (!bugs.Contains(bug))
        //    {
        //        bugs.Add(bug);
        //        this.history.Add($"Bug with title: {bug.Title} has been succesfully added!");
        //        return $"Bug with title: {bug.Title} has been succesfully added!";
        //    }
        //    else
        //    {
        //        return $"Bug with title: {bug.Title} already exist!";
        //    }
        //}
        //public void AddWorkItemToBoadrd(IWorkItem workItem)
        //{
        //    this.workItems.Add(workItem);
        //}
        //public string AddFeedback(Feedback feedback)
        //{
        //    if (!feedbacks.Contains(feedback))
        //    {
        //        feedbacks.Add(feedback);
        //        this.history.Add($"Feedback with title: {feedback.Title} has been succesfully added!");
        //        return $"Feedback with title: {feedback.Title} has been succesfully added!";
        //    }
        //    else
        //    {
        //        return $"Feedback with title: {feedback.Title} already exist!";
        //    }
        //}

        //public string AddStory(Story story)
        //{
        //    if (!stories.Contains(story))
        //    {
        //        stories.Add(story);
        //        this.history.Add($"Story with title: {story.Title} has been succesfully added!");
        //        return $"Story with title: {story.Title} has been succesfully added!";
        //    }
        //    else
        //    {
        //        return $"Story with title: {story.Title} already exist!";
        //    }
        //}

        //public string RemoveBug(Bug bug)
        //{
        //    if (bugs.Contains(bug))
        //    {
        //        bugs.Remove(bug);
        //        this.history.Add($"Bug with title: {bug.Title} has been succesfully removed!");
        //        return $"Bug with title: {bug.Title} has been succesfully removed!";
        //    }
        //    else
        //    {
        //        return $"Bug with title: {bug.Title} is not existing!";
        //    }
        //}

        //public string RemoveFeedback(Feedback feedback)
        //{
        //    if (feedbacks.Contains(feedback))
        //    {
        //        feedbacks.Remove(feedback);
        //        this.history.Add($"Feedback with title: {feedback.Title} has been succesfully removed!");
        //        return $"Feedback with title: {feedback.Title} has been succesfully removed!";
        //    }
        //    else
        //    {
        //        return $"There is no feedback with name {feedback.Title} on the list!";
        //    }
        //}

        //public string RemoveStory(Story story)
        //{
        //    if (stories.Contains(story))
        //    {
        //        stories.Remove(story);
        //        this.history.Add($"Story with title: {story.Title} has been succesfully removed!");
        //        return $"Story title: {story.Title} has been succesfully removed!";
        //    }
        //    else
        //    {
        //        return $"There is no story with name {story.Title} on the list!";
        //    }
        //}

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

        public string PrintDetails()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Board: {this.Name}");
            foreach (var item in this.WorkItems)
            {
                sb.AppendLine($"{item.PrintDetails()}");
            }
            return sb.ToString().Trim();
        }
    }
}
