using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeDAL.Contracts.RequestDAL
{
    public class PincodeRequestDAL
    {
        public string? type { get; set; }
        public int? id { get; set; }

        

        public string? name { get; set; }
        public int? age { get; set; }
        public string? gender { get; set; }
        public string? hobby { get; set; }
        public int?  stateId{ get; set; }
        public int? districtId { get; set;}

        public int? cityId { get; set;}
        public int? pincode{ get; set;}
        public string? active {get; set;}
    
    }
}
