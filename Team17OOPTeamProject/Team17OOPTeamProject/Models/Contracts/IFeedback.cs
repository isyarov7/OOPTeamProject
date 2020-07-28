using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    public interface IFeedback
    {
        int Rating { get; }
        FeedbackStatus FeedbackStatus { get; }
    }
}
