using System;
using System.Collections.Generic;
using CodeDyno.DatabaseLocal;
using CodeDyno.TestingWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeDyno.TestingWebApi.Controllers
{
    [Route("api/dal")]
    public class DalController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public DalController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        [Route("allMeasures")]
        public ActionResult<IEnumerable<Measure>> Get()
        {
            IEnumerable<Measure> measures;
            try
            {
                measures = _dataAccess.GetEntities<Measure>();
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok(measures);
        }

        [HttpPost]
        [Route("/measure")]
        public void Post([FromBody] Measure measure)
        {
            _dataAccess.Insert(measure);
        }

        [HttpPost]
        [Route("/measures")]
        public void Post([FromBody] IEnumerable<Measure> measures)
        {
            _dataAccess.Insert(measures);
        }
    }
}