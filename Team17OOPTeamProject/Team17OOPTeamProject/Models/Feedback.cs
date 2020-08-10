using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject
{
    public class Feedback : WorkItem, IFeedback
    {
        //Fields
        private int rating;

        private FeedbackStatus feedbackStatus = FeedbackStatus.New;
        //Constructor
        public Feedback(string title, int rating)
             : base(title)
        {
            this.FeedbackStatus = feedbackStatus;
            this.Rating = rating;
        }

        public Feedback(string title, string description, int rating)
            : this(title, rating)
        {
            this.Description = description;
        }
        //Properties
        public int Rating
        {
            get => this.rating;
            set
            {
                if (value < 0)
                {
                    this.rating = 0;
                }
                this.rating = value;
            }
        }

        public FeedbackStatus FeedbackStatus { get; private set; }

        //Methods
        public void FeedBackStatusToUnscheduledScheduledDone()
        {
            if (FeedbackStatus == FeedbackStatus.New || FeedbackStatus == FeedbackStatus.Unscheduled
                || FeedbackStatus == FeedbackStatus.Scheduled)
            {
                this.history.Add($"Feedback status is changed from: {this.FeedbackStatus} to {++this.FeedbackStatus}");
            }
        }

        public void FeedBackStatusToScheduledUnscheduledNew()
        {
            if (FeedbackStatus == FeedbackStatus.Done || FeedbackStatus == FeedbackStatus.Unscheduled
                || FeedbackStatus == FeedbackStatus.Scheduled)
            {
                this.history.Add($"Changed status from {this.FeedbackStatus} to {--this.FeedbackStatus}");
            }
        }
    }
}
