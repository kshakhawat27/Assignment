using System;
using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmSubfeatureDAL
	{
		#region Auto Generated 

		public bool SaveAdmSubfeatureInfo(AdmSubfeatureEntity admSubfeatureEntity, Database db, DbTransaction transaction)
		{
            string sql = "INSERT INTO ADM_SubFeature ( TabId, SubFeatureName, URL, SL,QuickLink) VALUES (  @Tabid,  @Subfeaturename,  @Url,  @Sl,@QuickLink )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Tabid", DbType.String, admSubfeatureEntity.Tabid);
			db.AddInParameter(dbCommand, "Subfeaturename", DbType.String, admSubfeatureEntity.Subfeaturename);
			db.AddInParameter(dbCommand, "Url", DbType.String, admSubfeatureEntity.Url);
			db.AddInParameter(dbCommand, "Sl", DbType.String, admSubfeatureEntity.Sl);
            db.AddInParameter(dbCommand, "QuickLink", DbType.String, admSubfeatureEntity.QuickLink);
			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateAdmSubfeatureInfo(AdmSubfeatureEntity admSubfeatureEntity, Database db, DbTransaction transaction)
		{
            //TabId= @Tabid,
            string sql = "UPDATE ADM_SubFeature SET  SubFeatureName= @Subfeaturename, URL= @Url, SL= @Sl,QuickLink=@QuickLink WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admSubfeatureEntity.Id);
			//db.AddInParameter(dbCommand, "Tabid", DbType.String, admSubfeatureEntity.Tabid);
			db.AddInParameter(dbCommand, "Subfeaturename", DbType.String, admSubfeatureEntity.Subfeaturename);
			db.AddInParameter(dbCommand, "Url", DbType.String, admSubfeatureEntity.Url);
			db.AddInParameter(dbCommand, "Sl", DbType.String, admSubfeatureEntity.Sl);
            db.AddInParameter(dbCommand, "QuickLink", DbType.String, admSubfeatureEntity.QuickLink);
			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmSubfeatureInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM ADM_SubFeature WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmSubfeatureEntity GetSingleAdmSubfeatureRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = @"SELECT A.ID,M.ModuleName, A.TabId, A.SubFeatureName, A.URL, A.SL,isnull(A.QuickLink,'No') QuickLink FROM ADM_SubFeature A  LEFT OUTER JOIN ADM_MasterFeature M ON A.TabId = M.ID WHERE A.ID=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmSubfeatureEntity admSubfeatureEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admSubfeatureEntity = new AdmSubfeatureEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admSubfeatureEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["TabId"] != DBNull.Value)
					{
						admSubfeatureEntity.Tabid = dataReader["TabId"].ToString();
					}
					if (dataReader["SubFeatureName"] != DBNull.Value)
					{
						admSubfeatureEntity.Subfeaturename = dataReader["SubFeatureName"].ToString();
					}
					if (dataReader["URL"] != DBNull.Value)
					{
						admSubfeatureEntity.Url = dataReader["URL"].ToString();
					}
					if (dataReader["SL"] != DBNull.Value)
					{
						admSubfeatureEntity.Sl = dataReader["SL"].ToString();
					}
					if (dataReader["ModuleName"] != DBNull.Value)
					{
						admSubfeatureEntity.ModuleName = dataReader["ModuleName"].ToString();
					}
					if (dataReader["QuickLink"] != DBNull.Value)
					{
						admSubfeatureEntity.QuickLink = dataReader["QuickLink"].ToString();
					}
				}
			}
			return admSubfeatureEntity;
		}

		#endregion

	}
}

