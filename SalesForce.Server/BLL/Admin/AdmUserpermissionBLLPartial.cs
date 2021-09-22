using SalesForce.Domain.Admin;
using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmUserpermissionBLL
	{
		public object GetAllAdmUserpermissionRecord(object param)
		{
            AdmUserpermissionEntity obj = (AdmUserpermissionEntity)param;
			object retObj = null;
			AdmUserpermissionDAL admUserpermissionDAL = new AdmUserpermissionDAL();

            if(obj.GetAllAdmUserpermissionRecord)
                retObj = (object)admUserpermissionDAL.GetAllAdmUserpermissionRecord(param);
            else if(obj.GetAllAdmUserpermissionDetail)
                retObj = (object)admUserpermissionDAL.GetAllAdmUserpermissionDetail(param);
            else if (obj.GetAllAdmUserpermissionDetail_UserWise)
                retObj = (object)admUserpermissionDAL.GetAllAdmUserpermissionDetail_UserWise(param);
            else if (obj.UserLogon)
                retObj = (object)admUserpermissionDAL.UserLogon(param);
            else if (obj.PermittedModule)
                retObj = (object)admUserpermissionDAL.GetAllAdmPermitedModuleList(param);

            else if (obj.passwordChange)
                retObj = (object)admUserpermissionDAL.PasswordChange(param);

            else if (obj.GetUserNotification)
                retObj = (object)admUserpermissionDAL.GetNotificationUserWise(param);
            return retObj;
		}

	}
}

