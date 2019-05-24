using System.Collections.Generic;
using System.Threading.Tasks;
using DpHomework.Data;
using DpHomework.Models;

namespace DpHomework.Business
{
    public interface IIndividualService
    {
        Task<IEnumerable<Individual>> GetIndividualsAsync();
        Task<IEnumerable<IndividualViewModel>> GetIndividualsAddressesesAsync();
        Task<bool> CreateIndividualsAsync(IEnumerable<IndividualViewModel> models);
        Task<IndividualViewModel> GetIndividualById(int id);
    }
}