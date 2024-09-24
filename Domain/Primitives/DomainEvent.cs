using MediatR;

namespace Domain.Primitives;

public record DomainEvent(Int32 Id) : INotification;