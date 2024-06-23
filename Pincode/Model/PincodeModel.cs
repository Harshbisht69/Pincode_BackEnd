using PincodeBL.Contracts.RequestBL;
using PincodeBL.Contracts.ResponseBL;
using PincodeBL.Shared;
using PincodeDAL.Contracts.ResponseDAL;
using System.Data;

namespace Pincode.Model
{
    public class PincodeModel
    {
        public class PincodeOperations
        {
            public PincodeModelResponse updateDataToBL(PincodeProperties pincodeProperties)
            {
                PincodeRequestBL pincodeRequestBL = new PincodeRequestBL();
                pincodeRequestBL.name = pincodeProperties.name;
                pincodeRequestBL.age = pincodeProperties.age;
                pincodeRequestBL.gender = pincodeProperties.gender;
                pincodeRequestBL.hobby = pincodeProperties.hobby;
                pincodeRequestBL.stateId = pincodeProperties.stateId;
                pincodeRequestBL.districtId = pincodeProperties.districtId;
                pincodeRequestBL.cityId = pincodeProperties.cityId;
                pincodeRequestBL.pincode = pincodeProperties.pincode;
                pincodeRequestBL.id = pincodeProperties.id;
                pincodeRequestBL.active = pincodeProperties.active;

                pincodeRequestBL.BehaviourClass = "PincodeBL.BehaviourBL.PincodeBehaviourBL";
                pincodeRequestBL.BehaviourAction = "update_pincode_data";

                ServiceLocator serviceLocatorObj = new ServiceLocator();
                BaseResponse baseResponseObj = new BaseResponse();
                baseResponseObj = serviceLocatorObj.Execute(pincodeRequestBL);

                PincodeResponseBL pincodeResponseBL = (PincodeResponseBL)baseResponseObj;
                PincodeModelResponse pincodeModelResponse = new PincodeModelResponse();

                pincodeModelResponse.successMessage = pincodeResponseBL.SuccessMessage;
                pincodeModelResponse.errorMessage = pincodeResponseBL.ErrorMessage;

                return pincodeModelResponse;
            }
            public PincodeModelResponse deleteDataBL(PincodeProperties pincodeProperties)
            {
                PincodeRequestBL pincodeRequestBL = new PincodeRequestBL();
                
                pincodeRequestBL.active = pincodeProperties.active;
                pincodeRequestBL.id = pincodeProperties.id;

                pincodeRequestBL.BehaviourClass = "PincodeBL.BehaviourBL.PincodeBehaviourBL";
                pincodeRequestBL.BehaviourAction = "delete_pincode_data";

                ServiceLocator serviceLocatorObj = new ServiceLocator();
                BaseResponse baseResponseObj = new BaseResponse();
                baseResponseObj = serviceLocatorObj.Execute(pincodeRequestBL);

                PincodeResponseBL pincodeResponseBL = (PincodeResponseBL)baseResponseObj;
                PincodeModelResponse pincodeModelResponse = new PincodeModelResponse();

                pincodeModelResponse.successMessage = pincodeResponseBL.SuccessMessage;
                pincodeModelResponse.errorMessage = pincodeResponseBL.ErrorMessage;

                return pincodeModelResponse;
            }
            public PincodeModelResponse insertDataToBL(PincodeProperties pincodeProperties)
            {
                PincodeRequestBL pincodeRequestBL = new PincodeRequestBL();
                pincodeRequestBL.name= pincodeProperties.name;
                pincodeRequestBL.age = pincodeProperties.age;
                pincodeRequestBL.gender = pincodeProperties.gender;
                pincodeRequestBL.hobby = pincodeProperties.hobby;
                pincodeRequestBL.stateId = pincodeProperties.stateId;
                pincodeRequestBL.districtId = pincodeProperties.districtId;
                pincodeRequestBL.cityId = pincodeProperties.cityId;
                pincodeRequestBL.pincode = pincodeProperties.pincode;
                pincodeRequestBL.active = pincodeProperties.active;

                pincodeRequestBL.BehaviourClass = "PincodeBL.BehaviourBL.PincodeBehaviourBL";
                pincodeRequestBL.BehaviourAction = "insert_pincode_data";

                ServiceLocator serviceLocatorObj = new ServiceLocator();
                BaseResponse baseResponseObj = new BaseResponse();
                baseResponseObj = serviceLocatorObj.Execute(pincodeRequestBL);

                PincodeResponseBL pincodeResponseBL = (PincodeResponseBL)baseResponseObj;
                PincodeModelResponse pincodeModelResponse = new PincodeModelResponse();

                pincodeModelResponse.successMessage = pincodeResponseBL.SuccessMessage;
                pincodeModelResponse.errorMessage = pincodeResponseBL.ErrorMessage;

                return pincodeModelResponse;

            }
            public PincodeModelResponse getUserDetails()
            {
                PincodeRequestBL pincodeRequestBL = new PincodeRequestBL();
                pincodeRequestBL.BehaviourClass = "PincodeBL.BehaviourBL.PincodeBehaviourBL";
                pincodeRequestBL.BehaviourAction = "get_user_details";

                ServiceLocator serviceLocatorObj = new ServiceLocator();
                PincodeResponseBL pincodeResponseBL = (PincodeResponseBL)serviceLocatorObj.Execute(pincodeRequestBL);
                PincodeModelResponse pincodeModelResponse = new PincodeModelResponse();

                pincodeModelResponse.dataSet = pincodeResponseBL.DataSet;
                pincodeModelResponse.successMessage = pincodeResponseBL.SuccessMessage;
               

                return pincodeModelResponse;

            }
            public PincodeModelResponse getStatedata(PincodeProperties pincodeProperties) 
            { 

                PincodeRequestBL pincodeRequestBL = new PincodeRequestBL();
                pincodeRequestBL.id = pincodeProperties.id;
                pincodeRequestBL.type = pincodeProperties.type;

                pincodeRequestBL.BehaviourClass = "PincodeBL.BehaviourBL.PincodeBehaviourBL";
                pincodeRequestBL.BehaviourAction = "get_pincode_data";

                ServiceLocator serviceLocatorObj = new ServiceLocator();
                BaseResponse baseResponseObj = new BaseResponse();
                baseResponseObj = serviceLocatorObj.Execute(pincodeRequestBL);

                PincodeResponseBL pincodeResponseBL = (PincodeResponseBL)baseResponseObj;
                PincodeModelResponse pincodeModelResponse = new PincodeModelResponse();

                pincodeModelResponse.dataSet = pincodeResponseBL.DataSet;
                pincodeModelResponse.successMessage = pincodeResponseBL.SuccessMessage;
                pincodeModelResponse.errorMessage = pincodeResponseBL.ErrorMessage;

                return pincodeModelResponse;
            }

        }




        public class PincodeProperties
        {
            public int? id { get; set; }
            public string? type { get; set; }
            public string? name { get; set; }
            public int? age { get; set; }
            public string? gender { get; set; }
            public string? hobby { get; set; }
            public int? stateId { get; set; }
            public int? districtId { get; set; }

            public int? cityId { get; set; }
            public int? pincode { get; set; }
            public string? active { get; set; }
        }

       

        public class PincodeModelResponse
        { 
            public DataSet dataSet { get; set; }
            public string successMessage { get; set; }
            public string errorMessage { get; set; }
        }

    }
    
}
