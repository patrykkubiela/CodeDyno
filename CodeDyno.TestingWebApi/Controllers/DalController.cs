using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeDyno.DatabaseLocal;
using Microsoft.AspNetCore.Mvc;

namespace CodeDyno.TestingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DalController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public DalController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}