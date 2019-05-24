using System.Threading.Tasks;
using DpHomework.Data;
using DpHomework.Models;

namespace DpHomework.Business
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> CreateAddressAsync(AddressViewModel model)
        {
            return await _addressRepository.CreateAddressAsync(model.MapViewModelToEntityModel());
        }
    }
}