using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DpHomework.Data
{
    public class IndividualRepository : IIndividualRepository
    {
        private DphomeworkDbContext _context;

        public IndividualRepository(DphomeworkDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Individual>> GetIndividualsAsync()
        {
            return _context.Individual.ToList();
        }

        public async Task<IEnumerable<IndividualsAndAddresses>> GetIndividualsAddressesesAsync()
        {
            return _context.IndividualsAndAddresseses.ToList();
        }

        public async Task<bool> CreateIndividuals(IEnumerable<Individual> individuals)
        {
            foreach (var individual in individuals)
            {
                var individualParams = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@firstName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.FirstName
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@middleName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.MiddleName
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@lastName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.LastName
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@email",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.Email
                    },
                };

                var result = _context.Database.ExecuteSqlCommand(
                        "[dbo].[InsertIndividual] @firstName, @middleName, @lastName, @email", individualParams);

                foreach (var address in individual.Address)
                {
                    var addressParamName = new SqlParameter[]
                    {
                        new SqlParameter()
                        {
                            ParameterName = "@addressLine1",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Direction = ParameterDirection.Input,
                            Value = address.AddressLine1
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@addressLine2",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Direction = ParameterDirection.Input,
                            Value = address.AddressLine2
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@city",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 100,
                            Direction = ParameterDirection.Input,
                            Value = address.City
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@state",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 35,
                            Direction = ParameterDirection.Input,
                            Value = address.State
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@zip",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Direction = ParameterDirection.Input,
                            Value = address.Zip
                        },

                    };

                }
            }

            return true;
        }
    }
}
