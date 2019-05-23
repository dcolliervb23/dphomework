using System.Linq;
using DpHomework.Data;
using DpHomework.Models;

namespace DpHomework.Business
{
    public static class MappingExtensions
    {
        public static Individual MapViewModelToEntityModel(this IndividualViewModel model)
        {
            return new Individual()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Address = model.Addresses.Select(x => new Address()
                {
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    City = x.City,
                    State = x.State,
                    Zip = x.Zip
                }).ToList()
            };
        }
        
    }
}