using System.Collections.Generic;
using System.Threading.Tasks;
using DpHomework.Data;

namespace DpHomework.Business
{
    public interface IIndividualService
    {
        Task<IEnumerable<Individual>> GetIndividualsAsync();
        Task<IEnumerable<IndividualsAndAddresses>> GetIndividualsAddressesesAsync();
    }
}