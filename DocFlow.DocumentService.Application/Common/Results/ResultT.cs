namespace DocFlow.DocumentService.Application.Common.Results
{
    public class Result<T> : Result
    {
        public T Value { get; }

        protected Result(
            T value,
            bool isSuccess,
            string error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(
                value,
                true,
                string.Empty);
        }

        public static new Result<T> Failure(string error)
        {
            return new Result<T>(
                default!,
                false,
                error);
        }
    }
}
