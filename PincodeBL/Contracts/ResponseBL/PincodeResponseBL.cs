using PincodeBL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.Contracts.ResponseBL
{
    public class PincodeResponseBL : BaseResponse
    {
        public DataSet DataSet { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

    }

   

}
