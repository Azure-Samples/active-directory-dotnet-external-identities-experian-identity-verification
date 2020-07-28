namespace CrossCoreExtIdApi.Controllers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Models;
    using Models.Configuration;
    using Newtonsoft.Json;
    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class CrossCoreExtIdController : ControllerBase
    {
        private readonly IOptions<CrossCoreConfig> _config;
        private readonly ILogger<CrossCoreExtIdController> _logger;
        private readonly IService _service;

        public CrossCoreExtIdController(
            ILogger<CrossCoreExtIdController> logger,
            IOptions<CrossCoreConfig> config,
            IService crossCoreService
        )
        {
            _logger = logger;
            _config = config;
            _service = crossCoreService;
        }

        [BasicAuth]
        [HttpPost]
        [Route("CrossCore")]
        public async Task<IActionResult> CrossCore( /*[FromBody] CrossCoreB2CInput input*/)
        {
            CrossCoreExtIdInput input;

            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                input = JsonConvert.DeserializeObject<CrossCoreExtIdInput>(body);
            }

            input.CorrelationId = Guid.NewGuid().ToString();
            input.Email = null;

            var output = await _service.ServiceCall(input);

            if (!output.Equals("CONTINUE") && !output.Equals("REFER"))
            {
                return BadRequest(new ExtIdResponse("EXPECTIDERR001", "Your identity could not be verified based on the details you provided.",
                    HttpStatusCode.BadRequest, "ValidationError"));
            }

            var response = new CrossCoreOutput {Decision = output};

            return Ok(response);
        }
    }
}