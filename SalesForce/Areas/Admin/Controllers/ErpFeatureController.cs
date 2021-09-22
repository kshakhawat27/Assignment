using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web.Mvc;
using SalesForce.Domain.Admin;
using SalesForce.Structure;

namespace SalesForce.Areas.Admin.Controllers
{
    public class ErpFeatureController : AdmBaseController
    {
        // GET: Admin/ErpFeature

        #region MasterTab

        public ActionResult MasterTab()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Admin, "Tab Features", "MasterTab");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Master Features";

            Session["PageHeader"] = "Master Features";
            ViewData["ModuleList"] = ModuleList();
            List<SelectListItem> type = new List<SelectListItem>();
            ViewData["TabNameList"] = type;
            return View();
        }


        [HttpPost]
        public JsonResult GetTabList(string moduleName = "")
        {
            AdmMasterfeatureEntity obj = new AdmMasterfeatureEntity();

            if (moduleName != "0")
                obj.Modulename = moduleName;

            else
                obj = null;


            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmMasterfeatureRecord, obj);

            int iCount = 1;
            string TableData = "", Edit = "", Delete = "", Status = "";
            foreach (DataRow dr in dt.Rows)
            {
                Edit = "<i onclick=\"OpenPopupModel('" + dr["ID"] + "');\" title='Edit This' class='md-icon md-24 material-icons md-color-orange-400'>&#xE254;</i>";

                TableData = TableData + "<tr>"
                                      + "<td>" + Edit + " " + Delete + "</td>"
                                      + "<td>" + dr["ModuleName"] + "</td>"
                                      + "<td>" + dr["TabName"] + "</td>"
                                      + "<td>" + dr["URL"] + "</td>"
                                      + "<td>" + dr["SL"] + "</td>"
                                      + "</tr>";

                iCount += 1;
            }
            string tHead = "<tr><th>Actions</th><th>Module Name</th><th>Tab Name</th><th>Url</th><th>SL/Order</th></tr>";
            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleMasterFeatureById(string Id)
        {
            AdmMasterfeatureEntity iGet = (AdmMasterfeatureEntity)ExecuteDB(ERPTask.AG_GetSingleAdmMasterfeatureRecordById, Id);
            return Json(iGet);
        }

        public JsonResult AddUpdateMasterFeatureRecord(AdmMasterfeatureEntity iSet)
        {
            try
            {
                bool issave = false;
                if (iSet.Id != null && iSet.Id == "0")
                {
                    issave = (bool)ExecuteDB(ERPTask.AG_SaveAdmMasterfeatureInfo, iSet);
                }
                else
                {
                    issave = (bool)ExecuteDB(ERPTask.AG_UpdateAdmMasterfeatureInfo, iSet);
                }
                if (issave)
                {
                    return Json(new { Success = true, Msg = "Successfully Recorded" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Success = false, Msg = "Failed To Record" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        #region SubTab

        public ActionResult SubTab()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Admin, "Tab Features", "SubTab");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Sub Features";

            Session["PageHeader"] = "Sub Features";
            ViewData["ModuleList"] = ModuleList();
            List<SelectListItem> type = new List<SelectListItem>();
            ViewData["TabNameList"] = type;
            return View();
        }

        [HttpPost]
        public JsonResult GetSubTabList(string moduleName = "", string tabName = "")
        {
            if (tabName == "null")
                tabName = "";

            AdmSubfeatureEntity obj = new AdmSubfeatureEntity
            {
                ModuleName = moduleName,
                Tabid = tabName
            };
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmSubfeatureRecord, obj);

            int iCount = 1;
            string TableData = "", Edit = "", Delete = "";

            foreach (DataRow dr in dt.Rows)
            {
                Edit = "<i onclick=\"OpenPopupModel('" + dr["ID"] + "');\" title='Edit This' class='md-icon md-24 material-icons md-color-orange-400'>&#XE254;</i>";
                Delete = "<i onclick=\"DeleteTab('" + dr["ID"] + "');\" title='Delete This' class='md-icon md-24 material-icons md-color-red-400'>&#XE872;</i>";

                TableData = TableData + "<tr>"
                                      + "<td>" + Edit + " " + Delete + "</td>"
                                      + "<td>" + dr["ModuleName"] + "</td>"
                                      + "<td>" + dr["TabName"] + "</td>"
                                      + "<td>" + dr["SubFeatureName"] + "</td>"
                                      + "<td>" + dr["URL"] + "</td>"
                                      + "<td>" + dr["QuickLink"] + "</td>"
                                      + "<td>" + dr["SL"] + "</td>"
                                      + "</tr>";

                iCount += 1;
            }
            string tHead = "<tr><th>Actions</th><th>Module Name</th><th>Tab Name</th><th>Feature Name</th><th>Url</th><th>Quick Link</th><th>SL/Order</th></tr>";
            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleSubFeatureById(string Id)
        {
            AdmSubfeatureEntity iGet = (AdmSubfeatureEntity)ExecuteDB(ERPTask.AG_GetSingleAdmSubfeatureRecordById, Id);
            return Json(iGet);
        }
        //AddUpdateSubFeatureInfo
        public JsonResult AddUpdateSubFeatureInfo(AdmSubfeatureEntity iSet)
        {
            try
            {
                bool issave = false;
                if (iSet.Id != null && iSet.Id == "0")
                {
                    issave = (bool)ExecuteDB(ERPTask.AG_SaveAdmSubfeatureInfo, iSet);
                }
                else
                {
                    issave = (bool)ExecuteDB(ERPTask.AG_UpdateAdmSubfeatureInfo, iSet);
                }
                if (issave)
                {
                    return Json(new { Success = true, Msg = "Successfully Recorded" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Success = false, Msg = "Failed To Record Data" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteSubTabById(string ID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteAdmSubfeatureInfoById, ID);
                if (isUpdate)
                    return Json(new { Success = true, Message = "Successfully Deleted" });
                return Json(new { Success = false, Message = "Failed" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        #endregion
    }
}