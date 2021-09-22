using SalesForce.Domain.Admin;
using SalesForce.Models;
using SalesForce.Structure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;

namespace SalesForce.Controllers
{
    public class BaseController : Controller
    {
        public object ExecuteDB(string methodName, object param)
        {
            object retObject = ServerManager.GetTaskManager.Execute(Module.Admin, methodName, param);
            return retObject;
        }

        public void GetUserPermittedModuleListNew()
        {
            List<FeatureName> tempFeature = new List<FeatureName>();
            List<FeatureName> ModuleTabList = new List<FeatureName>();

            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
            if (CurrentUserId == "001055")
            {
                obj.isAdmin = true;
                obj.PermittedModule = true;
                
            }
            else
            {
                obj.isAdmin = false;
                obj.PermittedModule = true;
                obj.Userid = CurrentUserId;
                obj.Role = Role;

            }
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserpermissionRecord, obj);
            string ModName = "";

            foreach (DataRow dr in dt.Rows)
            {

                ModName = dr["ModuleName"].ToString();
                if (ModName == "SWOF")
                {
                    tempFeature.Add(new FeatureName()
                    {
                        Id = dr["ModuleName"].ToString().ToUpper(),
                        Name = ModName,
                        FeatureURL = "/Operations/SWOF"
                    });
                }
                else
                {
                    tempFeature.Add(new FeatureName()
                    {
                        Id = dr["ModuleName"].ToString().ToUpper(),
                        Name = ModName,
                        FeatureURL = "/" + dr["ModuleName"].ToString() + "/" + dr["ModuleName"].ToString() + "Home"
                    });
                }
            }


            Session["ERP_Dashboard"] = "1";
            Session["ERP_MainTab_List"] = tempFeature;
            Session["ERP_SubTab_List"] = ModuleTabList;
        }

        public void GetModuleWiseTabList(string ModuleName, string uID, string CurrentPageName = "")
        {
            List<FeatureName> tempFeature = new List<FeatureName>();
            List<FeatureName> ModuleSubTabList = new List<FeatureName>();

            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();

            DataTable dt;

            obj.ModuleName = ModuleName;

            if (uID == "001055")
                obj.GetAllAdmUserpermissionDetail = true;
            else
            {
                obj.Userid = uID;
                obj.Role = Role;
                obj.GetAllAdmUserpermissionDetail_UserWise = true;
            }
            //obj.GetAllAdmUserpermissionDetail = true;
            dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllAdmUserpermissionRecord, obj);

            foreach (DataRow dr in dt.Rows)
            {
                int flag = 0;

                foreach (FeatureName list in tempFeature)
                {

                    if (list.Name == dr["TabName"].ToString())
                        flag = 1;

                }

                if (flag != 1)
                {


                    tempFeature.Add(new FeatureName()
                    {
                        Id = dr["MasterID"].ToString(),
                        Name = dr["TabName"].ToString(),
                        FeatureURL = dr["TabUrl"].ToString().Replace("~", ""),
                    });
                    GetModuleSubTabListTabWise(uID, ModuleName, dr["TabName"].ToString(), ref ModuleSubTabList, CurrentPageName);
                }

            }

            Session["ERP_Dashboard"] = "0";
            Session["ERP_MainTab_List"] = tempFeature;
            Session["ERP_SubTab_List"] = ModuleSubTabList;
            int x = 2;
        }

        public void GetModuleSubTabListTabWise(string uID, string ModuleName, string FeatureName, ref List<FeatureName> SubFeature, string CurrentPageName = "")
        {

            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
            DataTable dt;
            obj.ModuleName = ModuleName;
            obj.TabName = FeatureName;

            if (uID == "001055")
            {
                obj.GetAllAdmUserpermissionDetail = true;
            }
            else
            {
                obj.Userid = uID;
                obj.GetAllAdmUserpermissionDetail_UserWise = true;
                obj.Role = Role;
            }
            //obj.GetAllAdmUserpermissionDetail = true;
            dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmUserpermissionRecord, obj);
            foreach (DataRow dr in dt.Rows)
            {
                string cPage = "0";
                string[] strName = null;
                strName = dr["TabUrl"].ToString().ToString().Split('/');
                if (CurrentPageName != "")
                {
                    if (strName[strName.Length - 1] == CurrentPageName)
                        cPage = "1";
                }

                SubFeature.Add(new FeatureName()
                {
                    Id = FeatureName,
                    Name = dr["SubFeatureName"].ToString(),
                    FeatureURL = dr["SubFetURL"].ToString().Replace("~", ""),
                    CurrentPageStatus = cPage
                });
            }



        }

        public string CurrentModule
        {
            get
            {
                if (Session["ModuleName"] != null)
                {
                    return (Session["ModuleName"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["ModuleName"] = value;
            }
        }

        public string CurrentUserId
        {
            get
            {
                if (Session["UserId"] != null)
                {
                    return (Session["UserId"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["UserId"] = value;
            }
        }
        public int Role
        {
            get
            {
                if (Session["Role"] != null)
                {
                    return (Convert.ToInt32(Session["Role"]));
                }

                return 0;
            }
            set
            {
                Session["Role"] = value;
            }
        }
        public string LogedEmpID
        {
            get
            {
                if (Session["LogedEmpID"].ToString() != null)
                {
                    return (Session["LogedEmpID"].ToString());
                }

                return string.Empty;
            }
            set
            {
                Session["LogedEmpID"] = value;
            }
        }
        public string CurrentUserName
        {
            get
            {
                if (Session["UserName"] != null)
                {
                    return Session["UserName"].ToString();
                }

                return string.Empty;
            }

            set { Session["UserName"] = value; }
        }

        public string CurrentUserType
        {
            get
            {
                if (Session["UserType"] != null)
                {
                    return Session["UserType"].ToString();
                }

                return string.Empty;
            }

            set { Session["UserType"] = value; }
        }

        public string CurrentCompanyName
        {
            get
            {
                if (Session["CurrentCompanyName"] != null)
                {
                    return Session["CurrentCompanyName"].ToString();
                }

                return string.Empty;
            }

            set { Session["CurrentCompanyName"] = value; }
        }

        public string CurrentAppName
        {
            get
            {
                if (Session["CurrentAppName"] != null)
                {
                    return Session["CurrentAppName"].ToString();
                }

                return string.Empty;
            }

            set { Session["CurrentAppName"] = value; }
        }

        public string CurrentCompanyAddress
        {
            get
            {
                if (Session["CurrentCompanyAddress"] != null)
                {
                    return Session["CurrentCompanyAddress"].ToString();
                }

                return string.Empty;
            }

            set { Session["CurrentCompanyAddress"] = value; }
        }

        public string LoginDatetime
        {
            get
            {
                if (Session["LoginDatetime"] != null)
                {
                    return Session["LoginDatetime"].ToString();
                }

                return string.Empty;
            }

            set { Session["LoginDatetime"] = value; }
        }

        public string CurrentUserEmail
        {
            get
            {
                if (Session["UserEmail"] != null)
                {
                    return Session["UserEmail"].ToString();
                }

                return string.Empty;
            }

            set { Session["UserEmail"] = value; }
        }

        protected void SetLoginSessionData(SystemContact contact, bool createPersistentCookie)
        {
            SetUserSessionData(contact);
            FormsAuthentication.SetAuthCookie("1", createPersistentCookie);
        }

        protected void SetUserSessionData(SystemContact contact)
        {
            CurrentUserName = contact.FirstName;
            CurrentCompanyName = contact.CompanyName;
            CurrentCompanyAddress = contact.CompanyAddress;
            CurrentUserType = contact.UserType;
            LoginDatetime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            CurrentUserId = contact.Id;
            LogedEmpID = contact.EmpId;
            //CurrentAppName = ConfigurationManager.AppSettings.Get("AppName");
        }



        public List<SelectListItem> SrcMonthList()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                string monthName = new DateTime(2010, i, 1).ToString("MMMM", CultureInfo.InvariantCulture);
                Items.Add(new SelectListItem { Text = monthName, Value = i.ToString() });
            }
            return Items;
        }
        public List<SelectListItem> SrcYearList()
        {
            List<SelectListItem> Items = new List<SelectListItem>();
            for (int i = 2014; i < 2024; i++)
            {
                Items.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            return Items;
        }

        //..  rk Common Functions
        public string RkSessionRemove(string SessVal = "SspPopMsg")
        {
            string GetVal = "";
            if (Session[SessVal] != null)
            {
                GetVal = Session[SessVal].ToString();
                Session.Remove(SessVal);
            }
            return GetVal;
        }

        public bool RkSspSendEmail(string Subject = "", string Body = "", Dictionary<string, string> MailTo = null, Dictionary<string, string> MailCc = null)
        {
            bool result = false;

            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "mail.pakizaknit.com";
            client.Credentials = new System.Net.NetworkCredential("pakiza/ssp", "ptvl@123");

            MailMessage mail = new MailMessage();
            MailAddress fromMail = new MailAddress("ssp@pakizatvl.com", "SSPortal");
            mail.From = fromMail;
            foreach (KeyValuePair<string, string> aData in MailTo)
            {
                mail.To.Add(new MailAddress(aData.Key, aData.Value));
            }
            foreach (KeyValuePair<string, string> aData in MailCc)
            {
                mail.CC.Add(new MailAddress(aData.Key, aData.Value));
            }
            mail.IsBodyHtml = true;
            mail.Subject = Subject;
            mail.Body = Body;
            try
            {
                client.Send(mail);
                result = true;
            }
            catch (SmtpFailedRecipientException ex)
            {
                // ex.FailedRecipient and ex.GetBaseException() should give you enough info.
            }

            return result;
        }

        public string RkBDTkFormatAmt(string ConAmt = "")
        {
            if (!string.IsNullOrEmpty(ConAmt))
            {
                string Minus = (Convert.ToDouble(ConAmt) < 0) ? "-" : "";
                string[] TmpAmt = Math.Round(Math.Abs(Convert.ToDouble(ConAmt)), 2).ToString().Split('.');
                string MainAmt = TmpAmt[0];
                string Points = (TmpAmt.Count() > 1) ? "." + TmpAmt[1].ToString() : "";
                string StrMoney = "";

                while (MainAmt.Length > 0)
                {
                    if (MainAmt.Length < 4)
                    {
                        StrMoney = string.IsNullOrEmpty(StrMoney) ? MainAmt : MainAmt + "," + StrMoney;
                        MainAmt = "";
                    }
                    else
                    {
                        StrMoney = string.IsNullOrEmpty(StrMoney) ? MainAmt.Substring(MainAmt.Length - 3, 3) : MainAmt.Substring(MainAmt.Length - 3, 3) + "," + StrMoney;
                        MainAmt = MainAmt.Substring(0, MainAmt.Length - 3);

                        if (MainAmt.Length < 3)
                        {
                            StrMoney = MainAmt + "," + StrMoney;
                            MainAmt = "";
                        }
                        else
                        {
                            StrMoney = MainAmt.Substring(MainAmt.Length - 2, 2) + "," + StrMoney;
                            MainAmt = MainAmt.Substring(0, MainAmt.Length - 2);

                            if (MainAmt.Length < 3)
                            {
                                StrMoney = MainAmt + "," + StrMoney;
                                MainAmt = "";
                            }
                            else
                            {
                                StrMoney = MainAmt.Substring(MainAmt.Length - 2, 2) + "," + StrMoney;
                                MainAmt = MainAmt.Substring(0, MainAmt.Length - 2);
                            }
                        }
                    }
                }

                ConAmt = Minus + StrMoney + Points;
            }
            //return Json(ConAmt, JsonRequestBehavior.AllowGet);
            return ConAmt;
        }

        public string RkBDTkFormatWord(string ConAmt = "", string UpCase = "") /// UpCase => Up, Lo, Any string for first char up
        {
            Dictionary<int, string> ones = new Dictionary<int, string>()
            {
                { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" }, { 11, "Eleven" },
                { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }
            };
            Dictionary<int, string> tens = new Dictionary<int, string>()
            {
                { 1, "Ten" }, { 2, "Twenty" }, { 3, "Thirty" }, { 4, "Forty" }, { 5, "Fifty" }, { 6, "Sixty" }, { 7, "Seventy" }, { 8, "Eighty" }, { 9, "Ninety" }
            };
            Dictionary<int, string> hundreds = new Dictionary<int, string>()
            {
                { 1, "Hundred" }, { 2, "Thousand" }, { 3, "Lak" }, { 4, "Core" }
            };

            if (!string.IsNullOrEmpty(ConAmt))
            {
                string Points = ""; string StrMoney = "";
                string Minus = (Convert.ToDouble(ConAmt) < 0) ? "Negative " : "";

                string[] TmpAmt = RkBDTkFormatAmt(ConAmt).Split('.');
                StrMoney = Math.Abs(Convert.ToDouble(TmpAmt[0])).ToString();
                Points = (TmpAmt.Count() > 1) ? TmpAmt[1].ToString() : "";

                TmpAmt = StrMoney.Split(',');
                Array.Reverse(TmpAmt);
                int Count = 1; ConAmt = "";
                foreach (string Amt in TmpAmt)
                {
                    StrMoney = "";
                    if (Convert.ToInt32(Amt) < 20)
                    {
                        StrMoney = (Convert.ToInt32(Amt) > 0) ? ones[Convert.ToInt32(Amt)] : "";
                    }
                    else if (Convert.ToInt32(Amt) < 100)
                    {
                        if (Convert.ToInt32(Amt.Substring(0, 1)) > 0) StrMoney = tens[Convert.ToInt32(Amt.Substring(0, 1))];
                        if (Convert.ToInt32(Amt.Substring(1, 1)) > 0) StrMoney = StrMoney + (string.IsNullOrEmpty(StrMoney) ? "" : " ") + ones[Convert.ToInt32(Amt.Substring(1, 1))];
                    }
                    else
                    {
                        if (Convert.ToInt32(Amt.Substring(0, 1)) > 0) StrMoney = tens[Convert.ToInt32(Amt.Substring(0, 1))] + " " + hundreds[1];
                        if (Convert.ToInt32(Amt.Substring(1, 1)) > 0) StrMoney = StrMoney + (string.IsNullOrEmpty(StrMoney) ? "" : " ") + tens[Convert.ToInt32(Amt.Substring(1, 1))];
                        if (Convert.ToInt32(Amt.Substring(2, 1)) > 0) StrMoney = StrMoney + (string.IsNullOrEmpty(StrMoney) ? "" : " ") + ones[Convert.ToInt32(Amt.Substring(2, 1))];
                    }

                    if (Count > 1)
                    {
                        StrMoney = string.IsNullOrEmpty(StrMoney) ? "" : StrMoney + " " + hundreds[Count];
                    }

                    Count++;
                    if (Count > 4) Count = 2;
                    ConAmt = StrMoney + (string.IsNullOrEmpty(ConAmt) ? "" : " ") + ConAmt;
                }

                if (!string.IsNullOrEmpty(ConAmt)) ConAmt = ConAmt + " Taka";

                if (!string.IsNullOrEmpty(Points) && Convert.ToInt32(Points) > 0)
                {
                    StrMoney = "";
                    if (Points.Length == 1)
                    {
                        StrMoney = tens[Convert.ToInt32(Points)];
                    }
                    else
                    {
                        if (Convert.ToInt32(Points.Substring(0, 1)) > 1)
                        {
                            StrMoney = tens[Convert.ToInt32(Points.Substring(0, 1))];
                            if (Convert.ToInt32(Points.Substring(1, 1)) > 0) StrMoney = StrMoney + (string.IsNullOrEmpty(StrMoney) ? "" : " ") + ones[Convert.ToInt32(Points.Substring(1, 1))];
                        }
                        else if (Convert.ToInt32(Points.Substring(0, 1)) > 0) StrMoney = ones[Convert.ToInt32(Points)];
                    }
                    ConAmt = ConAmt + " And " + StrMoney + " Paisa";
                }

                if (!string.IsNullOrEmpty(ConAmt)) ConAmt = ConAmt + " Only.";
            }

            if (!string.IsNullOrEmpty(ConAmt) && !string.IsNullOrEmpty(UpCase))
            {
                if (UpCase == "Up") ConAmt = ConAmt.ToUpper();
                else if (UpCase == "Lo") ConAmt = ConAmt.ToLower();
                else ConAmt = char.ToUpper(ConAmt[0]) + ConAmt.Substring(1).ToLower();
            }

            return ConAmt;
            /// www.phptpoint.com/convert-number-into-words-in-php/ 
        }

        public string RkCheckDateFormat(string Date = "", string InFormat = "dd/MM/yyyy")
        {
            string Result = ""; // DateTime.Now.Date.AddDays(-60).ToString("dd/MM/yyyy");
            if (!string.IsNullOrEmpty(Date) && !string.IsNullOrEmpty(InFormat))
            {
                string[] format = new string[] { InFormat };
                DateTime datetime;

                if (DateTime.TryParseExact(Date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                    Result = datetime.ToString();
            }
            return Result;
        }
        

    }
}