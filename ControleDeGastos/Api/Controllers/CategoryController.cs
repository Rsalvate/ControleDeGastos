using Api.Controllers.Base;
using Api.ViewModels.Requests.Category;
using Domain.Categories.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/category")]
public class CategoryController : ApiControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new CreateCategoryCommand(request.Name, request.Description), cancellationToken);

        return result.IsSuccess ? Ok() : HandleFailure(result);
    }

}
