namespace ResFin.Domain.Abstractions;

public abstract class BaseEntity
    {
    protected BaseEntity ( Guid id ) => Id = id;


    public Guid Id { get; init; }
    }