using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmSubfeatureDAL
	{
		public DataTable GetAllAdmSubfeatureRecord(object param)
        {
            AdmSubfeatureEntity op = (AdmSubfeatureEntity)param;
			Database db = DatabaseFactory.CreateDatabase();
            string sql = @"SELECT ADM_SubFeature.ID, TabId, ModuleName,TabName, SubFeatureName, ADM_SubFeature.URL, ADM_SubFeature.SL,isnull(QuickLink,'No')  QuickLink
                            FROM ADM_SubFeature,ADM_MasterFeature where ADM_SubFeature.TabId = ADM_MasterFeature.ID ";

            if (op != null)
            {
                if (op.Id != null && op.Id != "")
                {

                    sql = sql + "AND ADM_SubFeature.ID='" + op.Id + "' ";

                }

                if (op.ModuleName != null && op.ModuleName != "")
                {

                    sql = sql + "AND ModuleName='" + op.ModuleName + "' ";

                }

                if (op.Tabid != null && op.Tabid != "")
                {

                    sql = sql + "AND TabId= '" + op.Tabid + "' ";

                }
                             


            }

            sql = sql + " ORDER BY ADM_SubFeature.SL";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			DataSet ds = db.ExecuteDataSet(dbCommand);
			return ds.Tables[0];
		}

	}
}

