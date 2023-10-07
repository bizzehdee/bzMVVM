using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bzMVVM
{
    public enum RequestType
    {
        Option,
        Get,
        Post,
        Put,
        Patch,
        Delete
    }

    public interface IApiProvider
    {
        Task<T> Request<T>(RequestType requestType, string url, IDictionary<string, string> body);
    }
}
