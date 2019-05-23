using System;
using System.Collections.Generic;

namespace DpHomework.Data
{
    public partial class Address
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int? IndividualId { get; set; }

        public virtual Individual Individual { get; set; }
    }
}