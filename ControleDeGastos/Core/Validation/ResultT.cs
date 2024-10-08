﻿namespace Core.Validation;
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSucces, Error error)
        : base(isSucces, error) => _value = value;

    public TValue? Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result cannot be accessed.");
        
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
