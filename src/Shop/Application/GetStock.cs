using System;
using Core.Messaging;
using Store.StoreFrontStore;

namespace Store.Application
{
    public record GetStock : Command, ICommand<StoreFrontState>
    {
        public Guid OwnerId { get; set; }
    }
}