using System;
using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Admin
{
	public partial class AttendanceDAL
	{
        #region Auto Generated 

        public bool SaveAttendanceInfo(AttendanceModel attendanceEntity, Database db, DbTransaction transaction)
        {
            
             String sql = "INSERT INTO Attendance ( EmployeeId, StartDateTime, EndDateTime, CreatedBy, CreatedDate) VALUES ( @Employeeid,  @Startdatetime,  @Enddatetime,  @Createdby,  @Createddate )";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);

            db.AddInParameter(dbCommand, "Employeeid", DbType.String, attendanceEntity.Employeeid);
            db.AddInParameter(dbCommand, "Startdatetime", DbType.String, attendanceEntity.Startdatetime);
            db.AddInParameter(dbCommand, "Enddatetime", DbType.String, attendanceEntity.Enddatetime);
            db.AddInParameter(dbCommand, "Createdby", DbType.String, attendanceEntity.Createdby);
            db.AddInParameter(dbCommand, "Createddate", DbType.String, attendanceEntity.Createddate);

            db.ExecuteNonQuery(dbCommand, transaction);
            return true;
        }

        public bool UpdateAttendanceInfo(AttendanceModel attendanceEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE Attendance SET  EndDateTime= @Enddatetime WHERE EmployeeId=@Employeeid";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);		
			db.AddInParameter(dbCommand, "Employeeid", DbType.String, attendanceEntity.Employeeid);			
			db.AddInParameter(dbCommand, "Enddatetime", DbType.String, attendanceEntity.Enddatetime);
	

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}



		#endregion

	}
}

