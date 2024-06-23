using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pincode.Model;


namespace Pincode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("userDetails")]
        public IActionResult GetUserDetailsFromModel() { 
            PincodeModel.PincodeOperations pincodeOperations = new PincodeModel.PincodeOperations();
            PincodeModel.PincodeModelResponse  pincodeModelResponse = new PincodeModel.PincodeModelResponse();
            pincodeModelResponse = pincodeOperations.getUserDetails();
            string JsonResponse = JsonConvert.SerializeObject(pincodeModelResponse, Formatting.Indented);
            JsonResult result = new JsonResult(JsonResponse);

            return Ok(result);
        }
        [HttpPost("state")]
        public IActionResult GetPincodeData([FromBody] Model.PincodeModel.PincodeProperties pincodeProperties) { 

            PincodeModel.PincodeOperations pincodeOperations = new PincodeModel.PincodeOperations();
            PincodeModel.PincodeModelResponse  pincodeModelResponse = new PincodeModel.PincodeModelResponse();
            pincodeModelResponse = pincodeOperations.getStatedata(pincodeProperties);

            string JsonResponse = JsonConvert.SerializeObject(pincodeModelResponse, Formatting.Indented);
            JsonResult result = new JsonResult(JsonResponse);

            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult UpdateDetails([FromBody] Model.PincodeModel.PincodeProperties pincodeProperties)
        {
            PincodeModel.PincodeOperations pincodeOperations = new PincodeModel.PincodeOperations();
            PincodeModel.PincodeModelResponse pincodeModelResponse = new PincodeModel.PincodeModelResponse();
            pincodeModelResponse = pincodeOperations.updateDataToBL(pincodeProperties);

            return Ok(pincodeModelResponse);
        }
        [HttpPost("Delete")]
        public IActionResult deleteDetails([FromBody] Model.PincodeModel.PincodeProperties pincodeProperties)
        {
            PincodeModel.PincodeOperations pincodeOperations = new PincodeModel.PincodeOperations();
            PincodeModel.PincodeModelResponse pincodeModelResponse = new PincodeModel.PincodeModelResponse();
            pincodeModelResponse = pincodeOperations.deleteDataBL(pincodeProperties);

            return Ok(pincodeModelResponse);
        }


        [HttpPost("insert")]
        public IActionResult InsertDetails([FromBody] Model.PincodeModel.PincodeProperties pincodeProperties)
        {
            PincodeModel.PincodeOperations pincodeOperations = new PincodeModel.PincodeOperations();
            PincodeModel.PincodeModelResponse pincodeModelResponse = new PincodeModel.PincodeModelResponse();
            pincodeModelResponse = pincodeOperations.insertDataToBL(pincodeProperties); 

            return Ok(pincodeModelResponse);


        }

    }
}
