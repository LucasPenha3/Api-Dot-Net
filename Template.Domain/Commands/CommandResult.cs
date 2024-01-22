using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces.Commands;

namespace Template.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(){ }

        public CommandResult(bool success, string message = null) 
        {
            Success = success;
            Message = message;
        }
        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
