using Payment.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Commands
{
    public class CommandResult: IComandResult
    {
        public CommandResult()
        {

        }
        public CommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
}
