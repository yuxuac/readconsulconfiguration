using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ReadConsulConfiguration.Configuration;

namespace ReadConsulConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Consul2Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DemoAppSettings _options;
        private readonly DemoAppSettings _optionsSnapshot;

        public Consul2Controller(IConfiguration configuration, IOptions<DemoAppSettings> options, IOptionsSnapshot<DemoAppSettings> optionsSnapshot)
        {
            this._configuration = configuration;
            this._options = options.Value;
            this._optionsSnapshot = optionsSnapshot.Value;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllKeys()
        {
            return new string[] { _configuration["DemoAppSettings:Key1"], _options.Key1, _optionsSnapshot.Key1 };
        }

        [HttpGet("keys/{key}")]
        public ActionResult<string> GetSpecificKey(string key)
        {
            return $"{key} = {_configuration["DemoAppSettings:" + key]}";
        }
    }
}