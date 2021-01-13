using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Commands
{
    public class CommandFailedResult : ICommandResult
    {
        public IEnumerable<string> Failures { get; }

        public bool IsSuccess { get; }
        public CommandFailedResult(IEnumerable<string> failures)
        {
            Failures = failures;
            IsSuccess = false;
        }
    }
}
