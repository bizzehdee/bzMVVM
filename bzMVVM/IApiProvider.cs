using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bzMVVM
{
    public interface IApiProvider
    {
        Task<T> Get<T>(string url, IDictionary<string, string> queryString);
    }
}
