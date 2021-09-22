using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Web.Mvc;
using SalesForce.Domain.Admin;
using SalesForce.Structure;

namespace SalesForce.Areas.Admin.Controllers
{
    public class UserManagementController : AdmBaseController
    {

        // GET: Admin/ManageEmployee
        public ActionResult UserInfo()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Account");
            //M_GetModuleWiseTabList(Module.Admin, "User Management", "User");
            M_GetModuleWiseTabList(Module.Admin, "User Management", "UserInfo");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "User";
            ViewData["PageHeader"] = "User Information";


            EmployeeModel Iset = new EmployeeModel();
            Iset.Id = 0;
            return View(Iset);
        }

        [HttpPost]
        public JsonResult GetUserList()
        {
            try
            {
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserRecord, null);
                List<EmployeeModel> itemList = new List<EmployeeModel>();

                int iCount = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    itemList.Add(new EmployeeModel()
                    {
                        SL = iCount + 1,
                        Id =Convert.ToInt32(dr["ID"]),
                        Employeeidno = dr["EmployeeIdNo"].ToString(),
                        Firstname = dr["FirstName"].ToString(),
                        Lastname = dr["LastName"].ToString(),
                        Joiningdate = dr["JoiningDate"].ToString(),
                        Email = dr["Email"].ToString(),
                        Department = dr["Department"].ToString(),
                        Designaton = dr["Designaton"].ToString(),
                   
                   
                    });


                    iCount += 1;
                }
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult AddUpdateUserInfo(EmployeeModel regionModel)
        {
            try
            {
                bool isUpdate = false;
                regionModel.Createdby = Session["UserId"].ToString();
                regionModel.Createddate = DateTime.Today.Date.ToString("dd/MM/yyyy");

                if (/*regionModel.Id == null || */regionModel.Id == 0)
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_SaveAdmUserInfo, regionModel);
                else
                    isUpdate = (bool)ExecuteDB(ERPTask.AG_UpdateAdmUserInfo, regionModel);
                if (isUpdate)
                {

                    return Json(new { Success = true, Message = "Successfully Saved" });
                }

                return Json(new { Success = false, Message = "Failed" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        [HttpPost]
        public JsonResult GetSingleAdmUserRecordById(int Id)
        {
            EmployeeModel Iset = new EmployeeModel();         
            if (Id == 0)
            {
                Iset.Employeeidno = CurrentUserId;
            }
            else Iset.Id = Id;
            //Iset.Employeeidno = Id;
            EmployeeModel dt = (EmployeeModel)ExecuteDB(ERPTask.AG_GetSingleAdmUserRecordById, Iset);
            return Json(dt, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteAdmUserInfoById(string ID)
        {
            try
            {
                Thread.Sleep(50);
                bool isUpdate = false;
                isUpdate = (bool)ExecuteDB(ERPTask.AG_DeleteAdmUserInfoById, ID);
                if (isUpdate)
                    return Json(new { Success = true, Message = "Successfully Deleted" });
                return Json(new { Success = false, Message = "Failed" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }


        public ActionResult UserPermission()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            //M_GetModuleWiseTabList("Admin", "UserManagement", "UserPermission");
            //ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "User Permission";

            M_GetModuleWiseTabList(Module.Admin, "User Management", "UserPermission");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "User Information";

            Session["PageHeader"] = "User Permission";

            List<SelectListItem> type = new List<SelectListItem>();
            ViewData["TabIdList"] = type;
            ViewData["ModuleList"] = ModuleList();
            ViewData["UserListSelect"] = GetUserListSelect();

            AdmUserpermissionEntity uP = new AdmUserpermissionEntity();
            uP.Id = "0";
            return View(uP);
        }
        public List<SelectListItem> GetUserListSelect()
        {
            List<SelectListItem> Result = new List<SelectListItem>();
            Result.Add(new SelectListItem()
            {
                Text = "Select...",
                Value = "",
                Selected = true
            });

            List<AdmUserEntity> itemList = GetUserListObj();
            foreach (AdmUserEntity dr in itemList)
            {
                Result.Add(new SelectListItem()
                {
                    Text = dr.UserName,
                    Value = dr.Id
                });
            }
            return Result;
        }
        public List<AdmUserEntity> GetUserListObj(string Id = "")
        {
            AdmUserEntity iSet = new AdmUserEntity();
            iSet.Id = Id;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserRecord, iSet);
            List<AdmUserEntity> itemList = new List<AdmUserEntity>();

            int iCount = 0;

            foreach (DataRow dr in dt.Rows)
            {
                itemList.Add(new AdmUserEntity()
                {
                    SL = iCount + 1,
                    Id = dr["ID"].ToString(),
                    UserId = dr["UserId"].ToString(),
                    UserPassword = dr["UserPassword"].ToString(),
                    UserName = dr["UserName"].ToString(),
                    Dob = dr["Dob"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    JoiningDate = dr["JoiningDate"].ToString(),
                    ContactNo = dr["ContactNo"].ToString(),
                    Email = dr["Email"].ToString(),
                });


                iCount += 1;
            }
            return itemList;
        }
        [HttpPost]
        public JsonResult GetUserListbyID(string Id = "")
        {
            List<AdmUserEntity> itemList = GetUserListObj(Id);
            return Json(itemList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetUserListData(string eID = "")
        {

            AdmUserEntity objR = new AdmUserEntity();
            objR.Id = eID;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserRecord, objR);

            string liStart = "<li>";
            string liEnd = "</li>";
            string aLinkStart = "<a ";
            string aLinkClass = "class='md-list-content' data-invoice-id='2'>";
            string aLinkEnd = "</a>";

            string spanIndicate = "<span class='uk-badge uk-badge-primary'>";
            string spanMain = "<span class='md-list-heading uk-text-truncate'>";
            string spanSmall = "<span class='uk-text-small uk-text-muted'>";
            string spanEnd = "</span>";
            string strProgramList = "";
            string strTemp = "";

            foreach (DataRow dr in dt.Rows)
            {
                strTemp = liStart + aLinkStart;
                strTemp = strTemp + " href='javascript:CallReqDataForEdit(" + dr["UserId"].ToString() + ")' ";
                strTemp = strTemp + aLinkClass;
                strTemp = strTemp + spanMain;
                strTemp = strTemp + "UserId : " + dr["UserId"].ToString();
                //strTemp = strTemp + spanSmall;
                //strTemp = strTemp + "(" + dr["Quantity"].ToString() + ")";
                //strTemp = strTemp +  spanEnd;
                strTemp = strTemp + spanEnd;
                strTemp = strTemp + spanSmall;
                strTemp = strTemp + "Name : " + dr["UserName"].ToString();
                strTemp = strTemp + spanEnd;
                //strTemp = strTemp + spanSmall;
                //strTemp = strTemp + "Line :" + dr["EmpName"].ToString();
                //strTemp = strTemp + spanEnd;
                strTemp = strTemp + aLinkEnd;
                strTemp = strTemp + liEnd;

                strProgramList = strProgramList + strTemp;
                strTemp = "";
            }
            //PosProductnameEntity bMaster = new PosProductnameEntity();
            AdmUserEntity bMaster = new AdmUserEntity();
            bMaster.DataLists = strProgramList;
            return Json(bMaster);
        }

        [HttpPost]
        public JsonResult GetExistingUserData(string pId)
        {
            //AdmUserEntity iGet = (AdmUserEntity)ExecuteDB(ERPTask.AG_GetSingleAdmUserRecordById, pId);
            AdmUserEntity objR = new AdmUserEntity();
            objR.UserId = pId;
            AdmUserEntity iGetUser = (AdmUserEntity)ExecuteDB(ERPTask.AG_GetSingleAdmUserRecordById, objR);
            if (iGetUser != null)
            {
                objR.UserId = iGetUser.UserId;
                objR.UserPassword = iGetUser.UserPassword;
                objR.UserName = iGetUser.UserName;
            }

            return Json(objR);
        }

        [HttpPost]
        public ActionResult TabList(string id)
        {
            try
            {
                return Json(getModuleName(id));
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult PermissionDetails(string ModuleName = "", string Tabid = "", string UserId = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                if ((ModuleName == "" && Tabid == "") || ModuleName == "")
                {
                    return Json(new { Result = "ERROR", Message = "Please select module name" });
                }
                AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
                string status = "Not Permitted";
                obj.GetAllAdmUserpermissionRecord = true;
                obj.Userid = UserId;
                //obj.Userid = UserId;
                DataTable check = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserpermissionRecord, obj);

                obj.GetAllAdmUserpermissionRecord = false;
                obj.Userid = "";
                obj.ModuleName = ModuleName;
                obj.TabId = Tabid;
                obj.GetAllAdmUserpermissionDetail = true;
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserpermissionRecord, obj);
                List<AdmUserpermissionEntity> ItemList = null;
                ItemList = new List<AdmUserpermissionEntity>();

                int iCount = 0;
                //int offset = 0;

                //offset = jtStartIndex / jtPageSize;

                foreach (DataRow dr in dt.Rows)
                {
                    string Alevel = "";
                    foreach (DataRow row in check.Select("SubFeatureId='" + dr["ID"].ToString() + "'"))
                    {
                        status = "Permitted";
                        Alevel = string.IsNullOrEmpty(row["AccessLevel"].ToString()) ? "1" : row["AccessLevel"].ToString();
                        Alevel = (Alevel == "1") ? "Full" : "Read";
                    }

                    //if (iCount >= jtStartIndex && iCount < (jtPageSize * (offset + 1)))
                    //{
                    ItemList.Add(new AdmUserpermissionEntity()
                    {
                        SL = iCount + 1,
                        Id = dr["ID"].ToString(),
                        ModuleName = dr["ModuleName"].ToString(),
                        TabName = dr["TabName"].ToString(),
                        SubFeature = dr["SubFeatureName"].ToString(),
                        status = status,
                        Accesslevel = Alevel
                    });
                    //}
                    status = "Not Permitted";
                    iCount += 1;
                }
                var RecordCount = dt.Rows.Count;
                var Record = ItemList;
                return Json(new { Result = "OK", Records = Record, TotalRecordCount = RecordCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public JsonResult DeletePermissionSingle(string data, string userId)
        {
            try
            {
                AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
                obj.Subfeatureid = data;
                obj.Userid = userId;
                ExecuteDB(ERPTask.AG_DeleteAdmUserpermissionInfoById, obj);

                return Json(new { Success = true, Message = "Permission successfully save." });
            }

            catch (Exception e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }


        [HttpPost]
        public JsonResult SubmitPermission(string data, string userId)
        {
            try
            {
                string[] permission = data.Split(',');
                AdmUserpermissionEntity obj = new AdmUserpermissionEntity();

                for (int i = 0; i < permission.Length; i += 2)
                {
                    obj.Subfeatureid = permission[i];
                    obj.Accesslevel = permission[i + 1];
                    obj.Userid = userId;
                    ExecuteDB(ERPTask.AG_DeleteAdmUserpermissionInfoById, obj);
                    ExecuteDB(ERPTask.AG_SaveAdmUserpermissionInfo, obj);
                }
                return Json(new { Success = true, Message = "Permission successfully save." });

            }

            catch (Exception e)
            {
                return Json(new { Success = false, Message = e.Message });
            }
        }

        public JsonResult DeletePermission(string data, string userId)
        {
            try
            {
                string[] permission = data.Split(',');
                AdmUserpermissionEntity obj = new AdmUserpermissionEntity();

                for (int i = 0; i < permission.Length; i++)
                {
                    obj.Subfeatureid = permission[i];
                    obj.Userid = userId;
                    ExecuteDB(ERPTask.AG_DeleteAdmUserpermissionInfoById, obj);
                }

                return Json(new { Success = true, Message = "Permission successfully save." });

            }

            catch (Exception e)
            {
                return Json(new { Success = false, Message = e.Message });
            }



        }
   
    }
}