using System.Threading.Tasks;

namespace DpHomework.Data
{
    public interface IAddressRepository
    {
        Task<bool> CreateAddressAsync(Address address);
    }
}