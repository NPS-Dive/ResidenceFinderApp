

namespace ResFin.Application.Abstractions.Messeging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }