using Newtonsoft.Json;

using SalesForce.Domain.Admin;
using SalesForce.Structure;
using System;
using System.Data;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SalesForce.Areas.Admin.Controllers
{
    public class SettingsController : AdmBaseController
    {
        // GET: Admin/Settings
        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult EditPersonalInfo()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Admin, "Settings", "CompanyCategory");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Company Category";
            Session["PageHeader"] = "Company Category";
            ViewData["IsActiveList"] = GetIsActiveList();
            return View();
        }
        public ActionResult EmployeeList()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Admin, "Settings", "CompanyCategory");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Company Category";
            Session["PageHeader"] = "Company Category";
            ViewData["IsActiveList"] = GetIsActiveList();
            return View();
        }

        public ActionResult Attendance()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Admin, "Settings", "CompanyCategory");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Company Category";
            Session["PageHeader"] = "Company Category";
            ViewData["IsActiveList"] = GetIsActiveList();
            return View();
        }

        [HttpPost]
        public JsonResult AddUpdateUserAttendace(string Status)
        {
            try
            {
                AttendanceModel regionModel = new AttendanceModel();
                string Message1 = "";
                bool isUpdate = false;
                regionModel.Startdatetime = DateTime.Now.ToString();
                regionModel.Employeeid = Session["UserId"].ToString();
                regionModel.Createdby = Session["UserId"].ToString();
                regionModel.Createddate = DateTime.Today.Date.ToString("dd/MM/yyyy");
                regionModel.flag = "Attendance";

                if (Status == "")
                {
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveAttendanceInfo, regionModel);
                    Message1 = "Attendance Successfully Given";
                }
                else
                {
                    regionModel.Enddatetime = DateTime.Now.ToString();
                    regionModel.Employeeid = Session["UserId"].ToString();
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateAttendanceInfo, regionModel);
                    Message1 = "Successfully finished today's job";
                }
                if (isUpdate)
                {

                    return Json(new { Success = true, Message = Message1 });
                }

                return Json(new { Success = false, Message = "Failed" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }


    }
}