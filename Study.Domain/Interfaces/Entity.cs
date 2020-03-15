using System;

namespace Study.Domain.Interfaces
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
