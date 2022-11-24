using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace app01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [Route ("training")]
        public string Test()
        {
            return DateTime.Now.ToString();

        }
    }
}
