using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace IDO_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        [Route ("training")]
        public string test()
        {
            string a = "abd";
            Console.WriteLine(a);
            return a;
        }
    }
    }
