using System.Data;
using System.Data.Common;
using SalesForce.Domain.Admin;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace SalesForce.Server.DAL.Inventory
{
    public partial class AdmUserpermissionDAL
    {
        public DataTable GetAllAdmUserpermissionRecord(object param)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT A.ID, A.UserId, B.UserId, SubFeatureId, AccessLevel, A.CreatedBy, A.CreatedDate, A.UpdateBy, A.UpdateDate FROM ADM_UserPermission A, ADM_USER B where (B.UserId = A.UserId)";

            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;

            if (obj != null)
            {
                if (obj.Userid != null && obj.Userid != "")
                {
                    sql = sql + "AND A.UserId= '" + obj.Userid + "' ";
                }
            }

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }


        public DataTable GetAllAdmUserpermissionDetail(object param)
        {
            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT A.ID MasterID,B.TabId, B.ID,B.URL  SubFetURL, ModuleName,TabName,A.URL TabURL,SubFeatureName,QuickLink FROM  ADM_MasterFeature A, ADM_SubFeature B where ( A.ID = B.TabId ) and A.IsActive=1 ";

            if (obj != null)
            {
                if (obj.ModuleName != null && obj.ModuleName != "")
                {
                    sql = sql + "AND ModuleName= '" + obj.ModuleName + "' ";
                }

                if (obj.TabId != null && obj.TabId != "" && obj.TabId != "null")
                {
                    sql = sql + " and B.TabId= '" + obj.TabId + "' ";
                }

                if (obj.TabName != null && obj.TabName != "" && obj.TabName != "null")
                {
                    sql = sql + " and TabName = '" + obj.TabName + "' ";
                }

                if (obj.TabName != null && obj.TabName != "" && obj.TabName != "null")
                {
                    sql = sql + " ORDER BY B.SL ASC ";
                }

                else
                    sql = sql + " ORDER BY A.SL ASC ";
            }

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public DataTable GetAllAdmUserpermissionDetail_UserWise(object param)
        {
            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT A.ID MasterID,B.TabId, B.ID,B.URL  SubFetURL, ModuleName,TabName,A.URL TabURL,SubFeatureName,QuickLink FROM  ADM_MasterFeature A, ADM_SubFeature B where ( A.ID = B.TabId )and A.IsActive=1 ";

            if (obj != null)
            {
                if (obj.ModuleName != null && obj.ModuleName != "")
                {
                    sql = sql + "AND A.ModuleName= '" + obj.ModuleName + "' ";
                }

                if (obj.TabName != null && obj.TabName != "" && obj.TabName != "null")
                {
                    sql = sql + "AND TabName= '" + obj.TabName + "' ";
                }

                if (obj.TabId != null && obj.TabId != "" && obj.TabId != "null")
                {
                    sql = sql + " and B.TabId= '" + obj.TabId + "' ";
                }


                sql = sql + "AND B.RollId= '" + obj.Role + "' ";
                



                if (obj.TabName != null && obj.TabName != "" && obj.TabName != "null")
                {
                    sql = sql + " ORDER BY B.SL ASC ";
                }


                else
                    sql = sql + " ORDER BY A.SL ASC ";
            }

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public DataTable GetAllAdmPermitedModuleList(object param)
        {
            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            string sql = "SELECT distinct(ModuleName) ModuleName,ModuleSortBy ";
            if (!obj.isAdmin || obj.Role==1)
            {
                //sql = sql + "FROM  ADM_MasterFeature A, ADM_SubFeature B, ADM_UserPermission C where A.ID = B.TabId and C.SubFeatureId=B.ID ";
                //sql = sql + " and C.UserId ='" + obj.Userid + "'";
                sql = sql + "from ADM_MasterFeature M left join ADM_SubFeature S on M.ID=s.TabId where RollId=1 ";
                
            }
            else
            {
                sql = sql + "FROM  ADM_MasterFeature A, ADM_SubFeature B where A.ID = B.TabId ";
            }


            sql = sql + " order by ModuleSortBy ";


            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public DataTable UserLogon(object param)
        {

            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
            Database db = DatabaseFactory.CreateDatabase();

            string sql = @"SELECT A.ID, UserId,UserPassword Password, A.EmpId, UserType,UserName EmpName,Email, RollId 
From ADM_User A where A.UserId='" + obj.Userid + "' AND UserPassword='" + obj.password + "'";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

        public string PasswordChange(object param)
        {

            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
            Database db = DatabaseFactory.CreateDatabase();

            string sql = "UPDATE ADM_User SET Password=@newPassword OUTPUT INSERTED.Password WHERE Id=@Id and Password=@password";
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            db.AddInParameter(dbCommand, "Id", DbType.String, obj.Id);
            db.AddInParameter(dbCommand, "password", DbType.String, obj.password);
            db.AddInParameter(dbCommand, "newPassword", DbType.String, obj.newPassword);
            string password = (string)db.ExecuteScalar(dbCommand);
            return password;
        }

        public DataTable GetNotificationUserWise(object param)
        {
            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
            Database db = DatabaseFactory.CreateDatabase();
            string sql = @"select * from (
                    select 'QUT' Title,count(*) Counts,'Check Quation' Header, cast(count(*) as nvarchar(50))+' Quotation is pending for check' Details,
                    '~/MERC/OrderBooking/CheckPreCosting' TargetURL 
                    from MERC_CostingMaster where isnull(SubmittedStatus,0)=1 and isnull(ApproveStatus,0)=0
                    union
                    select 'QUT' Title,count(*) Counts,'Approve Quation' Header, cast(count(*) as nvarchar(50))+' Quotation is pending for Approve' Details,
                    '~/MERC/OrderBooking/ApprovePreCosting' TargetURL 
                    from MERC_CostingMaster where isnull(SubmittedStatus,0)=1 and isnull(ApproveStatus,0)=1 and isnull(ApproveStatusMD,0)=0
                    union
                    select 'FAB' Title,count(*) Counts,'Check Fabric Work Order' Header, cast(count(*) as nvarchar(50))+' Fabric Work Order is pending for Check' Details,
                    '~/MERC/OrderSheet/CheckFabricWorkOrder' TargetURL 
                    from MERC_KinttingSheetMaster where isnull(Submitstatus,0)=1 and isnull(ApproveStatus,0)=1 and isnull(CheckStatus,0)=0
                    union
                    select 'FAB' Title,count(*) Counts,'Approve Fabric Work Order' Header, cast(count(*) as nvarchar(50))+' Fabric Work Order is pending for Approve' Details,
                    '~/MERC/OrderSheet/ApproveFabricWorkOrder' TargetURL 
                    from MERC_KinttingSheetMaster where isnull(Submitstatus,0)=1 and isnull(ApproveStatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(ApproveStatus,0)=0 
                    union
                    select 'WO' Title,count(*) Counts,'Check Work Order' Header, cast(count(*) as nvarchar(50))+' Work Order is pending for Check' Details,
                    '~/MERC/WorkOrder/WorkOrderListCheckBy' TargetURL 
                    from MERC_WorkOrderMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=0 
                    union
                    select 'WO' Title,count(*) Counts,'Check(Acc Head) Work Order' Header, cast(count(*) as nvarchar(50))+' Work Order is pending for Check (Account Head)' Details,
                    '~/MERC/WorkOrder/WorkOrderListAccHead' TargetURL 
                    from MERC_WorkOrderMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=0 
                    union
                    select 'WO' Title,count(*) Counts,'Check(MSC) Work Order' Header, cast(count(*) as nvarchar(50))+' Work Order is pending for Check (MSC)' Details,
                    '~/MERC/WorkOrder/WorkOrderListMSC' TargetURL 
                    from MERC_WorkOrderMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=1 and isnull(CheckMSCStatus,0)=0
                    union
                    select 'WO' Title,count(*) Counts,'Check(Accounts) Work Order' Header, cast(count(*) as nvarchar(50))+' Work Order is pending for Check (Accounts)' Details,
                    '~/MERC/WorkOrder/WorkOrderListAccounts' TargetURL 
                    from MERC_WorkOrderMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=1 and isnull(CheckMSCStatus,0)=1 and isnull(CheckAccStatus,0)=0 
                    union
                    select 'WO' Title,count(*) Counts,'Approve Work Order' Header, cast(count(*) as nvarchar(50))+' Work Order is pending for Approve' Details,
                    '~/MERC/WorkOrder/WorkOrderListApprove' TargetURL 
                    from MERC_WorkOrderMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=1 and isnull(CheckMSCStatus,0)=1 and isnull(CheckAccStatus,0)=1 and isnull(ApproveStatus,0)=0 
                    union
                    select 'YB' Title,count(*) Counts,'Check Yarn Booking' Header, cast(count(*) as nvarchar(50))+' Yarn Booking is pending for Check' Details,
                    '~/MERC/Booking/YarnBookingCheck' TargetURL 
                    from MERC_YarnBookingMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=0 
                    union
                    select 'YB' Title,count(*) Counts,'Check(Acc Head) Yarn Booking' Header, cast(count(*) as nvarchar(50))+' Yarn Booking is pending for Check (Account Head)' Details,
                    '~/MERC/Booking/YarnBookingCheckAccHead' TargetURL 
                    from MERC_YarnBookingMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=0 
                    union
                    select 'YB' Title,count(*) Counts,'Check(Accounts) Yarn Booking' Header, cast(count(*) as nvarchar(50))+' Yarn Booking is pending for Check (Accounts)' Details,
                    '~/MERC/Booking/YarnBookingCheckAccounts' TargetURL 
                    from MERC_YarnBookingMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=1  and isnull(CheckAccStatus,0)=0 
                    union
                    select 'YB' Title,count(*) Counts,'Approve Yarn Booking' Header, cast(count(*) as nvarchar(50))+' Yarn Booking is pending for Approve' Details,
                    '~/MERC/Booking/YarnBookingApprove' TargetURL 
                    from MERC_YarnBookingMaster where isnull(Submitstatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(CheckAcHeadStatus,0)=1  and isnull(CheckAccStatus,0)=1 and isnull(ApproveStatus,0)=0 
                    union
                    select 'YB' Title,count(*) Counts,'Approved Yarn Booking' Header, cast(count(*) as nvarchar(50))+'Approved Yarn Booking' Details,
                    '~/MERC/Booking/yarnbookingstatus' TargetURL 
                    from MERC_YarnBookingMaster where isnull(ApproveStatus,0)=1 
                    union
                    select 'BGT' Title,count(*) Counts,'Check Budget' Header, cast(count(*) as nvarchar(50))+' Budget is pending for Check' Details,
                    '~/MERC/Budget/CheckBudget' TargetURL 
                    from MERC_BudgetMaster A where isnull(A.SubmittedStatus,0)=1 and isnull(CheckStatus,0)=0 
                    union
                    select 'BGT' Title,count(*) Counts,'Check Budget(Acc Head)' Header, cast(count(*) as nvarchar(50))+' Budget is pending for Check(Account Head)' Details,
                    '~/MERC/Budget/ApproveBudget' TargetURL 
                    from MERC_BudgetMaster A where isnull(A.SubmittedStatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(ApproveStatus,0)=0
                    union
                    select 'BGT' Title,count(*) Counts,'Approve Budget' Header, cast(count(*) as nvarchar(50))+' Budget is pending for Approve' Details,
                    '~/MERC/Budget/ApproveBudgetMD' TargetURL 
                    from MERC_BudgetMaster A where isnull(A.SubmittedStatus,0)=1 and isnull(CheckStatus,0)=1 and isnull(ApproveStatus,0)=1 and isnull(ApproveStatusMD,0)=0 
     
                    ) AA where Counts>0 ";

            if (obj != null)
            {
                if (obj.Userid != null && obj.Userid != "" && obj.Userid != "null")
                {
                    sql = sql + @"and TargetURL in(select distinct B.URL SubFetURL 
from ADM_SubFeature B,ADM_UserPermission C   
where C.SubFeatureId=B.ID and C.UserId='" + obj.Userid + "')";
                }
            }

            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            DataSet ds = db.ExecuteDataSet(dbCommand);
            return ds.Tables[0];
        }

    }
}

