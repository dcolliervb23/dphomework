using System.Threading.Tasks;
using DpHomework.Models;

namespace DpHomework.Business
{
    public interface IAddressService
    {
        Task<bool> CreateAddressAsync(AddressViewModel model);
    }
}