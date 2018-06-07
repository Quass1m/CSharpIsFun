using System;

namespace CSharpIsFun.UsefulCode
{
    /// <summary>
    /// Railway oriented programming - returning Success/Fail status
    /// An alternative is to return a tuple with status and value
    /// </summary>
    /// <typeparam name="TSuccess"></typeparam>
    /// <see cref="https://www.youtube.com/watch?v=7yGtpyJxlEQ"/>
    /// <see cref="https://vimeo.com/113707214"/>
    public sealed class Result<TSuccess>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public TSuccess Value { get; }
        public string Error { get; }

        internal Result(bool isSuccess, TSuccess value, string error)
        {
            if (isSuccess && value == default)
                throw new ArgumentException(nameof(value));

            if (!isSuccess && string.IsNullOrWhiteSpace(error))
                throw new ArgumentException(nameof(error));

            IsSuccess = isSuccess;
            Value = value;
            Error = error;
        }

        public static Result<TSuccess> Success(TSuccess value)
            => new Result<TSuccess>(true, value, string.Empty);

        public static Result<TSuccess> Fail(string error)
            => new Result<TSuccess>(false, default, error);
    }
}