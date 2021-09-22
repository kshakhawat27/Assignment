using System;
using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmUserpermissionDAL
	{
		#region Auto Generated 

		public bool SaveAdmUserpermissionInfo(AdmUserpermissionEntity admUserpermissionEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO ADM_UserPermission ( UserId, SubFeatureId, AccessLevel, CreatedBy, CreatedDate, UpdateBy, UpdateDate) VALUES (  @Userid,  @Subfeatureid,  @Accesslevel,  @Createdby,  @Createddate,  @Updateby,  @Updatedate )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Userid", DbType.String, admUserpermissionEntity.Userid);
			db.AddInParameter(dbCommand, "Subfeatureid", DbType.String, admUserpermissionEntity.Subfeatureid);
			db.AddInParameter(dbCommand, "Accesslevel", DbType.String, admUserpermissionEntity.Accesslevel);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, admUserpermissionEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, admUserpermissionEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, admUserpermissionEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, admUserpermissionEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateAdmUserpermissionInfo(AdmUserpermissionEntity admUserpermissionEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE ADM_UserPermission SET UserId= @Userid, SubFeatureId= @Subfeatureid, AccessLevel= @Accesslevel, CreatedBy= @Createdby, CreatedDate= @Createddate, UpdateBy= @Updateby, UpdateDate= @Updatedate WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, admUserpermissionEntity.Id);
			db.AddInParameter(dbCommand, "Userid", DbType.String, admUserpermissionEntity.Userid);
			db.AddInParameter(dbCommand, "Subfeatureid", DbType.String, admUserpermissionEntity.Subfeatureid);
			db.AddInParameter(dbCommand, "Accesslevel", DbType.String, admUserpermissionEntity.Accesslevel);
			db.AddInParameter(dbCommand, "Createdby", DbType.String, admUserpermissionEntity.Createdby);
			db.AddInParameter(dbCommand, "Createddate", DbType.String, admUserpermissionEntity.Createddate);
			db.AddInParameter(dbCommand, "Updateby", DbType.String, admUserpermissionEntity.Updateby);
			db.AddInParameter(dbCommand, "Updatedate", DbType.String, admUserpermissionEntity.Updatedate);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteAdmUserpermissionInfoById(object param, Database db, DbTransaction transaction)
		{
            AdmUserpermissionEntity obj = (AdmUserpermissionEntity) param;
            int flag = 0;
			string sql = "DELETE FROM ADM_UserPermission WHERE ";

            if (obj.Id != null && obj.Id != "")
            {
                if (flag == 1)
                    sql = sql + " AND ";

                sql = sql + " ID='" + obj.Id + "' ";
                flag = 0;
            }
           
            if (obj.Subfeatureid != null && obj.Subfeatureid != "")
            {
                if (flag == 1)
                    sql = sql + " AND ";
                sql = sql + " SubFeatureId='" + obj.Subfeatureid + "' ";
                flag = 1;
            }

           
            if (obj.Userid != null && obj.Userid != "")
            {
                if (flag == 1)
                    sql = sql + " AND ";
                sql = sql + " UserId='" + obj.Userid + "' ";
                flag = 1;
            }
			
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public AdmUserpermissionEntity GetSingleAdmUserpermissionRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, UserId, SubFeatureId, AccessLevel, CreatedBy, CreatedDate, UpdateBy, UpdateDate FROM ADM_UserPermission WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			AdmUserpermissionEntity admUserpermissionEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					admUserpermissionEntity = new AdmUserpermissionEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						admUserpermissionEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["UserId"] != DBNull.Value)
					{
						admUserpermissionEntity.Userid = dataReader["UserId"].ToString();
					}
					if (dataReader["SubFeatureId"] != DBNull.Value)
					{
						admUserpermissionEntity.Subfeatureid = dataReader["SubFeatureId"].ToString();
					}
					if (dataReader["AccessLevel"] != DBNull.Value)
					{
						admUserpermissionEntity.Accesslevel = dataReader["AccessLevel"].ToString();
					}
					if (dataReader["CreatedBy"] != DBNull.Value)
					{
						admUserpermissionEntity.Createdby = dataReader["CreatedBy"].ToString();
					}
					if (dataReader["CreatedDate"] != DBNull.Value)
					{
						admUserpermissionEntity.Createddate = dataReader["CreatedDate"].ToString();
					}
					if (dataReader["UpdateBy"] != DBNull.Value)
					{
						admUserpermissionEntity.Updateby = dataReader["UpdateBy"].ToString();
					}
					if (dataReader["UpdateDate"] != DBNull.Value)
					{
						admUserpermissionEntity.Updatedate = dataReader["UpdateDate"].ToString();
					}
				}
			}
			return admUserpermissionEntity;
		}

		#endregion

	}
}

