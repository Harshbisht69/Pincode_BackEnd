using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PincodeDAL.Entity.PincodeEntity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using PincodeDAL.Contracts.RequestDAL;
using PincodeDAL.Contracts.ResponseDAL;

namespace PincodeDAL.PincodeBehaviourDAL
{
    public class PincodeBehaviourDAL
    {
        private readonly string? _dbString = new PincodeDAL.Entity.PincodeEntity.PincodeNewContext().Database.GetConnectionString();
        int response = 0;

       
        public PincodeResponseDAL SaveDataToDb(PincodeRequestDAL pincodeRequestDAL)
        {
            
            using(PincodeDAL.Entity.PincodeEntity.PincodeNewContext dbContext = new PincodeDAL.Entity.PincodeEntity.PincodeNewContext())
            {
                MyTable myTable = new MyTable();
                myTable.Name = pincodeRequestDAL.name;
                myTable.Age = pincodeRequestDAL.age;
                myTable.Gender = pincodeRequestDAL.gender;
                myTable.Hobby = pincodeRequestDAL.hobby;
                myTable.StateId = pincodeRequestDAL.stateId;
                myTable.DistrictId = pincodeRequestDAL.districtId;
                myTable.CityId = pincodeRequestDAL.cityId;
                myTable.Pincode = pincodeRequestDAL.pincode;
                myTable.Active= pincodeRequestDAL.active;
                dbContext.Add(myTable);

                response = dbContext.SaveChanges();

            }
            PincodeResponseDAL pincodeResponseDAL = new PincodeResponseDAL();
            if (response > 0)
            {
                pincodeResponseDAL.successMessage = "Data saved successfully.";
            }
            else
            {
                pincodeResponseDAL.errorMessage = "No data was saved.";
            }

            return pincodeResponseDAL;


        }
        public DataSet GetUserDetailsFromDB()
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand("ShowUserDetails", connection);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dataSet);
            }

            return dataSet;

        }
        
        public DataSet GetStateDataFromDB(PincodeRequestDAL pincodeRequestDAL)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(_dbString))
            {
                SqlCommand cmd = new SqlCommand("GetDataByTypeAndId", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@type", pincodeRequestDAL.type));

                cmd.Parameters.Add(new SqlParameter("@id", pincodeRequestDAL.id ?? (object)DBNull.Value));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                connection.Close();
                adapter.Fill(dataSet);  
            }
            return dataSet;
        }

        public PincodeResponseDAL UpdateDataInDB(PincodeRequestDAL pincodeRequest)
        {
            int response = 0;
            using (PincodeDAL.Entity.PincodeEntity.PincodeNewContext dbContext = new PincodeDAL.Entity.PincodeEntity.PincodeNewContext())
            {
                MyTable existingPincode = dbContext.MyTables.Find(pincodeRequest.id);
                if (existingPincode != null)
                {
                    existingPincode.Name = pincodeRequest.name;
                    existingPincode.Age = pincodeRequest.age;
                    existingPincode.Gender = pincodeRequest.gender;
                    existingPincode.Hobby = pincodeRequest.hobby;
                    existingPincode.StateId = pincodeRequest.stateId;
                    existingPincode.DistrictId = pincodeRequest.districtId;
                    existingPincode.CityId = pincodeRequest.cityId;
                    existingPincode.Pincode = pincodeRequest.pincode;

                    response = dbContext.SaveChanges();
                }

            }
            PincodeResponseDAL pincodeResponseDAL = new PincodeResponseDAL();
            if (response == 1)
            {
                pincodeResponseDAL.successMessage = "Data updated successfully.";
            }
            else
            {
                pincodeResponseDAL.errorMessage = "No data was updated.";
            }

            return pincodeResponseDAL;
        }

        public PincodeResponseDAL DeleteDataInDB(PincodeRequestDAL pincodeRequest)
        {
            int response = 0;
            using (PincodeDAL.Entity.PincodeEntity.PincodeNewContext dbContext = new PincodeDAL.Entity.PincodeEntity.PincodeNewContext())
            {
                MyTable existingPincode = dbContext.MyTables.Find(pincodeRequest.id);
                if (existingPincode != null)
                {
                    if(existingPincode.Active == "Active")
                    {
                        existingPincode.Active = "Inactive";
                    }
                    else
                    {
                        existingPincode.Active = "Active";
                    }
                    

                    response = dbContext.SaveChanges();
                }

            }
            PincodeResponseDAL pincodeResponseDAL = new PincodeResponseDAL();
            if (response == 1)
            {
                pincodeResponseDAL.successMessage = "Data deleted successfully.";
            }
            else
            {
                pincodeResponseDAL.errorMessage = "No data was deleted.";
            }

            return pincodeResponseDAL;
        }






    }

}
