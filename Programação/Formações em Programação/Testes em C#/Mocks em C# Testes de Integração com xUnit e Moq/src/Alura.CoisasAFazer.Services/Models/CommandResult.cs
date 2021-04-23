using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.CoisasAFazer.Services.Models
{
    public class CommandResult
    {
        public CommandResult(bool success)
        {
            IsSuccess = success;
        }
        public bool IsSuccess { get; set; }
    }
}
