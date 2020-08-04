using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace T17.Models.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string commandLine);
    }
}
