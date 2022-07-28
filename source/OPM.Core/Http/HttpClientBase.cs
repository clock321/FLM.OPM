using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OPM.Core.Http
{
  public class HttpClientBase
  {
    protected  readonly HttpClient _httpClient = new HttpClient();

    protected AccessTokenSingleton _AccessToken;

    public HttpClientBase(AccessTokenSingleton AccessTokenModel)
    {
      _httpClient.BaseAddress = new Uri(AppConfigurations.SeverHost);
      _AccessToken = AccessTokenModel;
    }

    public async Task InvokeAsync(HttpMethod httpMethod, string methodName)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, methodName);
      httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.access_token);
      await ProcessResponseAsync(await _httpClient.SendAsync(httpRequestMessage));
    }

    public async Task InvokeAsync<TRequest>(HttpMethod httpMethod, string methodName, TRequest data)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, methodName) {
        Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
      };
      httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.access_token);
      await ProcessResponseAsync(await _httpClient.SendAsync(httpRequestMessage));
    }

    public async Task<TValue> InvokeAsync<TValue>(HttpMethod httpMethod, string methodName)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, methodName);
      httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.access_token);
      return await ProcessResponseAsync<TValue>(await _httpClient.SendAsync(httpRequestMessage));
    }

    public async Task<TValue> InvokeAsync<TRequest, TValue>(HttpMethod httpMethod, string methodName, TRequest data)
    {
      HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, methodName) {
        Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
      };
      httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _AccessToken.access_token);
      return await ProcessResponseAsync<TValue>(await _httpClient.SendAsync(httpRequestMessage));
    }

    public Task<TValue> GetAsync<TValue>(string methodName) => this.InvokeAsync<TValue>(HttpMethod.Get, methodName);

    public Task<TValue> GetAsync<TRequest, TValue>(string methodName, TRequest data) => this.InvokeAsync<TRequest, TValue>(HttpMethod.Get, methodName, data);

    public Task PostAsync(string methodName) => this.InvokeAsync(HttpMethod.Post, methodName);

    public Task PostAsync<TRequest>(string methodName, TRequest data) => this.InvokeAsync(HttpMethod.Post, methodName, data);

    public Task<TValue> PostAsync<TValue>(string methodName, object data) => this.InvokeAsync<object, TValue>(HttpMethod.Post, methodName, data);

    public Task<TValue> PostAsync<TRequest, TValue>(string methodName, TRequest data) => this.InvokeAsync<TRequest, TValue>(HttpMethod.Post, methodName, data);

    public Task PutAsync<TRequest>(string methodName, TRequest data) => this.InvokeAsync(HttpMethod.Put, methodName, data);

    public Task<TValue> PutAsync<TRequest, TValue>(string methodName, TRequest data) => this.InvokeAsync<TRequest, TValue>(HttpMethod.Put, methodName, data);

    public Task DeleteAsync(string methodName) => this.InvokeAsync(HttpMethod.Delete, methodName);

    public Task DeleteAsync<TRequest>(string methodName, TRequest data) => this.InvokeAsync(HttpMethod.Delete, methodName, data);

    public Task<TValue> DeleteAsync<TRequest, TValue>(string methodName, TRequest data) => this.InvokeAsync<TRequest, TValue>(HttpMethod.Delete, methodName, data);




    public virtual async Task<TValue> ProcessResponseAsync<TValue>(HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode && (int)response.StatusCode != 599)
      {
        throw new HttpRequestException("请求接口失败");
      }
      return await response.Content.ReadFromJsonAsync<TValue>();

    }

    public virtual async Task<string> ProcessResponseAsync(HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode && (int)response.StatusCode != 599)
      {
        throw new HttpRequestException("请求接口失败");
      }
      return  await response.Content.ReadAsStringAsync();
    }

  }
}
