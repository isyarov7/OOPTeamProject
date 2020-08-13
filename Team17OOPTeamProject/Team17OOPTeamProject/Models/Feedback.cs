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

        private FeedbackStatus feedbackStatus;
        //Constructor
        public Feedback(string title,string description, int rating)
             : base(title, description)
        {
            this.feedbackStatus = FeedbackStatus.New;
            this.FeedbackStatus = feedbackStatus;
            this.Rating = rating;
        }
        //Properties
        public int Rating
        {
            get => this.rating;
            set
            {
                if (value < 0 || value > 5)
                {
                    throw new ArgumentException("Rating must be between 0 and 5.");
                }
                this.rating = value;
            }
        }

        public FeedbackStatus FeedbackStatus
        {
            get { return this.feedbackStatus; }
            set { this.feedbackStatus = value; }
        }
        public override string PrintDetails()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Type of WorkItem: Feedback");
            sb.AppendLine(base.PrintDetails());
            sb.AppendLine($"Feedback status: {this.FeedbackStatus}");
            sb.AppendLine($"Feedback rating: {this.Rating}");
            return sb.ToString();
        }
    }
}
