using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Volo.Abp;

namespace OPM.Core.Http
{
  public class AbpHttpClientBase: HttpClientBase
  {
    public AbpHttpClientBase(AccessTokenSingleton AccessTokenModel) : base(AccessTokenModel) { }


    public override async Task<TValue> ProcessResponseAsync<TValue>(HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode && (int)response.StatusCode != 599)
      {
        throw new HttpRequestException("请求接口失败");
      }
      var responseData = await response.Content.ReadFromJsonAsync<AbpApiResult<TValue>>(new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });
      if (!responseData.success)
      {
        throw new UserFriendlyException(responseData.error.message);
      }
      return responseData.result;

    }

    public override async Task<string> ProcessResponseAsync(HttpResponseMessage response)
    {
      if (!response.IsSuccessStatusCode && (int)response.StatusCode != 599)
      {
        throw new HttpRequestException("请求接口失败");
      }
      var responseData = await response.Content.ReadFromJsonAsync<AbpApiResult<dynamic>>(new System.Text.Json.JsonSerializerOptions() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull, PropertyNameCaseInsensitive = true });
      if (!responseData.success)
      {
        throw new UserFriendlyException(responseData.error.message);
      }
      return responseData.result;
    }
  }
}
