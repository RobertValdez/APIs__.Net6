using Microsoft.AspNetCore.Mvc;

namespace APIs_con_.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    { 
        private readonly ILogger<HelloWorldController> _logger;
        IHelloWorldService _helloWorldService;
        TareasContext _context;
        public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger, TareasContext tareasContext)
        {
            _helloWorldService = helloWorldService;
            _logger = logger;

            _context = tareasContext;
        } 

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogCritical("La  comida es lo que se tiene que comer.");
            return Ok(_helloWorldService.GetHellowWorld());
        }

        [HttpGet]
        [Route("createDB")]
        public IActionResult CreateDatabase()
        {
            _context.Database.EnsureCreated();
            return Ok();
        }
    }
}