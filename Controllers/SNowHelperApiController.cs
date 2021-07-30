using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TrueDynamicWeb.Models;

namespace TrueDynamicWeb.Controllers
{
    public class SNowHelperApiController : ApiController
    {
        // GET: api/SNowHelperApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SNowHelperApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SNowHelperApi
        [ActionName("SnowCount")]
        public async Task<IHttpActionResult> PostCount(Url_config_tabl UrlConfigtabl)
        {
            var client = new RestClient(UrlConfigtabl.url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Basic YXRtb3Myc25vdzpGUiU4Sm13cFU5NTZw");
            IRestResponse response = await client.ExecuteAsync(request);
            return Ok(JObject.Parse(response.Content));
        }

        [ActionName("SnowContent")]
        public async Task<IHttpActionResult> PostContent(Url_config_tabl UrlConfigtabl,int limit,int offset)
        {
            string newUrl = UrlConfigtabl.url.Replace("stats", "table").Replace("&sysparm_count=true", "")+ "&sysparm_limit="+limit+"&sysparm_offset="+offset;
            return Ok(newUrl);
            var client = new RestClient(UrlConfigtabl.url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Basic YXRtb3Myc25vdzpGUiU4Sm13cFU5NTZw");
            IRestResponse response = await client.ExecuteAsync(request);
            return Ok(JObject.Parse(response.Content));
        }

        // PUT: api/SNowHelperApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SNowHelperApi/5
        public void Delete(int id)
        {
        }
    }
}
