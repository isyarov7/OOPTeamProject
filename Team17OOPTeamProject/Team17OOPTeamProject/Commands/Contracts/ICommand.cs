using System;
using System.Collections.Generic;
using System.Text;

namespace T17.Models.Commands.Contracts
{
    public interface ICommand
    {
        string Execute();
    }
}
