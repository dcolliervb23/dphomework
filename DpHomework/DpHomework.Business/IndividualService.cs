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

        public async Task<IndividualViewModel> GetIndividualById(int id)
        {
            var individualById = await _repository.GetIndividualById(id);
            return individualById.MapEntityToViewModel();
        }

        public async Task<IEnumerable<IndividualViewModel>> GetIndividualsAddressesesAsync()
        {
            var rawData = await _repository.GetIndividualsAddressesesAsync();
            var viewModel = new Dictionary<int,IndividualViewModel>();
            foreach (var data in rawData)
            {
                if (viewModel.ContainsKey(data.Id))
                {
                    viewModel[data.Id].Addresses.Add(data.MapEntityAddressToViewModel());
                }
                else
                {
                    viewModel.Add(data.Id, data.MapEntityToViewModel());
                }
            }

            return viewModel.Values.ToList();
        }

        public async Task<bool> CreateIndividualsAsync(IEnumerable<IndividualViewModel> models)
        {
            var entities = models.Select(m =>
            {
                if (m == null) throw new ArgumentNullException(nameof(m));
                return m.MapViewModelToEntityModel();
            }).ToList();
            var result = await _repository.CreateIndividualsAsync(entities);
            return result;
        }



    }
}
