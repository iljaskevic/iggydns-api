using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace IggyDNSAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class UpdateController : Controller
    {
        private readonly ILogger<UpdateController> _logger;
        private readonly IConfiguration _config;

        public UpdateController(ILogger<UpdateController> logger, IConfiguration config)
        {
            this._logger = logger;
            this._config = config;
            //_logger.LogDebug($"Conn Str: {_config.GetConnectionString("IggyDNSStorage")}");
        }
        // GET api/values
        [HttpGet, HttpHead]
        public IActionResult Get()
        {
            StringValues apiHeaders;
            string token = null;
            if (Request.Headers.TryGetValue("X-Api-Key", out apiHeaders))
            {
                token = apiHeaders.ElementAt<string>(0);
                // _logger.LogDebug($"Found 'api-key' header: {token}");
            }
            else
            {
                // _logger.LogError($"No api-key header");
                return Unauthorized();
            }
            return Ok($"API Key: {token}");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [HttpHead("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
