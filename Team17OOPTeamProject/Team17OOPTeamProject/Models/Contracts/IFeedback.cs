using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IFeedback : IWorkItem
    {
        public FeedbackStatus FeedbackStatus { get; set; }
        public int Rating { get; }
    }
}
