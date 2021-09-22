using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmSubfeatureBLL
	{
		#region Auto Generated 

		public object SaveAdmSubfeatureInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmSubfeatureEntity admSubfeatureEntity = (AdmSubfeatureEntity)param;
					AdmSubfeatureDAL admSubfeatureDAL = new AdmSubfeatureDAL();
					retObj = (object)admSubfeatureDAL.SaveAdmSubfeatureInfo(admSubfeatureEntity, db, transaction);
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

		public object UpdateAdmSubfeatureInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmSubfeatureEntity admSubfeatureEntity = (AdmSubfeatureEntity)param;
					AdmSubfeatureDAL admSubfeatureDAL = new AdmSubfeatureDAL();
					retObj = (object)admSubfeatureDAL.UpdateAdmSubfeatureInfo(admSubfeatureEntity, db, transaction);
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

		public object DeleteAdmSubfeatureInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmSubfeatureDAL admSubfeatureDAL = new AdmSubfeatureDAL();
					retObj = (object)admSubfeatureDAL.DeleteAdmSubfeatureInfoById(param , db, transaction);
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

		public object GetSingleAdmSubfeatureRecordById(object param)
		{
			object retObj = null;
			AdmSubfeatureDAL admSubfeatureDAL = new AdmSubfeatureDAL();
			retObj = (object)admSubfeatureDAL.GetSingleAdmSubfeatureRecordById(param);
			return retObj;
		}

		#endregion

	}
}

