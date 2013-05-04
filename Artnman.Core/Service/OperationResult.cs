namespace Artnman.Core.Service
{
    public class OperationResult
    {
        public enum ResultType
        {
            Success,
            Failure,
            Warning
        }

        public ResultType Type { get; set; }

        public string Message { get; set; }
    }
}
