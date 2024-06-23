using PincodeBL.Contracts.RequestBL;
using PincodeBL.Contracts.ResponseBL;
using PincodeBL.Shared;
using PincodeDAL.Contracts.RequestDAL;
using PincodeDAL.Contracts.ResponseDAL;
using PincodeDAL.PincodeBehaviourDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincodeBL.BehaviourBL
{
    public class PincodeBehaviourBL : BaseBehaviour
    {
        public override BaseResponse Execute(BaseRequest baseRequest)
        {
           PincodeRequestBL pincodeRequestBL = (PincodeRequestBL)baseRequest;
            BaseResponse response = new BaseResponse();

            switch(pincodeRequestBL.BehaviourAction )  
            {
                case "get_pincode_data":
                    response = getStateDetails(pincodeRequestBL);
                    break;
                case "insert_pincode_data":
                    response = saveDatatoDL(pincodeRequestBL);
                    break;
                case "update_pincode_data":
                    response = updataDataToDAL(pincodeRequestBL);
                    break;

                case "get_user_details":
                    response = getUserDetailsFromDAL();
                    break;
                case "delete_pincode_data":
                    response = deleteDataDL(pincodeRequestBL);
                    break;

                default:
                    break;
            }
            return response;
        }
        public BaseResponse updataDataToDAL(PincodeRequestBL pincodeRequestBL)
        {
            PincodeBehaviourDAL pincodeBehaviourDAL = new PincodeBehaviourDAL();
            PincodeRequestDAL pincodeRequestDAL = new PincodeRequestDAL();
            pincodeRequestDAL.name = pincodeRequestBL.name;
            pincodeRequestDAL.age = pincodeRequestBL.age;
            pincodeRequestDAL.gender = pincodeRequestBL.gender;
            pincodeRequestDAL.hobby = pincodeRequestBL.hobby;
            pincodeRequestDAL.stateId = pincodeRequestBL.stateId;
            pincodeRequestDAL.districtId = pincodeRequestBL.districtId;
            pincodeRequestDAL.cityId = pincodeRequestBL.cityId;
            pincodeRequestDAL.pincode = pincodeRequestBL.pincode;
            pincodeRequestDAL.id = pincodeRequestBL.id;

            PincodeResponseDAL pincodeResponseDAL = new PincodeResponseDAL();
            pincodeResponseDAL = pincodeBehaviourDAL.UpdateDataInDB(pincodeRequestDAL);
            PincodeResponseBL pincodeResponseBL = new PincodeResponseBL();
            pincodeResponseBL.SuccessMessage = pincodeResponseDAL.successMessage;
            pincodeResponseBL.ErrorMessage = pincodeResponseDAL.errorMessage;

            return pincodeResponseBL;


        }
        public BaseResponse deleteDataDL(PincodeRequestBL pincodeRequestBL)
        {
            PincodeBehaviourDAL pincodeBehaviourDAL = new PincodeBehaviourDAL();
            PincodeRequestDAL pincodeRequestDAL = new PincodeRequestDAL();
            pincodeRequestDAL.active = pincodeRequestBL.active;
            pincodeRequestDAL.id = pincodeRequestBL.id;
           

            PincodeResponseDAL pincodeResponseDAL = new PincodeResponseDAL();
            pincodeResponseDAL = pincodeBehaviourDAL.DeleteDataInDB(pincodeRequestDAL);
            PincodeResponseBL pincodeResponseBL = new PincodeResponseBL();
            pincodeResponseBL.SuccessMessage = pincodeResponseDAL.successMessage;
            pincodeResponseBL.ErrorMessage = pincodeResponseDAL.errorMessage;

            return pincodeResponseBL;


        }
        public BaseResponse saveDatatoDL(PincodeRequestBL pincodeRequestBL)
        {
            PincodeRequestDAL pincodeRequestDAL = new PincodeRequestDAL();
            pincodeRequestDAL.name = pincodeRequestBL.name;
            pincodeRequestDAL.age = pincodeRequestBL.age;
            pincodeRequestDAL.gender = pincodeRequestBL.gender;
            pincodeRequestDAL.hobby = pincodeRequestBL.hobby;
            pincodeRequestDAL.stateId = pincodeRequestBL.stateId;
            pincodeRequestDAL.districtId = pincodeRequestBL.districtId;
            pincodeRequestDAL.cityId = pincodeRequestBL.cityId;
            pincodeRequestDAL.pincode = pincodeRequestBL.pincode;
            pincodeRequestDAL.active = pincodeRequestBL.active;

            PincodeBehaviourDAL pincodeBehaviourDAL = new PincodeBehaviourDAL();
            PincodeResponseDAL pincodeResponseDAL = new PincodeResponseDAL();
            pincodeResponseDAL = pincodeBehaviourDAL.SaveDataToDb(pincodeRequestDAL);

            PincodeResponseBL pincodeResponseBL = new PincodeResponseBL();
            pincodeResponseBL.SuccessMessage = pincodeResponseDAL.successMessage;
            pincodeResponseBL.ErrorMessage = pincodeResponseDAL.errorMessage;

            return pincodeResponseBL;


        }
        public BaseResponse getUserDetailsFromDAL()
        {
            PincodeBehaviourDAL pincodeBehaviourDAL = new PincodeBehaviourDAL();
            PincodeResponseBL pincodeResponseBL = new PincodeResponseBL();
            pincodeResponseBL.DataSet = pincodeBehaviourDAL.GetUserDetailsFromDB();
            pincodeResponseBL.SuccessMessage = "Successfully data retrieved";
            return pincodeResponseBL;
        }
        public BaseResponse getStateDetails(PincodeRequestBL pincodeRequestBL)
        {
            PincodeRequestDAL pincodeRequestDAL = new PincodeRequestDAL();
            pincodeRequestDAL.id = pincodeRequestBL.id;
            pincodeRequestDAL.type = pincodeRequestBL.type;

            PincodeBehaviourDAL pincodeBehaviourDAL = new PincodeBehaviourDAL();
            PincodeResponseBL pincodeResponseBL = new PincodeResponseBL();

            
            DataSet dataSet = pincodeBehaviourDAL.GetStateDataFromDB(pincodeRequestDAL);

            if (dataSet != null  && dataSet.Tables[0].Rows.Count > 0)
            {
                
                pincodeResponseBL.SuccessMessage = "Data retrieved successfully.";
                pincodeResponseBL.DataSet = dataSet;
            }
            else
            {
                
                pincodeResponseBL.ErrorMessage = "No data found.";
            }

            return pincodeResponseBL;


        }

        
    }
}
