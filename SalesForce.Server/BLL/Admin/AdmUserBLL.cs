using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmUserBLL
	{
		#region Auto Generated 

		public object SaveAdmUserInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
                    EmployeeModel admUserEntity = (EmployeeModel)param;
					AdmUserDAL admUserDAL = new AdmUserDAL();
					retObj = (object)admUserDAL.SaveAdmUserInfo(admUserEntity, db, transaction);
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

		public object UpdateAdmUserInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
                    EmployeeModel admUserEntity = (EmployeeModel)param;
					AdmUserDAL admUserDAL = new AdmUserDAL();
					retObj = (object)admUserDAL.UpdateAdmUserInfo(admUserEntity, db, transaction);
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

		public object DeleteAdmUserInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmUserDAL admUserDAL = new AdmUserDAL();
					retObj = (object)admUserDAL.DeleteAdmUserInfoById(param , db, transaction);
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

		public object GetSingleAdmUserRecordById(object param)
		{
			object retObj = null;
			AdmUserDAL admUserDAL = new AdmUserDAL();
			retObj = (object)admUserDAL.GetSingleAdmUserRecordById(param);
			return retObj;
		}

		#endregion

	}
}

