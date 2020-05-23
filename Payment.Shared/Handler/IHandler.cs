using Payment.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Shared.Handler
{
    public interface IHandler<T> where T :ICommands
    {
        IComandResult Handle(T command);
    }
}
