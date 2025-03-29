using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UluhEvidencija.Contract.Models.Response
{
    public enum ResponseStatus
    {
        Success,
        Warning,
        BadRequest,
        NotFound,
        Conflict,
        Error,
        Unauthorized
    }
    public class Response<T>
    {
        public IEnumerable<string> Messages => MessageList;
        public ResponseStatus Status { get; private init; }
        public T Data { get; set; } = default;
        internal List<string> MessageList { get; set; } = new List<string>();
        public bool IsSuccess => Status == ResponseStatus.Success || Status == ResponseStatus.Warning;

        public Response()
        {
        }
        internal Response(ResponseStatus status)
        {
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
        }
        internal Response(ResponseStatus status, string message)
        {
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
            MessageList = new List<string> { message };
        }
        internal Response(ResponseStatus status, IEnumerable<string> messages)
        {
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
            MessageList = messages.ToList();
        }
        internal Response(ResponseStatus status, T data)
        {
            if (status != ResponseStatus.Success && status != ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
            Data = data;
        }
        internal Response(ResponseStatus status, T data, string message)
        {
            if (status != ResponseStatus.Success && status != ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
            Data = data;
            MessageList = new List<string> { message };
        }
        internal Response(ResponseStatus status, T data, IEnumerable<string> messages)
        {
            if (status != ResponseStatus.Success && status != ResponseStatus.Warning)
            {
                throw new ArgumentException(nameof(status));
            }

            Status = status;
            Data = data;
            MessageList = messages.ToList();
        }

        public static Response<T> Success(T data) =>
            new(ResponseStatus.Success, data);
        public static Response<T> Error =>
            new(ResponseStatus.Error);

        public static implicit operator Response<T>(T data) =>
            Success(data);
        public static implicit operator Response<T>(ResponseError error) =>
            new()
            {
                MessageList = error.MessageList,
                Status = error.Status
            };
    }
    public static partial class Response
    {
        #region Success
        public static Response<T> Success<T>(T data) =>
            new(ResponseStatus.Success, data);
        public static Response<T> Success<T>(T data, string message) =>
            new(ResponseStatus.Success, data, message);
        public static Response<T> Success<T>(T data, IEnumerable<string> messages) =>
            new(ResponseStatus.Success, data, messages);
        public static Response<T> Success<T>(T data, params string[] messages) =>
            new(ResponseStatus.Success, data, messages);
        #endregion Success

        #region Warning
        public static Response<T> Warning<T>(T data) =>
            new(ResponseStatus.Warning, data);
        public static Response<T> Warning<T>(T data, string message) =>
            new(ResponseStatus.Warning, data, message);
        public static Response<T> Warning<T>(T data, IEnumerable<string> messages) =>
            new(ResponseStatus.Warning, data, messages);
        public static Response<T> Warning<T>(T data, params string[] messages) =>
            new(ResponseStatus.Warning, data, messages);
        #endregion Warning

        #region BadRequest
        public static Response<T> BadRequest<T>() =>
            new(ResponseStatus.BadRequest);
        public static Response<T> BadRequest<T>(string message) =>
            new(ResponseStatus.BadRequest, message);
        public static Response<T> BadRequest<T>(IEnumerable<string> messages) =>
            new(ResponseStatus.BadRequest, messages);
        public static Response<T> BadRequest<T>(params string[] messages) =>
            new(ResponseStatus.BadRequest, messages);
        public static ResponseError BadRequest() =>
            new(ResponseStatus.BadRequest);
        public static ResponseError BadRequest(string message) =>
            new(ResponseStatus.BadRequest, message);
        public static ResponseError BadRequest(IEnumerable<string> messages) =>
            new(ResponseStatus.BadRequest, messages);
        public static ResponseError BadRequest(params string[] messages) =>
            new(ResponseStatus.BadRequest, messages);
        #endregion BadRequest    

        #region NotFound
        public static Response<T> NotFound<T>() =>
             new(ResponseStatus.NotFound);
        public static Response<T> NotFound<T>(string message) =>
            new(ResponseStatus.NotFound, message);
        public static Response<T> NotFound<T>(IEnumerable<string> messages) =>
            new(ResponseStatus.NotFound, messages);
        public static Response<T> NotFound<T>(params string[] messages) =>
            new(ResponseStatus.NotFound, messages);
        public static ResponseError NotFound() =>
            new(ResponseStatus.NotFound);
        public static ResponseError NotFound(string message) =>
            new(ResponseStatus.NotFound, message);
        public static ResponseError NotFound(IEnumerable<string> messages) =>
            new(ResponseStatus.NotFound, messages);
        public static ResponseError NotFound(params string[] messages) =>
            new(ResponseStatus.NotFound, messages);

        #endregion NotFound

        #region Conflict
        public static Response<T> Conflict<T>() =>
            new(ResponseStatus.Conflict);
        public static Response<T> Conflict<T>(string message) =>
            new(ResponseStatus.Conflict, message);
        public static Response<T> Conflict<T>(IEnumerable<string> messages) =>
            new(ResponseStatus.Conflict, messages);
        public static Response<T> Conflict<T>(params string[] messages) =>
            new(ResponseStatus.Conflict, messages);
        public static ResponseError Conflict() =>
            new(ResponseStatus.Conflict);
        public static ResponseError Conflict(string message) =>
            new(ResponseStatus.Conflict, message);
        public static ResponseError Conflict(IEnumerable<string> messages) =>
            new(ResponseStatus.Conflict, messages);
        public static ResponseError Conflict(params string[] messages) =>
            new(ResponseStatus.Conflict, messages);
        #endregion Conflict

        #region Error
        public static Response<T> Error<T>() =>
            new(ResponseStatus.Error);
        public static Response<T> Error<T>(string message) =>
            new(ResponseStatus.Error, message);
        public static Response<T> Error<T>(IEnumerable<string> messages) =>
            new(ResponseStatus.Error, messages);
        public static Response<T> Error<T>(params string[] messages) =>
            new(ResponseStatus.Error, messages);
        public static ResponseError Error() =>
            new(ResponseStatus.Error);
        public static ResponseError Error(string message) =>
            new(ResponseStatus.Error, message);
        public static ResponseError Error(IEnumerable<string> messages) =>
            new(ResponseStatus.Error, messages);
        public static ResponseError Error(params string[] messages) =>
            new(ResponseStatus.Error, messages);
        #endregion Error

        #region Unauthorized
        public static Response<T> Unauthorized<T>() =>
            new(ResponseStatus.Unauthorized);
        public static Response<T> Unauthorized<T>(string message) =>
            new(ResponseStatus.Unauthorized, message);
        public static Response<T> Unauthorized<T>(IEnumerable<string> messages) =>
            new(ResponseStatus.Unauthorized, messages);
        public static Response<T> Unauthorized<T>(params string[] messages) =>
            new(ResponseStatus.Unauthorized, messages);
        public static ResponseError Unauthorized() =>
            new(ResponseStatus.Unauthorized);
        public static ResponseError Unauthorized(string message) =>
            new(ResponseStatus.Unauthorized, message);
        public static ResponseError Unauthorized(IEnumerable<string> messages) =>
            new(ResponseStatus.Unauthorized, messages);
        public static ResponseError Unauthorized(params string[] messages) =>
            new(ResponseStatus.Unauthorized, messages);

        #endregion Unauthorized

        #region Try

        public static Action<Exception>? DefaultCatchAction;

        private static Response<T> Catch<T>(Exception e, Action<Exception>? catchAction, string error)
        {
            catchAction = catchAction ?? DefaultCatchAction;
            catchAction?.Invoke(e);

            return new(ResponseStatus.Error, $"{error};{e.Message}");
        }
        public static Response<T> Try<T>(Func<T> tryFunction, Action<Exception>? catchAction = null, string error = "caught_exception")
        {
            try
            {
                var data = tryFunction();
                //ovde ispititali da li je null ????
                return new(ResponseStatus.Success, data);
            }
            catch (Exception e)
            {
                return Catch<T>(e, catchAction, error);
            }
        }

        public static Response<T> Try<T>(Func<Response<T>> tryFunction, Action<Exception>? catchAction = null, string error = "caught_exception")
        {
            try
            {
                return tryFunction();
            }
            catch (Exception e)
            {
                return Catch<T>(e, catchAction, error);
            }
        }
        public static async Task<Response<T>> Try<T>(Func<Task<T>> tryFunction, Action<Exception>? catchAction = null, string error = "caught_exception")
        {
            try
            {
                var data = await tryFunction();
                return new(ResponseStatus.Success, data);
            }
            catch (Exception e)
            {
                return Catch<T>(e, catchAction, error);
            }
        }

        public static async Task<Response<T>> Try<T>(Func<Task<Response<T>>> tryFunction, Action<Exception>? catchAction = null, string error = "caught_exception")
        {
            try
            {
                return await tryFunction();
            }
            catch (Exception e)
            {
                return Catch<T>(e, catchAction, error);
            }
        }

        #endregion Try

        #region Zip

        public static Response<(T1, T2)> Zip<T1, T2>(
            Response<T1> response1,
            Response<T2> response2
        )
        {
            var statuses = new[]
            {
            response1.Status,
            response2.Status
        };

            var status = statuses.Max();
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                var data = (response1.Data!, response2.Data!);
                return new(status, data);
            }
            else
            {
                return new(status);
            }
        }

        public static async Task<Response<(T1, T2)>> Zip<T1, T2>(
            Task<Response<T1>> response1,
            Task<Response<T2>> response2
        )
        {
            await Task.WhenAll(response1, response2);

            return Zip(
                await response1,
                await response2
            );
        }

        public static Response<(T1, T2, T3)> Zip<T1, T2, T3>(
            Response<T1> response1,
            Response<T2> response2,
            Response<T3> response3
        )
        {
            var statuses = new[]
            {
            response1.Status,
            response2.Status,
            response3.Status
        };

            var status = statuses.Max();
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                var data = (response1.Data!, response2.Data!, response3.Data!);
                return new(status, data);
            }
            else
            {
                return new(status);
            }
        }

        public static async Task<Response<(T1, T2, T3)>> Zip<T1, T2, T3>(
            Task<Response<T1>> response1,
            Task<Response<T2>> response2,
            Task<Response<T3>> response3
        )
        {
            await Task.WhenAll(response1, response2, response3);

            return Zip(
                await response1,
                await response2,
                await response3
            );
        }

        public static Response<(T1, T2, T3, T4)> Zip<T1, T2, T3, T4>(
            Response<T1> response1,
            Response<T2> response2,
            Response<T3> response3,
            Response<T4> response4
        )
        {
            var statuses = new[]
            {
            response1.Status,
            response2.Status,
            response3.Status,
            response4.Status
        };

            var status = statuses.Max();
            if (status == ResponseStatus.Success || status == ResponseStatus.Warning)
            {
                var data = (response1.Data!, response2.Data!, response3.Data!, response4.Data!);
                return new(status, data);
            }
            else
            {
                return new(status);
            }
        }

        public static async Task<Response<(T1, T2, T3, T4)>> Zip<T1, T2, T3, T4>(
            Task<Response<T1>> response1,
            Task<Response<T2>> response2,
            Task<Response<T3>> response3,
            Task<Response<T4>> response4
        )
        {
            await Task.WhenAll(response1, response2, response3, response4);

            return Zip(
                await response1,
                await response2,
                await response3,
                await response4
            );
        }

        #endregion Zip
    }
}
