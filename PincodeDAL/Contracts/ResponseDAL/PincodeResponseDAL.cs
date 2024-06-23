using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeDAL.Contracts.ResponseDAL
{
    public class PincodeResponseDAL
    {
        public DataSet dataSet { get; set; }

        public string successMessage { get; set; }
        public string errorMessage { get; set; }

      
    }
}
