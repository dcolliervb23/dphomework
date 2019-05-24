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
    [Route("api/Address")]
    public class AddressController : Controller
    {
        private IAddressService _addressService;
        private IIndividualService _individualService;

        public AddressController(IAddressService addressService, IIndividualService individualService)
        {
            _addressService = addressService;
            _individualService = individualService;
        }

        // GET: api/Address
        [HttpGet]
        public IEnumerable<string> GetList()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Address/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Address
        [HttpPost]
        public async Task<ActionResult> Post(AddressViewModel model)
        {
            try
            {
                var result =  await _addressService.CreateAddressAsync(model);
                return Json(new { status = HttpStatusCode.Created });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // PUT: api/Address/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
