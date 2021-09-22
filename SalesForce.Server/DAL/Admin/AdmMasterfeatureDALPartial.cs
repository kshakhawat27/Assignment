using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmMasterfeatureDAL
    {
        public DataTable GetAllAdmMasterfeatureRecord(object param)
        {
            int flag = 0;
            AdmMasterfeatureEntity op = (AdmMasterfeatureEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT ID, ModuleName, TabName, URL, SL FROM ADM_MasterFeature where 1=1 ";

            if (op != null)
            {
                if (op.Modulename != null && op.Modulename != "")
                {
                    sql = sql + " and ModuleName='" + op.Modulename + "' ";
                }
                if (op.isDistinct)
                {
                    sql = "SELECT distinct(ModuleName)ModuleName FROM ADM_MasterFeature ";
                }
            }

            //sql = sql + " ORDER BY SL ASC";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

    }
}

