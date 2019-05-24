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

        public async Task<Individual> GetIndividualById(int id)
        {
            return await _context.Individual.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateIndividualsAsync(IEnumerable<Individual> individuals)
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
                        Value = individual.FirstName ?? string.Empty
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@middleName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.MiddleName ?? string.Empty
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@lastName",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.LastName ?? String.Empty
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@email",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 100,
                        Direction = ParameterDirection.Input,
                        Value = individual.Email ?? string.Empty
                    },
                };

                var individualResult = await _context.Database.ExecuteSqlCommandAsync(
                        "[dbo].[InsertIndividual] @firstName, @middleName, @lastName, @email", individualParams);

                if (individual.Address != null)
                {
                    foreach (var address in individual.Address)
                    {
                        var addressParams = new SqlParameter[]
                        {
                            new SqlParameter()
                            {
                                ParameterName = "@individualId",
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input,
                                Value = individualResult
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@addressLine1",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 100,
                                Direction = ParameterDirection.Input,
                                Value = address.AddressLine1 ?? string.Empty
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@addressLine2",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 100,
                                Direction = ParameterDirection.Input,
                                Value = address.AddressLine2 ?? string.Empty
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@city",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 100,
                                Direction = ParameterDirection.Input,
                                Value = address.City ?? string.Empty
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@state",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 35,
                                Direction = ParameterDirection.Input,
                                Value = address.State ?? string.Empty
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@zip",
                                SqlDbType = SqlDbType.VarChar,
                                Size = 10,
                                Direction = ParameterDirection.Input,
                                Value = address.Zip ?? string.Empty
                            },

                        };

                        var addressResult = await _context.Database.ExecuteSqlCommandAsync(
                            "[dbo].[InsertAddress] @addressLine1, @addressLine2, @city, @state, @zip, @individualId",
                            addressParams);

                    }
                }
            }

            return true;
        }
    }
}
