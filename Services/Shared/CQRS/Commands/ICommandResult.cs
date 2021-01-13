using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Commands
{
    public interface ICommandResult
    {
        public bool IsSuccess { get; }
    }
}
