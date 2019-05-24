using System.Collections.Generic;
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

        public static IndividualViewModel MapEntityToViewModel(this IndividualsAndAddresses entity)
        {
            return new IndividualViewModel()
            {
                Email = entity.Email,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                Id = entity.Id,
                Addresses = new List<AddressViewModel>()
                {
                    entity.MapEntityAddressToViewModel()
                }
            };
        }

        public static AddressViewModel MapEntityAddressToViewModel(this IndividualsAndAddresses entity)
        {
            return new AddressViewModel()
            {
                Id = entity.AddressId ?? 0,
                AddressLine1 = entity.AddressLine1,
                AddressLine2 = entity.AddressLine2,
                City = entity.City,
                State = entity.State,
                Zip = entity.Zip,
                IndividualId = entity.Id
            };
        }
        
    }
}