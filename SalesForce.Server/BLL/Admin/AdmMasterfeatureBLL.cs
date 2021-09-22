using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmMasterfeatureBLL
	{
		#region Auto Generated 

		public object SaveAdmMasterfeatureInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMasterfeatureEntity admMasterfeatureEntity = (AdmMasterfeatureEntity)param;
					AdmMasterfeatureDAL admMasterfeatureDAL = new AdmMasterfeatureDAL();
					retObj = (object)admMasterfeatureDAL.SaveAdmMasterfeatureInfo(admMasterfeatureEntity, db, transaction);
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

		public object UpdateAdmMasterfeatureInfo(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMasterfeatureEntity admMasterfeatureEntity = (AdmMasterfeatureEntity)param;
					AdmMasterfeatureDAL admMasterfeatureDAL = new AdmMasterfeatureDAL();
					retObj = (object)admMasterfeatureDAL.UpdateAdmMasterfeatureInfo(admMasterfeatureEntity, db, transaction);
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

		public object DeleteAdmMasterfeatureInfoById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			object retObj = null;
			using (DbConnection connection = db.CreateConnection())
			{
				connection.Open();
				DbTransaction transaction = connection.BeginTransaction();
				try
				{
					AdmMasterfeatureDAL admMasterfeatureDAL = new AdmMasterfeatureDAL();
					retObj = (object)admMasterfeatureDAL.DeleteAdmMasterfeatureInfoById(param , db, transaction);
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

		public object GetSingleAdmMasterfeatureRecordById(object param)
		{
			object retObj = null;
			AdmMasterfeatureDAL admMasterfeatureDAL = new AdmMasterfeatureDAL();
			retObj = (object)admMasterfeatureDAL.GetSingleAdmMasterfeatureRecordById(param);
			return retObj;
		}

		#endregion

	}
}

