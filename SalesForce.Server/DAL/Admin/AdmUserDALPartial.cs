using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmUserDAL
    {
        public DataTable GetAllAdmUserRecord(object param)
        {

            //AdmUserEntity op = (AdmUserEntity)param;
            //Database db = DatabaseFactory.CreateDatabase();

            ////string sql = "SELECT ADM_User.ID, UserId, EmpName,FatherName,MotherName,Organization,DeptName,Designation,EmployeeTypeName,Password, ADM_User.EmpId,UserType, Created_by AS CreatedBy, Created_Date AS CreatedDate, Updated_By AS UpdatedBy, Updated_Date AS UpdatedDate FROM ADM_User,vw_All_EmployeeInformation  Where vw_All_EmployeeInformation.EmpId = ADM_User.EmpId ";
            //string sql = @"SELECT U.ID,U.UserId,U.UserPassword,U.UserName,U.Dob,Gender,U.JoiningDate,U.ContactNo,U.Email,U.EmpId,U.UserType from ADM_User U ";


            //if (op != null)
            //{
            //    sql = sql + " WHERE 1=1 ";
            //    if (!string.IsNullOrEmpty(op.Id))
            //    {
            //        sql = sql + " and U.ID='" + op.Id + "' ";

            //    }
            //    if (!string.IsNullOrEmpty(op.UserId))
            //    {
            //        sql = sql + " and U.UserId='" + op.UserId + "' ";

            //    }
            //    if (!string.IsNullOrEmpty(op.isManager))
            //    {
            //        sql = sql + " and isManager='" + op.isManager + "' ";

            //    }
            //    if (!string.IsNullOrEmpty(op.isHod))
            //    {
            //        sql = sql + " and isHod='" + op.isHod + "' ";

            //    }
            //    if (!string.IsNullOrEmpty(op.isPMG))
            //    {
            //        sql = sql + " and isPMG='" + op.isPMG + "' ";

            //    }
            //    if (!string.IsNullOrEmpty(op.UserDesig))
            //    {
            //        sql = sql + " and UserDesig='" + op.UserDesig + "' ";

            //    }
            //    if (!string.IsNullOrEmpty(op.UserTLeader))
            //    {
            //        sql = sql + " and U.UserTLeader='" + op.UserTLeader + "' ";

            //    }
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT Id, EmployeeIdNo, FirstName, LastName, JoiningDate, Email, ContactNo, NationalId, OfficeName, Department, Designaton, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate FROM Employee";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];

        //}

        //    DbCommand dbCommand = db.GetSqlStringCommand(sql);
        //    DataSet ds = db.ExecuteDataSet(dbCommand);
        //    return ds.Tables[0];
        }

    }
}

