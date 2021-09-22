using System;
using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmUserDAL
    {
        #region Auto Generated 

        public bool SaveAdmUserInfo(EmployeeModel employeeEntity, Database db, DbTransaction transaction)
        {

            //string sql = "INSERT INTO ADM_User ( UserId, UserPassword, UserName, Dob,Gender, JoiningDate, ContactNo, Email, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate,UserDept,UserDesig,UserTLeader,isManager,isHod,isPMG,BranchId) VALUES (  @UserId,  @UserPassword, @UserName, @Dob,@Gender,  @JoiningDate, @ContactNo, @Email, @CreatedBy,  @CreatedDate,  @UpdatedBy,  @UpdatedDate,@UserDept,@UserDesig,@UserTLeader,@isManager,@isHod,@isPMG ,@BranchId )";
            //DbCommand dbCommand = db.GetSqlStringCommand(sql);

            //db.AddInParameter(dbCommand, "UserId", DbType.String, admUserEntity.UserId);
            //db.AddInParameter(dbCommand, "UserPassword", DbType.String, admUserEntity.UserPassword);
            //db.AddInParameter(dbCommand, "UserName", DbType.String, admUserEntity.UserName);
            //db.AddInParameter(dbCommand, "Dob", DbType.String, admUserEntity.Dob);
            //db.AddInParameter(dbCommand, "Gender", DbType.String, admUserEntity.Gender);
            //db.AddInParameter(dbCommand, "JoiningDate", DbType.String, admUserEntity.JoiningDate);
            //db.AddInParameter(dbCommand, "ContactNo", DbType.String, admUserEntity.ContactNo);
            //db.AddInParameter(dbCommand, "Email", DbType.String, admUserEntity.Email);
            //db.AddInParameter(dbCommand, "CreatedBy", DbType.String, admUserEntity.CreatedBy);
            //db.AddInParameter(dbCommand, "CreatedDate", DbType.String, admUserEntity.CreatedDate);
            //db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, admUserEntity.UpdatedBy);
            //db.AddInParameter(dbCommand, "UpdatedDate", DbType.String, admUserEntity.UpdatedDate);

            //db.AddInParameter(dbCommand, "UserDept", DbType.String, admUserEntity.UserDept);
            //db.AddInParameter(dbCommand, "UserDesig", DbType.String, admUserEntity.UserDesig);
            //db.AddInParameter(dbCommand, "UserTLeader", DbType.String, admUserEntity.UserTLeader);
            //db.AddInParameter(dbCommand, "isManager", DbType.String, admUserEntity.isManager);
            //db.AddInParameter(dbCommand, "isHod", DbType.String, admUserEntity.isHod);
            //db.AddInParameter(dbCommand, "isPMG", DbType.String, admUserEntity.isPMG);
            //db.AddInParameter(dbCommand, "BranchId", DbType.String, admUserEntity.BranchId);

            //db.ExecuteNonQuery(dbCommand, transaction);
            //return true;

            string sql = "INSERT INTO Employee ( EmployeeIdNo, FirstName, LastName, JoiningDate, Email, ContactNo, NationalId, OfficeName, Department, Designaton, IsActive, CreatedBy, UpdatedBy, UpdatedDate) VALUES ( @Employeeidno,  @Firstname,  @Lastname,  @Joiningdate,  @Email,  @Contactno,  @Nationalid,  @Officename,  @Department,  @Designaton,  @Isactive,  @Createdby, @Updatedby,  @Updateddate )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "Employeeidno", DbType.String, employeeEntity.Employeeidno);
            db.AddInParameter(dbCommand, "Firstname", DbType.String, employeeEntity.Firstname);
            db.AddInParameter(dbCommand, "Lastname", DbType.String, employeeEntity.Lastname);
            db.AddInParameter(dbCommand, "Joiningdate", DbType.String, employeeEntity.Joiningdate);
            db.AddInParameter(dbCommand, "Email", DbType.String, employeeEntity.Email);
            db.AddInParameter(dbCommand, "Contactno", DbType.String, employeeEntity.Contactno);
            db.AddInParameter(dbCommand, "Nationalid", DbType.String, employeeEntity.Nationalid);
            db.AddInParameter(dbCommand, "Officename", DbType.String, employeeEntity.Officename);
            db.AddInParameter(dbCommand, "Department", DbType.String, employeeEntity.Department);
            db.AddInParameter(dbCommand, "Designaton", DbType.String, employeeEntity.Designaton);
            db.AddInParameter(dbCommand, "Isactive", DbType.String, employeeEntity.Isactive);
            db.AddInParameter(dbCommand, "Createdby", DbType.String, employeeEntity.Createdby);
            db.AddInParameter(dbCommand, "Updatedby", DbType.String, employeeEntity.Updatedby);
            db.AddInParameter(dbCommand, "Updateddate", DbType.String, employeeEntity.Updateddate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

        public bool UpdateAdmUserInfo(EmployeeModel employeeEntity, Database db, DbTransaction transaction)
        {
            //string sql = "UPDATE ADM_User SET UserId= @UserId, UserPassword= @UserPassword, UserName=@UserName, Dob= @Dob,Gender= @Gender, JoiningDate= @JoiningDate, @ContactNo=@ContactNo, Email= @Email, CreatedBy= @CreatedBy, CreatedDate= @CreatedDate, UserDept= @UserDept, UserDesig= @UserDesig, UserTLeader= @UserTLeader, isManager= @isManager, isHod= @isHod, isPMG= @isPMG, BranchId= @BranchId WHERE ID=@Id";
            //DbCommand dbCommand = db.GetSqlStringCommand(sql);
            //db.AddInParameter(dbCommand, "Id", DbType.String, admUserEntity.Id);
            //db.AddInParameter(dbCommand, "UserId", DbType.String, admUserEntity.UserId);
            //db.AddInParameter(dbCommand, "UserPassword", DbType.String, admUserEntity.UserPassword);
            //db.AddInParameter(dbCommand, "UserName", DbType.String, admUserEntity.UserName);
            //db.AddInParameter(dbCommand, "Dob", DbType.String, admUserEntity.Dob);
            //db.AddInParameter(dbCommand, "Gender", DbType.String, admUserEntity.Gender);
            //db.AddInParameter(dbCommand, "JoiningDate", DbType.String, admUserEntity.JoiningDate);
            //db.AddInParameter(dbCommand, "ContactNo", DbType.String, admUserEntity.ContactNo);
            //db.AddInParameter(dbCommand, "Email", DbType.String, admUserEntity.Email);
            //db.AddInParameter(dbCommand, "CreatedBy", DbType.String, admUserEntity.CreatedBy);
            //db.AddInParameter(dbCommand, "CreatedDate", DbType.String, admUserEntity.CreatedDate);
            ////db.AddInParameter(dbCommand, "UpdatedBy", DbType.String, admUserEntity.UpdatedBy);
            ////db.AddInParameter(dbCommand, "UpdatedDate", DbType.String, admUserEntity.UpdatedDate);
            //db.AddInParameter(dbCommand, "UserDept", DbType.String, admUserEntity.UserDept);
            //db.AddInParameter(dbCommand, "UserDesig", DbType.String, admUserEntity.UserDesig);
            //db.AddInParameter(dbCommand, "UserTLeader", DbType.String, admUserEntity.UserTLeader);
            //db.AddInParameter(dbCommand, "isManager", DbType.String, admUserEntity.isManager);
            //db.AddInParameter(dbCommand, "isHod", DbType.String, admUserEntity.isHod);
            //db.AddInParameter(dbCommand, "isPMG", DbType.String, admUserEntity.isPMG);
            //db.AddInParameter(dbCommand, "BranchId", DbType.String, admUserEntity.BranchId);
            //db.ExecuteNonQuery(dbCommand, transaction);
            //return true;
            string sql = "UPDATE Employee SET EmployeeIdNo= @Employeeidno, FirstName= @Firstname, LastName= @Lastname, JoiningDate= @Joiningdate, Email= @Email, ContactNo= @Contactno, NationalId= @Nationalid, OfficeName= @Officename, Department= @Department, Designaton= @Designaton, IsActive= @Isactive, CreatedBy= @Createdby, UpdatedBy= @Updatedby, UpdatedDate= @Updateddate WHERE Id=@Id";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "Id", DbType.String, employeeEntity.Id);
            db.AddInParameter(dbCommand, "Employeeidno", DbType.String, employeeEntity.Employeeidno);
            db.AddInParameter(dbCommand, "Firstname", DbType.String, employeeEntity.Firstname);
            db.AddInParameter(dbCommand, "Lastname", DbType.String, employeeEntity.Lastname);
            db.AddInParameter(dbCommand, "Joiningdate", DbType.String, employeeEntity.Joiningdate);
            db.AddInParameter(dbCommand, "Email", DbType.String, employeeEntity.Email);
            db.AddInParameter(dbCommand, "Contactno", DbType.String, employeeEntity.Contactno);
            db.AddInParameter(dbCommand, "Nationalid", DbType.String, employeeEntity.Nationalid);
            db.AddInParameter(dbCommand, "Officename", DbType.String, employeeEntity.Officename);
            db.AddInParameter(dbCommand, "Department", DbType.String, employeeEntity.Department);
            db.AddInParameter(dbCommand, "Designaton", DbType.String, employeeEntity.Designaton);
            db.AddInParameter(dbCommand, "Isactive", DbType.String, employeeEntity.Isactive);
            db.AddInParameter(dbCommand, "Createdby", DbType.String, employeeEntity.Createdby);
            db.AddInParameter(dbCommand, "Updatedby", DbType.String, employeeEntity.Updatedby);
            db.AddInParameter(dbCommand, "Updateddate", DbType.String, employeeEntity.Updateddate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

        public bool DeleteAdmUserInfoById(object param, Database db, DbTransaction transaction)
        {
            string sql = "DELETE FROM Employee WHERE Id=@Id";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "Id", DbType.String, param);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

        public EmployeeModel GetSingleAdmUserRecordById(object param)
        {
            ////Database db = DatabaseFactory.CreateDatabase();
            ////string sql = "";
            ////AdmUserEntity iGet = (AdmUserEntity)param;
            ////if (!string.IsNullOrEmpty(iGet.UserId))
            ////{
            ////    sql = "SELECT ID, UserId, UserPassword, UserName, Dob,Gender, JoiningDate, ContactNo, Email, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate,UserDept,UserDesig,UserTLeader,isManager,isHod,isPMG,BranchId FROM ADM_User WHERE UserId=@UserId";
            ////}
            ////else
            ////{
            ////    sql = "SELECT ID, UserId, UserPassword, UserName, Dob,Gender, JoiningDate, ContactNo, Email, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate,UserDept,UserDesig,UserTLeader,isManager,isHod,isPMG,BranchId FROM ADM_User WHERE ID=@Id";
            ////}

            //DbCommand dbCommand = db.GetSqlStringCommand(sql);
            //if (!string.IsNullOrEmpty(iGet.UserId))
            //{
            //    db.AddInParameter(dbCommand, "UserId", DbType.String, iGet.UserId);
            //}
            //else
            //{
            //    db.AddInParameter(dbCommand, "Id", DbType.String, iGet.Id);
            //}

            //AdmUserEntity admUserEntity = null;
            //using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            //{
            //    if (dataReader.Read())
            //    {
            //        admUserEntity = new AdmUserEntity();
            //        if (dataReader["ID"] != DBNull.Value)
            //        {
            //            admUserEntity.Id = dataReader["ID"].ToString();
            //        }
            //        if (dataReader["UserId"] != DBNull.Value)
            //        {
            //            admUserEntity.UserId = dataReader["UserId"].ToString();
            //        }
            //        if (dataReader["UserPassword"] != DBNull.Value)
            //        {
            //            admUserEntity.UserPassword = dataReader["UserPassword"].ToString();
            //        }

            //        if (dataReader["UserName"] != DBNull.Value)
            //        {
            //            admUserEntity.UserName = dataReader["UserName"].ToString();
            //        }

            //        if (dataReader["Dob"] != DBNull.Value)
            //        {
            //            admUserEntity.Dob = dataReader["Dob"].ToString();
            //        }

            //        if (dataReader["Gender"] != DBNull.Value)
            //        {
            //            admUserEntity.Gender = dataReader["Gender"].ToString();
            //        }
            //        if (dataReader["JoiningDate"] != DBNull.Value)
            //        {
            //            admUserEntity.JoiningDate = dataReader["JoiningDate"].ToString();
            //        }

            //        if (dataReader["ContactNo"] != DBNull.Value)
            //        {
            //            admUserEntity.ContactNo = dataReader["ContactNo"].ToString();
            //        }

            //        if (dataReader["Email"] != DBNull.Value)
            //        {
            //            admUserEntity.Email = dataReader["Email"].ToString();
            //        }
            //        if (dataReader["CreatedBy"] != DBNull.Value)
            //        {
            //            admUserEntity.CreatedBy = dataReader["CreatedBy"].ToString();
            //        }
            //        if (dataReader["CreatedDate"] != DBNull.Value)
            //        {
            //            admUserEntity.CreatedDate = dataReader["CreatedDate"].ToString();
            //        }
            //        if (dataReader["UpdatedBy"] != DBNull.Value)
            //        {
            //            admUserEntity.UpdatedBy = dataReader["UpdatedBy"].ToString();
            //        }
            //        if (dataReader["UpdatedDate"] != DBNull.Value)
            //        {
            //            admUserEntity.UpdatedDate = dataReader["UpdatedDate"].ToString();
            //        }
            //        if (dataReader["UserDept"] != DBNull.Value)
            //        {
            //            admUserEntity.UserDept = dataReader["UserDept"].ToString();
            //        }
            //        if (dataReader["UserDesig"] != DBNull.Value)
            //        {
            //            admUserEntity.UserDesig = dataReader["UserDesig"].ToString();
            //        }
            //        if (dataReader["UserTLeader"] != DBNull.Value)
            //        {
            //            admUserEntity.UserTLeader = dataReader["UserTLeader"].ToString();
            //        }
            //        if (dataReader["isManager"] != DBNull.Value)
            //        {
            //            admUserEntity.isManager = dataReader["isManager"].ToString();
            //        }
            //        if (dataReader["isHod"] != DBNull.Value)
            //        {
            //            admUserEntity.isHod = dataReader["isHod"].ToString();
            //        }
            //        if (dataReader["isPMG"] != DBNull.Value)
            //        {
            //            admUserEntity.isPMG = dataReader["isPMG"].ToString();
            //        }
            //        if (dataReader["BranchId"] != DBNull.Value)
            //        {
            //            admUserEntity.BranchId = dataReader["BranchId"].ToString();
            //        }

            //    }
            //}
            //return admUserEntity;
            EmployeeModel iGet = (EmployeeModel)param;
            Database db = DatabaseFactory.CreateDatabase();
            string sql;
            if (!string.IsNullOrEmpty(iGet.Employeeidno))
            {
                sql = "SELECT Id, EmployeeIdNo, FirstName, LastName, JoiningDate, Email, ContactNo, NationalId, OfficeName, Department, Designaton, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate FROM Employee WHERE Employeeidno=@Employeeidno";
            }
            else
            {
                sql = "SELECT Id, EmployeeIdNo, FirstName, LastName, JoiningDate, Email, ContactNo, NationalId, OfficeName, Department, Designaton, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate FROM Employee WHERE ID=@Id";
            }
      
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            if (!string.IsNullOrEmpty(iGet.Employeeidno))
            {
                db.AddInParameter(dbCommand, "Employeeidno", DbType.String, iGet.Employeeidno);
            }
            else
            {
                db.AddInParameter(dbCommand, "Id", DbType.String, iGet.Id);
            }
            EmployeeModel employeeEntity = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    employeeEntity = new EmployeeModel();
                    if (dataReader["Id"] != DBNull.Value)
                    {
                        employeeEntity.Id = Convert.ToInt32(dataReader["Id"]);
                    }
                    if (dataReader["EmployeeIdNo"] != DBNull.Value)
                    {
                        employeeEntity.Employeeidno = dataReader["EmployeeIdNo"].ToString();
                    }
                    if (dataReader["FirstName"] != DBNull.Value)
                    {
                        employeeEntity.Firstname = dataReader["FirstName"].ToString();
                    }
                    if (dataReader["LastName"] != DBNull.Value)
                    {
                        employeeEntity.Lastname = dataReader["LastName"].ToString();
                    }
                    if (dataReader["JoiningDate"] != DBNull.Value)
                    {
                        employeeEntity.Joiningdate = dataReader["JoiningDate"].ToString();
                    }
                    if (dataReader["Email"] != DBNull.Value)
                    {
                        employeeEntity.Email = dataReader["Email"].ToString();
                    }
                    if (dataReader["ContactNo"] != DBNull.Value)
                    {
                        employeeEntity.Contactno = dataReader["ContactNo"].ToString();
                    }
                    if (dataReader["NationalId"] != DBNull.Value)
                    {
                        employeeEntity.Nationalid = dataReader["NationalId"].ToString();
                    }
                    if (dataReader["OfficeName"] != DBNull.Value)
                    {
                        employeeEntity.Officename = dataReader["OfficeName"].ToString();
                    }
                    if (dataReader["Department"] != DBNull.Value)
                    {
                        employeeEntity.Department = dataReader["Department"].ToString();
                    }
                    if (dataReader["Designaton"] != DBNull.Value)
                    {
                        employeeEntity.Designaton = dataReader["Designaton"].ToString();
                    }
                    if (dataReader["IsActive"] != DBNull.Value)
                    {
                        employeeEntity.Isactive = dataReader["IsActive"].ToString();
                    }
                    if (dataReader["CreatedBy"] != DBNull.Value)
                    {
                        employeeEntity.Createdby = dataReader["CreatedBy"].ToString();
                    }
                    if (dataReader["CreatedDate"] != DBNull.Value)
                    {
                        employeeEntity.Createddate = dataReader["CreatedDate"].ToString();
                    }
                    if (dataReader["UpdatedBy"] != DBNull.Value)
                    {
                        employeeEntity.Updatedby = dataReader["UpdatedBy"].ToString();
                    }
                    if (dataReader["UpdatedDate"] != DBNull.Value)
                    {
                        employeeEntity.Updateddate = dataReader["UpdatedDate"].ToString();
                    }
                }
            }
            return employeeEntity;
        }

        public bool SaveAttendanceInfo(AttendanceModel attendanceEntity, Database db, DbTransaction transaction)
        {
            string sql = "SELECT isnull(MAX(Id),0)+1  FROM Attendance";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            attendanceEntity.Employeeid = Convert.ToString(db.ExecuteScalar(dbCommand, transaction));
             sql = "INSERT INTO Attendance ( EmployeeId, StartDateTime, EndDateTime, CreatedBy, CreatedDate) VALUES ( @Employeeid,  @Startdatetime,  @Enddatetime,  @Createdby,  @Createddate )";
            dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "Employeeid", DbType.String, attendanceEntity.Employeeid);
            db.AddInParameter(dbCommand, "Startdatetime", DbType.String, attendanceEntity.Startdatetime);
            db.AddInParameter(dbCommand, "Enddatetime", DbType.String, attendanceEntity.Enddatetime);
            db.AddInParameter(dbCommand, "Createdby", DbType.String, attendanceEntity.Createdby);
            db.AddInParameter(dbCommand, "Createddate", DbType.String, attendanceEntity.Createddate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

        #endregion

    }
}

