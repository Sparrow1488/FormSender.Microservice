using System.Collections.Generic;

namespace FormSender.Microservice
{
    public class OperationResult<TResult> : OperationResult
    {
        public TResult Body { get; set; }
    }

    public class OperationResult
    {
        public bool Ok { get; set; } = true;
        public List<string> Errors { get; } = new List<string>();
        public List<string> Messages { get; } = new List<string>();
    }
}
