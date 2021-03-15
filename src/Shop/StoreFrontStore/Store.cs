using System;
using Core.Messaging;

namespace Store.StoreFrontStore
{
    public record ItemCommand(DateTime Timestamp) : Message(Timestamp);

    public class Store
    {
        
    }
}