using KennyMF.Interface;
using KennyMF.Pages;
using KennyMF.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KennyMF.Services
{
    public class HttpService : IHttpService
    {
        private static HttpClient _client;
        public HttpService()
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", string.Empty);
                _client.DefaultRequestHeaders.Add("X-Tenant-Id", "0");

            }
            if((Application.Current as App).Token!=string.Empty && 
                _client.DefaultRequestHeaders.GetValues("Authorization").ToString()
                !="Bearer "+(Application.Current as App).Token)
            {
                SetClientHeader("Authorization", "Bearer " + (Application.Current as App).Token);
            }
        }
        public async Task<TOut> GetAsync<TOut>(string url) where TOut : class
        {
            if (!ConnectionService.HasInternetAccess())
            {
                MessagingCenter.Send<HttpService>(this, "NoNETWORKACCESS");
                throw new TaskCanceledException();
            }
            TOut result = null;
            try
            {
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    (Application.Current as App).MainPage = new NavigationPage(new LoginPage());
                    MessagingCenter.Send<HttpService>(this, "SESSIONEXPIRED");
                    return null;
                }
                result = await HandleResponse<TOut>(response);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            return result;
        }

        public async Task<TOut> PostAsync<TOut, Tin>(Tin requestObject, string url) where TOut : class
        {
            if (!ConnectionService.HasInternetAccess())
            {
                MessagingCenter.Send<HttpService>(this, "NONETWORKACCESS");
                throw new TaskCanceledException();
            }
            TOut result = null;
            try
            {
                var x = new JsonContent(requestObject);
                var response = await _client.PostAsync(url, new JsonContent(requestObject));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    (Application.Current as App).MainPage = new NavigationPage(new LoginPage());
                    MessagingCenter.Send<HttpService>(this, "SESSIONEXPIRED");
                    return null;
                }
                return await HandleResponse<TOut>(response);
            }
            catch (Exception e)
            {

                Debug.WriteLine(e);
            }
            return result;
        }

        public Task<TOut> PatchAsync<TOut, TIn>(TIn requestObject, string url) where TOut : class
        {
            throw new NotImplementedException();
        }

       

        public (bool success, string message) SetClientHeader(string key, string value)
        {
            throw new NotImplementedException();
        }

        private async Task<TOut> HandleResponse<TOut>(HttpResponseMessage response) where TOut : class
        {
            TOut res = null;
            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    res = JsonConvert.DeserializeObject<TOut>(x.Result);
                });
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            return res;
        }
    }
}
