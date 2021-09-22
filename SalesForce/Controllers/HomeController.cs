using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using SalesForce.Domain.Admin;

using SalesForce.Models;
using SalesForce.Structure;

namespace SalesForce.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            Session["PageHeader"] = "Pakiza VatTax";
            //Session["UserId"] = "2c7a06a2-49ff-4166-81cc-b43cd38a8d2b";
            GetUserPermittedModuleListNew();

            ViewBag.SrcMonthList = SrcMonthList();
            ViewBag.SrcYearList = SrcYearList();

            InvSuupplierEntity obj = new InvSuupplierEntity();
            obj.SrcMonth = DateTime.Now.Month.ToString();
            obj.SrcYear = DateTime.Now.Year.ToString();
            //iSet.SrcStartDate = DateTime.Now.Date.ToString("01/MM/yyyy");
            /*
                        if (CurrentUserType == UserAccessType.SysAdmin)
                            obj.DashboardShow = true;
                        else
                            obj.DashboardShow = false;
            */
           

            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(InvSuupplierEntity iSet)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            GetUserPermittedModuleListNew();

            ViewBag.SrcMonthList = SrcMonthList();
            ViewBag.SrcYearList = SrcYearList();



            /*if (CurrentUserType == UserAccessType.SysAdmin)
                iSet.DashboardShow = true;
            else
                iSet.DashboardShow = false;*/
            iSet.DashboardShow = true;
            iSet.DashboardFirst = true;

            //...... Get Dashboard Data
          


            return View(iSet);
        }
        public string GetSingleAdmUserRecordById(string Id)
        {
            AdmUserEntity Iset = new AdmUserEntity();
            Iset.UserId = Id;
            AdmUserEntity dt = (AdmUserEntity)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetSingleAdmUserRecordById, Iset);

            Session["UserName"] = dt.UserName;
            Session["LogedEmpGuID"] = dt.Id;

            return dt.Id;
        }

       


        

        [HttpGet]
        public ActionResult Login(LoginModel model)
        {
            ModelState.Clear();
            return View("Login", model);
        }

       
        [HttpPost]
        public ActionResult Login(string submit, LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == "ptvl@123" && model.UserName.ToUpper() == "ADMIN")
                {
                    SystemContact contactAd = new SystemContact();
                    contactAd.FirstName = "Admin";
                    contactAd.LastName = "Admin";
                    contactAd.EmpId = "001055";
                    contactAd.Id = "001055";
                    contactAd.UserType = UserAccessType.SysAdmin;
                    SetLoginSessionData(contactAd, false);
                    GetUserPermittedModuleListNew();
                    return RedirectToAction("Index", "Home");
                }
                else if (model.Password != "ptvl@123" && model.UserName.ToUpper() != "ADMIN")
                {

                    AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
                    SystemUser info = new SystemUser();
                    obj.Userid = model.UserName;
                    obj.password = model.Password;
                    obj.UserLogon = true;
                    SystemContact contactAd = new SystemContact();
                    DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserpermissionRecord, obj);

                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            contactAd.Id = dt.Rows[0]["UserId"].ToString();
                            contactAd.Id = dt.Rows[0]["UserId"].ToString();
                            contactAd.EmpId = dt.Rows[0]["EmpId"].ToString();
                            contactAd.Role = dt.Rows[0]["RollId"].ToString();
                            contactAd.FirstName = dt.Rows[0]["EmpName"].ToString();
                            contactAd.UserType = UserAccessType.ReadWrite;
                            info.UserName = dt.Rows[0]["UserId"].ToString(); ;
                            info.Password = dt.Rows[0]["Password"].ToString(); ;
                            info.Role = dt.Rows[0]["RollId"].ToString(); ;
                            contactAd.User = info;
                            Session["Role"]= dt.Rows[0]["RollId"].ToString();
                            SetLoginSessionData(contactAd, false);
                            GetUserPermittedModuleListNew();
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }

                else
                {
                    ModelState.AddModelError("UserName", "invalid username or password.");
                }

            }
            return View("Login", model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
    }
}