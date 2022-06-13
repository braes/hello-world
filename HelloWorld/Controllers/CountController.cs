using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountController : ControllerBase
    {
        private readonly string _folder = "/V1";
        private readonly string _path = "/V1/num";
        private readonly ILogger<CountController> _logger;

        public CountController(ILogger<CountController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCount")]
        public CountResult Get()
        {
            return new CountResult
            {
                Count = ReadNumber(),
                Now = DateTime.UtcNow
            };
        }

        private int ReadNumber()
        {
            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }

            var number = System.IO.File.Exists(_path) ? int.Parse(System.IO.File.ReadAllText(_path)) : 0;

            number++;
            System.IO.File.WriteAllText(_path, number.ToString());

            return number;
        }
    }
}
