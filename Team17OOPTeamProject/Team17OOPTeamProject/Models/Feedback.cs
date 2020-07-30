using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Abstract;
using Team17OOPTeamProject.Models.Contracts;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject
{
    public class Feedback : Abstract, IFeedback
    {
        //Fields
        private int rating;

        FeedbackStatus feedbackStatus;
        //Constructor
        public Feedback(string title, string description, int rating, FeedbackStatus feedbackStatus, List<string> comments, List<string> history)
            : base(title, description, comments, history)
        {
            this.Rating = rating;
            this.FeedbackStatus = feedbackStatus;
        }
        //Properties
        public int Rating
        {
            get => this.rating;
            set => this.rating = value;
        }

        public FeedbackStatus FeedbackStatus { get => this.feedbackStatus; set => feedbackStatus = value;}
    }
}
