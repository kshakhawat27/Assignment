using SalesForce.Domain.Admin;
using SalesForce.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SalesForce.List
{
    public class UserInfoList
    {
        public int SaveUserInfo(AdmUserEntity _dbModel)
        {
            SqlConnection conn = new SqlConnection(DBConnection.GetConnection());
            conn.Open();
            SqlCommand dCmd = new SqlCommand("SP_SET_INFO", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dCmd.Parameters.AddWithValue("@UserId", _dbModel.UserId);
                dCmd.Parameters.AddWithValue("@UserName", _dbModel.UserName);
                dCmd.Parameters.AddWithValue("@RollId", _dbModel.RollId);
                dCmd.Parameters.AddWithValue("@UserPassword", _dbModel.UserPassword);
                dCmd.Parameters.AddWithValue("@ImagePath", _dbModel.ImagePath);
               
             
                    dCmd.Parameters.AddWithValue("@QryOption", 1);
                return dCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}