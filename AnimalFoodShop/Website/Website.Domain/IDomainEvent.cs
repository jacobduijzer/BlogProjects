using System;
using MediatR;

namespace Website.Domain
{
    public interface IDomainEvent
        : INotification
    {
        DateTime OccurredOn { get; }
    }
}
