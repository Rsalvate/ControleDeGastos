using Core.MediatR.Command;
using Core.UoW;
using Core.Validation;
using Domain.Categories;
using Domain.Categories.Commands;
using Domain.Categories.Repository;

namespace Application.Categories.Commands.CreateCategory;
internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var existingCategory = await _categoryRepository.FindByName(request.Name);

        if (existingCategory != null) return Result.Failure(new Error(nameof(request.Name), $"An category with the name '{request.Name}' already exists."));

        var category = new Category(request.Name, request.Description);

        await _categoryRepository.AddAsync(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
