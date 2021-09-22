using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmUserpermissionBLL
	{
		#region Auto Generated 

		public object SaveAdmUserpermissionInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmUserpermissionEntity admUserpermissionEntity = (AdmUserpermissionEntity)param;
					AdmUserpermissionDAL admUserpermissionDAL = new AdmUserpermissionDAL();
					retObj = (object)admUserpermissionDAL.SaveAdmUserpermissionInfo(admUserpermissionEntity, db, transaction);
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

		public object UpdateAdmUserpermissionInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmUserpermissionEntity admUserpermissionEntity = (AdmUserpermissionEntity)param;
					AdmUserpermissionDAL admUserpermissionDAL = new AdmUserpermissionDAL();
					retObj = (object)admUserpermissionDAL.UpdateAdmUserpermissionInfo(admUserpermissionEntity, db, transaction);
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

		public object DeleteAdmUserpermissionInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmUserpermissionDAL admUserpermissionDAL = new AdmUserpermissionDAL();
					retObj = (object)admUserpermissionDAL.DeleteAdmUserpermissionInfoById(param , db, transaction);
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

		public object GetSingleAdmUserpermissionRecordById(object param)
		{
			object retObj = null;
			AdmUserpermissionDAL admUserpermissionDAL = new AdmUserpermissionDAL();
			retObj = (object)admUserpermissionDAL.GetSingleAdmUserpermissionRecordById(param);
			return retObj;
		}

		#endregion

	}
}

