using SalesForce.Domain.Admin;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SalesForce.Models;


namespace CG01Lib
{
    public class CG01List
    {
        //public int SaveCG01(EmployeeModel _dbModel)
        //{
        //    SqlConnection conn = new SqlConnection(Class1.DBConnection.GetConnection());
        //    conn.Open();
        //    SqlCommand dCmd = new SqlCommand("SP_SET_INFO", conn);
        //    dCmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        dCmd.Parameters.AddWithValue("@InfoID", _dbModel.InfoID);
        //        dCmd.Parameters.AddWithValue("@InfoName", _dbModel.InfoName);
        //        dCmd.Parameters.AddWithValue("@InfoWeb", _dbModel.InfoWeb);
        //        dCmd.Parameters.AddWithValue("@Infomail", _dbModel.Infomail);
        //        dCmd.Parameters.AddWithValue("@Country", _dbModel.Country);
        //        if (_dbModel.InfoID > 0)
        //            dCmd.Parameters.AddWithValue("@QryOption", 2);
        //        else
        //            dCmd.Parameters.AddWithValue("@QryOption", 1);
        //        return dCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //UtilityOptions.ErrorLog(ex.ToString(), MethodBase.GetCurrentMethod().Name);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dCmd.Dispose();
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}
        
        public List<EmployeeModel2> LoadAllCG01()
        {
            List<EmployeeModel2> _modelList = new List<EmployeeModel2>();
            SqlConnection conn = new SqlConnection(DBConnection.GetConnection());
            conn.Open();
            SqlCommand dAd = new SqlCommand("SP_SET_Employee", conn);
            SqlDataAdapter sda = new SqlDataAdapter(dAd);
            dAd.CommandType = CommandType.StoredProcedure;
            dAd.Parameters.AddWithValue("@QryOption",3);
            DataTable dt = new DataTable();
            try
            {
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    _modelList = (from DataRow row in dt.Rows
                                  select new EmployeeModel2
                                  {
                              
                                      Employeeidno= (row["EmployeeIdNo"].ToString()),
                                      Firstname= (row["FirstName"].ToString()),
                                      Lastname= (row["LastName"].ToString()),
                                      Joiningdate= (row["JoiningDate"].ToString()),
                                      Email= (row["Email"].ToString()),
                                      Designaton= (row["Designaton"].ToString()),
                                      Department = (row["Department"].ToString()),
                                      InfoName= (row["FirstName"].ToString()),
                                  }).ToList();
                }
                return _modelList;
            }
            catch (Exception ex)
            {
                //UtilityOptions.ErrorLog(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dt.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public DataSet LoadAllCG01Report()
        {
            SqlConnection conn = new SqlConnection(DBConnection.GetConnection());
            conn.Open();
            SqlCommand dAd = new SqlCommand("SP_SET_Employee", conn);
            SqlDataAdapter sda = new SqlDataAdapter(dAd);
            dAd.CommandType = CommandType.StoredProcedure;
            dAd.Parameters.AddWithValue("@QryOption", 3);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);


                return ds;
            }
            catch (Exception ex)
            {
                //UtilityOptions.ErrorLog(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                ds.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public List<AttendanceModel> LoadAllAttendance()
        {
            List<AttendanceModel> _modelList = new List<AttendanceModel>();
            SqlConnection conn = new SqlConnection(DBConnection.GetConnection());
            conn.Open();
            SqlCommand dAd = new SqlCommand("SP_SET_Employee", conn);
            SqlDataAdapter sda = new SqlDataAdapter(dAd);
            dAd.CommandType = CommandType.StoredProcedure;
            dAd.Parameters.AddWithValue("@QryOption", 4);
            DataTable dt = new DataTable();
            try
            {
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    _modelList = (from DataRow row in dt.Rows
                                  select new AttendanceModel
                                  {

                                      Employeeid = (row["EmployeeId"].ToString()),
                                      Startdatetime = (row["StartDateTime"].ToString()),
                                      Enddatetime = (row["EndDateTime"].ToString()),
                                      Createddate = (row["CreatedDate"].ToString()),
                                  
                                  }).ToList();
                }
                return _modelList;
            }
            catch (Exception ex)
            {
                //UtilityOptions.ErrorLog(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                dt.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        public DataSet LoadAllAttendanceReport()
        {
            SqlConnection conn = new SqlConnection(DBConnection.GetConnection());
            conn.Open();
            SqlCommand dAd = new SqlCommand("SP_SET_Employee", conn);
            SqlDataAdapter sda = new SqlDataAdapter(dAd);
            dAd.CommandType = CommandType.StoredProcedure;
            dAd.Parameters.AddWithValue("@QryOption", 5);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);


                return ds;
            }
            catch (Exception ex)
            {
                //UtilityOptions.ErrorLog(ex.ToString(), MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            finally
            {
                ds.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }


    }
}
