﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        public Task<ICommandResult> Handle(TCommand command);
    }
}
