using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmUserBLL
	{
		public object GetAllAdmUserRecord(object param)
		{
			object retObj = null;
			AdmUserDAL admUserDAL = new AdmUserDAL();
			retObj = (object)admUserDAL.GetAllAdmUserRecord(param);
			return retObj;
		}

	}
}

