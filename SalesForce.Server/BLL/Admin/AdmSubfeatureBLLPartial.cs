using SalesForce.Server.DAL.Inventory;

namespace SalesForce.Server.BLL.Inventory
{
    public partial class AdmSubfeatureBLL
	{
		public object GetAllAdmSubfeatureRecord(object param)
		{
			object retObj = null;
			AdmSubfeatureDAL admSubfeatureDAL = new AdmSubfeatureDAL();
			retObj = (object)admSubfeatureDAL.GetAllAdmSubfeatureRecord(param);
			return retObj;
		}

	}
}

