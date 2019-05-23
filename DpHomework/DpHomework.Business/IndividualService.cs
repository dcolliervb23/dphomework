using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DpHomework.Data;
using DpHomework.Models;

namespace DpHomework.Business
{
    public class IndividualService : IIndividualService
    {
        private IIndividualRepository _repository;

        public IndividualService(IIndividualRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Individual>> GetIndividualsAsync()
        {
            return await _repository.GetIndividualsAsync();
        }

        public async Task<IEnumerable<IndividualsAndAddresses>> GetIndividualsAddressesesAsync()
        {
            return await _repository.GetIndividualsAddressesesAsync();
        }

        public async Task<bool> CreateIndividualsAsync(IEnumerable<IndividualViewModel> models)
        {
            var entities = models.Select(m =>
            {
                if (m == null) throw new ArgumentNullException(nameof(m));
                return m.MapViewModelToEntityModel();
            });
            var result = await _repository.CreateIndividualsAsync(entities);
            return result;
        }



    }
}
