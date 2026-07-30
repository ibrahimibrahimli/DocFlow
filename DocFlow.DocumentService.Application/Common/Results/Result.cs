namespace DocFlow.DocumentService.Application.Common.Results
{
    public class Result
    {
        public bool IsSucces { get; }
        public bool IsFailure => !IsSucces;
        public string Error { get; }

        protected Result(bool isSuccess, string error)
        {
            IsSucces = isSuccess;
            Error = error;
        }

        public static Result Success()
        {
            return new Result(true, string.Empty);
        }

        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }
}
