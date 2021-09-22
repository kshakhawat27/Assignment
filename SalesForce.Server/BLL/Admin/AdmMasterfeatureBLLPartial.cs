using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmMasterfeatureBLL
	{
		public object GetAllAdmMasterfeatureRecord(object param)
		{
			object retObj = null;
			AdmMasterfeatureDAL admMasterfeatureDAL = new AdmMasterfeatureDAL();
			retObj = (object)admMasterfeatureDAL.GetAllAdmMasterfeatureRecord(param);
			return retObj;
		}

	}
}

