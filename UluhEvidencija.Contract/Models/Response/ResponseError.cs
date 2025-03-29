using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models.Response
{
    public class ResponseError
    {
        public IEnumerable<string> Messages => MessageList;
        internal List<string> MessageList { get; set; } = new List<string>();
        public ResponseStatus Status { get; private init; }
        internal ResponseError(ResponseStatus status)
        {
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
        }
        internal ResponseError(ResponseStatus status, string message)
        {
            Status = status;
            MessageList = new List<string> { message };
        }
        internal ResponseError(ResponseStatus status, IEnumerable<string> messages)
        {
            Status = status;
            MessageList = messages.ToList();
        }
    }
}
