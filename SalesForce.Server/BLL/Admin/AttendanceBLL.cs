using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SalesForce.Server.DAL.Admin;

namespace SalesForce.Server.BLL.Admin
{
	public partial class AttendanceBLL
	{
		#region Auto Generated 

		public object SaveAttendanceInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
                    AttendanceModel attendanceEntity = (AttendanceModel)param;
                    AttendanceDAL attendanceDAL = new AttendanceDAL();
					retObj = (object)attendanceDAL.SaveAttendanceInfo(attendanceEntity, db, transaction);
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
			return retObj;
		}

		public object UpdateAttendanceInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
                    AttendanceModel attendanceEntity = (AttendanceModel)param;
                    AttendanceDAL attendanceDAL = new AttendanceDAL();
                    retObj = (object)attendanceDAL.UpdateAttendanceInfo(attendanceEntity, db, transaction);
                    transaction.Commit();
                }
				catch
				{
					transaction.Rollback();
					throw;
				}
				finally
				{
					connection.Close();
				}
			}
			return retObj;
		}

	


		#endregion

	}
}

