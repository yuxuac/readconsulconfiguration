using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReadConsulConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsulController : ControllerBase
    {
        private readonly IConsulClient _consulClient;

        public ConsulController(IConsulClient consulClient)
        {
            this._consulClient = consulClient;
        }

        [HttpGet("")]
        public async Task<string> GetAsync([FromQuery]string key)
        {
            var val = string.Empty;
            if (!string.IsNullOrWhiteSpace(key))
            {
                var res = await _consulClient.KV.Get(key);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    val = System.Text.Encoding.UTF8.GetString(res.Response.Value);
                }
            }

            return $"{key}={val}";
        }
    }
}