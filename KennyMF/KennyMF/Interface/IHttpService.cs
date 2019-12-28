using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KennyMF.Interface
{
    public interface IHttpService
    {
        (bool success, string message) SetClientHeader(string key, string value);
        Task<TOut> GetAsync<TOut>(string url) where TOut : class;
        Task<TOut> PostAsync<TOut, Tin>(Tin requestObject, string url) where TOut : class;
        Task<TOut> PatchAsync<TOut, TIn>(TIn requestObject, string url) where TOut : class;
    }
}
