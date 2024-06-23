using System;
using System.Collections.Generic;

namespace PincodeDAL.Entity.PincodeEntity
{
    public partial class MyTable
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Hobby { get; set; }
        public int Id { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? Pincode { get; set; }
        public string? Active { get; set; }
    }
}
