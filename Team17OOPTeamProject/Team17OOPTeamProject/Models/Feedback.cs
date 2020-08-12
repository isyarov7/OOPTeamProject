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

        public FeedbackStatus FeedbackStatus { get; set; }
    }
}
