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
        //Constructor
        public Feedback(string title,string description, int rating)
             : base(title, description)
        {
            this.FeedbackStatus = FeedbackStatus.New;
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
        public FeedbackStatus FeedbackStatus { get; set; }
        //Methods
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
