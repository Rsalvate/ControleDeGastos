using Core.MediatR.Command;
using Core.Validation;

namespace Domain.Categories.Commands;
public sealed record CreateCategoryCommand(string Name, string Description) : ICommand;
