using Core.Validation;
using MediatR;

namespace Core.MediatR.Command;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
