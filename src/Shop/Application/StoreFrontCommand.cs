using System;
using Core.Messaging;
using LanguageExt.Common;
using Store.StoreFrontStore;

namespace Store.Application
{
    public record StoreFrontCommand(DateTime Timestamp) : Command(Timestamp), ICommand<StoreFrontState>;
}