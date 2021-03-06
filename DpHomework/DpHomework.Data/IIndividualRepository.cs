﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DpHomework.Data
{
    public interface IIndividualRepository
    {
        Task<IEnumerable<Individual>> GetIndividualsAsync();
        Task<IEnumerable<IndividualsAndAddresses>> GetIndividualsAddressesesAsync();
        Task<bool> CreateIndividualsAsync(IEnumerable<Individual> individuals);
        Task<Individual> GetIndividualById(int id);
    }
}