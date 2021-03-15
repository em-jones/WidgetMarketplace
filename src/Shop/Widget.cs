using System;
using Core.Domain.Types;
using Store.StoreFrontStore;

namespace Store
{
    /// <summary>
    /// ***Requirement***
    /// </summary>
    public record Widget(String Description, Amount Amount) : Item(Description, Amount, ItemType.Widget);
}