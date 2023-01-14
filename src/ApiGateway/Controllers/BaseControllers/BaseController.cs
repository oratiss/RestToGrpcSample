using ApiGateway.Configurations.GrpcServiceConfigurations;
using Grpc.Net.Client;
using HelloGrpcService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ApiGateway.Controllers.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Greeter.GreeterClient Client;
        public BaseController(IOptions<GrpcServiceConfiguration> options)
        {
        }
    }
}
