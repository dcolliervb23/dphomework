using DpHomework.Business;
using Microsoft.AspNetCore.Mvc;

namespace DpHomework.Web.Controllers
{
    public class AddressPageController : Controller
    {
        private IIndividualService _individualService;
        private IAddressService _addressService;

        public AddressPageController(IAddressService addressService, IIndividualService individualService)
        {
            _addressService = addressService;
            _individualService = individualService;
        }

        //        [HttpGet]
        public IActionResult AddAddress(int id)
        {
            var individual = _individualService.GetIndividualById(id).Result;
            return View(individual);
        }
    }
}