using System.Collections.Generic;

namespace FormSender.Microservice
{
    public class OperationResult<TResult>
    {
        public bool Ok { get; set; } = true;
        public List<string> Errors { get; } = new List<string>();
        public TResult Body { get; set; }
    }
}
