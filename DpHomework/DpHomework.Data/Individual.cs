using System;
using System.Collections.Generic;

namespace DpHomework.Data
{
    public partial class Individual
    {
        public Individual()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}