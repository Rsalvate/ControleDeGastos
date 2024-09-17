using Domain.Categories.Commands;
using FluentValidation;

namespace Domain.Categories.Validators;
internal class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(5).MaximumLength(30);
        RuleFor(x => x.Description).NotEmpty().MinimumLength(15).MaximumLength(100);
    }
}
