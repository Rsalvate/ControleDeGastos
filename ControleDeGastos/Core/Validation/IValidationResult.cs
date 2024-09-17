namespace Core.Validation;
public interface IValidationResult
{
    public static readonly Error ValidationError = new("ValidationError", "A validation problem ocurred");

    Error[] Errors { get; }
}
