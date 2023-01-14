using ApiGateway.Configurations.GrpcServiceConfigurations;
using ApiGateway.Controllers.BaseControllers;
using Grpc.Net.Client;
using HelloGrpcService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : BaseController
    {

        public HelloController(IOptions<GrpcServiceConfiguration> options) : base(options)
        {
            var channel = GrpcChannel.ForAddress(options.Value.HelloServiceUrl);
            Client = new Greeter.GreeterClient(channel);
        }


        // GET: api/<HelloController>
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string name)
        {

            var reply = await Client.SayHelloAsync(new HelloRequest { Name = $"{name}" });
            Console.WriteLine("from server: " + reply);
            return Ok(reply);
        }

    }
}
