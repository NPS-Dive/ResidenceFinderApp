namespace ResFin.Application.Abstractions.Messeging;

public interface ICommand : IRequest<Result>, IBaseCommand
    {

    }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }