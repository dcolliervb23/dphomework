using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DpHomework.Data
{
    public class AddressRepository : IAddressRepository
    {
        private DphomeworkDbContext _context;


        public AddressRepository(DphomeworkDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAddressAsync(Address address)
        {
            var addressParams = new SqlParameter[]
{
                        new SqlParameter()
                        {
                            ParameterName = "@individualId",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value = address.IndividualId
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

            return true;
        }
    }
}