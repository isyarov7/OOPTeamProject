using System;
using System.Collections.Generic;
using System.Text;
using Team17OOPTeamProject.Models.Enums;

namespace Team17OOPTeamProject.Models.Contracts
{
    interface IAbstract
    {
        string Title { get; }

        string Description { get; }
    }
}
