using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DpHomework.Business;
using DpHomework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DpHomework.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Individual")]
    public class IndividualController : Controller
    {
        private IIndividualService _individualService;

        public IndividualController(IIndividualService individualService)
        {
            _individualService = individualService;
        }

        // GET: api/Individual
        [HttpGet]
        public async Task<ActionResult> GetList()
        {
//            return new string[] { "value1", "value2" };
            try
            {
                var individuals = await _individualService.GetIndividualsAddressesesAsync();
                return Json(new {status = HttpStatusCode.OK, data = individuals});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // GET: api/Individual/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Json(new { status = HttpStatusCode.OK, data = "foo"});
        }
        
        // POST: api/Individual
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]IEnumerable<IndividualViewModel> values)
        {
            if (values == null)
            {
                return Json(new {status = HttpStatusCode.BadRequest});
            }
            var result = await _individualService.CreateIndividualsAsync(values);
            if (!result)
            {
                return Json(new {status = HttpStatusCode.InternalServerError});
            }

            return Json(new {status = HttpStatusCode.Created});
        }

        // PUT: api/Individual/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]IEnumerable<IndividualViewModel> values)
        {
            throw new NotImplementedException();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
