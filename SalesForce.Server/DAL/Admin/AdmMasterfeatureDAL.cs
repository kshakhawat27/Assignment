using System;
using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmMasterfeatureDAL
	{
		#region Auto Generated 

		public bool SaveAdmMasterfeatureInfo(AdmMasterfeatureEntity admMasterfeatureEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO ADM_MasterFeature ( ModuleName, TabName, URL, SL) VALUES (  @Modulename,  @Tabname,  @Url,  @Sl )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Modulename", DbType.String, admMasterfeatureEntity.Modulename);
			db.AddInParameter(dbCommand, "Tabname", DbType.String, admMasterfeatureEntity.Tabname);
			db.AddInParameter(dbCommand, "Url", DbType.String, admMasterfeatureEntity.Url);
			db.AddInParameter(dbCommand, "Sl", DbType.String, admMasterfeatureEntity.Sl);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateAdmMasterfeatureInfo(AdmMasterfeatureEntity admMasterfeatureEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE ADM_MasterFeature SET ModuleName= @Modulename, TabName= @Tabname, URL= @Url, SL= @Sl WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admMasterfeatureEntity.Id);
			db.AddInParameter(dbCommand, "Modulename", DbType.String, admMasterfeatureEntity.Modulename);
			db.AddInParameter(dbCommand, "Tabname", DbType.String, admMasterfeatureEntity.Tabname);
			db.AddInParameter(dbCommand, "Url", DbType.String, admMasterfeatureEntity.Url);
			db.AddInParameter(dbCommand, "Sl", DbType.String, admMasterfeatureEntity.Sl);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmMasterfeatureInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM ADM_MasterFeature WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmMasterfeatureEntity GetSingleAdmMasterfeatureRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, ModuleName, TabName, URL, SL FROM ADM_MasterFeature WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmMasterfeatureEntity admMasterfeatureEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admMasterfeatureEntity = new AdmMasterfeatureEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admMasterfeatureEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["ModuleName"] != DBNull.Value)
					{
						admMasterfeatureEntity.Modulename = dataReader["ModuleName"].ToString();
					}
					if (dataReader["TabName"] != DBNull.Value)
					{
						admMasterfeatureEntity.Tabname = dataReader["TabName"].ToString();
					}
					if (dataReader["URL"] != DBNull.Value)
					{
						admMasterfeatureEntity.Url = dataReader["URL"].ToString();
					}
					if (dataReader["SL"] != DBNull.Value)
					{
						admMasterfeatureEntity.Sl = dataReader["SL"].ToString();
					}
				}
			}
			return admMasterfeatureEntity;
		}

		#endregion

	}
}

