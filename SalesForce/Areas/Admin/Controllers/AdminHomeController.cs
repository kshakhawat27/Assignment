using System.Web.Mvc;

namespace SalesForce.Areas.Admin.Controllers
{
    public class AdminHomeController : SalesForce.Controllers.BaseController
    {

        public ActionResult Index()
        {
            GetModuleWiseTabList(Structure.Module.Admin, Session["UserId"].ToString(),"ADM");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Dashboard";
            return View();
        }
        //
        // GET: /POS/POSHome/

        //public ActionResult Index()
        //{
        //    if (Session["UserId"] == null)
        //        return RedirectToAction("Login", "../Account");

        //    CurrentModule = "POS";
        //    GetUserPermission("POS");

        //    ViewData["PageHeader"] = "EIMS";
        //    GetModuleWiseTabList("POS", Session["UserId"].ToString());
        //    GetUserNotification();

        //    HmResarvationEntity master = new HmResarvationEntity();
        //    master.CurrentRoomStatus = true;
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.POS, ERPTask.AG_GetAllHmResarvationRecord, master);
        //    HmGuestdetailsEntity iSet = new HmGuestdetailsEntity();
        //    List<HmGuestdetailsEntity> ItemList = null;
        //    ItemList = new List<HmGuestdetailsEntity>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //ArrivalDate
        //        iSet = new HmGuestdetailsEntity();
        //        iSet.Roomid = dr["RoomNo"].ToString();
        //        if (dr["GuestName"].ToString() != "")
        //        {
        //            iSet.Firstname = "Name: " + dr["GuestName"].ToString().Replace(",", "/");
        //            iSet.Nationality = "Nationality: " + dr["CountryName"].ToString();
        //            iSet.Visano = "Check In: " + dr["ArrivalDate"].ToString();
        //            iSet.Visaissuedfrom = "Check Out: " + dr["DepartureDate"].ToString();
        //        }
        //        else
        //    iSet.Firstname = "";
        //    ItemList.Add(iSet);
        //    }
        //    CommonClassForListPage iset = new CommonClassForListPage();
        //    iset.RoomAndGuestList = ItemList;
        //    return View(iset);
        //}

        //public void GetUserNotification()
        //{
        //    PosRequisitionmasterEntity obj = new PosRequisitionmasterEntity();
        //    obj.GetUserNotification = true;
        //    if (CurrentUserType != UserAccessType.SysAdmin)
        //    {
        //        obj.Userid = CurrentUserId;
        //        obj.Reqfor = LogedLineID;
        //    }
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.POS, ERPTask.AG_GetAllPosRequisitionmasterRecord, obj);

        //    List<FeatureName> NotificationList = new List<FeatureName>();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        NotificationList.Add(new FeatureName()
        //        {
        //            Id = dr["Title"].ToString(),
        //            Name = dr["Header"].ToString(),
        //            ControlerName = dr["Details"].ToString(),
        //            FeatureURL = dr["TargetURL"].ToString().Replace("~", ""),
        //        });
        //    }
        //    Session["ERP_Notification_Count"] = NotificationList.Count;
        //    Session["ERP_Notification_List"] = NotificationList;
        //}
    }
}
