using AutoMapper;
using Core.Validation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Base;

public abstract class ApiControllerBase : Controller
{
    private IMapper _mapper;
    private IMediator _mediator;

    protected IMapper Mapper => this._mapper ?? (this._mapper = this.HttpContext.RequestServices.GetRequiredService<IMapper>());
    protected IMediator Mediator => this._mediator ?? (this._mediator = this.HttpContext.RequestServices.GetRequiredService<IMediator>());

    protected IActionResult HandleFailure(Result result) =>

        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult => BadRequest(
                                                    CreateProblemDetails(
                                                        "Validation Error",
                                                        StatusCodes.Status400BadRequest,
                                                        result.Error, validationResult.Errors)),
            _ => BadRequest(CreateProblemDetails(
                            "Bad Request",
                             StatusCodes.Status400BadRequest,
                             result.Error)),
        };


    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}
