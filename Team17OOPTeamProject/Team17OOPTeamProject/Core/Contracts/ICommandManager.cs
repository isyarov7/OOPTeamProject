using System;
using System.Collections.Generic;
using System.Text;
using T17.Models.Commands.Contracts;

namespace T17.Models.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string commandLine);
    }
}
