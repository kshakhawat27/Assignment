using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using SalesForce.Domain.Admin;
using SalesForce.Models;
using SalesForce.Structure;

namespace SalesForce.Areas.Admin.Controllers
{
    public class AdmBaseController : Controller
    {
        //
        // GET: /ADM/AdmBase/

        #region All
        public object ExecuteDB(string methodName, object param)
        {
            object retObject = ServerManager.GetTaskManager.Execute(Module.Admin, methodName, param);
            return retObject;
        }

        public bool M_GetModuleWiseTabList(string ModuleName, string CurrentControlName = "", string CurrentPageName = "")
        {

            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
            List<FeatureName> tempFeature = new List<FeatureName>();
            List<FeatureName> ModuleSubTabList = new List<FeatureName>();
            DataTable dt;

            obj.ModuleName = ModuleName;
            try
            {
                if (Session["UserId"].ToString() == "001055")
                    obj.GetAllAdmUserpermissionDetail = true;
                else
                {
                    obj.Userid = Session["UserId"].ToString();
                    obj.GetAllAdmUserpermissionDetail_UserWise = true;
                }
            }
            catch { obj.GetAllAdmUserpermissionDetail = true; }
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
                    M_GetModuleSubTabListTabWise(ModuleName, dr["TabName"].ToString(), ref ModuleSubTabList, CurrentControlName, CurrentPageName);
                }

            }

            Session["ERP_Dashboard"] = "0";
            Session["ERP_MainTab_List"] = tempFeature;
            Session["ERP_SubTab_List"] = ModuleSubTabList;
            bool isExiistPer = false;

            foreach (FeatureName iGet in ModuleSubTabList)
            {
                string[] strName = null;
                strName = iGet.FeatureURL.ToString().Split('/');
                if (iGet.ControlerName.ToUpper() == CurrentControlName.ToUpper())
                {
                    if (strName[strName.Length - 1].ToUpper() == CurrentPageName.ToUpper())
                    {
                        isExiistPer = true;
                        break;
                    }
                }
            }

            return isExiistPer;
        }

        public void M_GetModuleSubTabListTabWise(string ModuleName, string FeatureName, ref List<FeatureName> SubFeature, string CurrentControlName = "", string CurrentPageName = "")
        {

            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
            DataTable dt;
            obj.ModuleName = ModuleName;
            obj.TabName = FeatureName;

            if (Session["UserId"].ToString() == "001055")
            {
                obj.GetAllAdmUserpermissionDetail = true;
            }
            else
            {
                obj.Userid = Session["UserId"].ToString();
                obj.GetAllAdmUserpermissionDetail_UserWise = true;
            }
            dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllAdmUserpermissionRecord, obj);

            foreach (DataRow dr in dt.Rows)
            {
                string cPage = "0";
                string[] strName = null;
                strName = dr["SubFetURL"].ToString().ToString().Split('/');
                if (FeatureName.ToUpper() == CurrentControlName.ToUpper())
                {
                    if (strName[strName.Length - 1].ToUpper() == CurrentPageName.ToUpper())
                        cPage = "1";
                }
                SubFeature.Add(new FeatureName()
                {
                    Id = FeatureName,
                    Name = dr["SubFeatureName"].ToString(),
                    FeatureURL = dr["SubFetURL"].ToString().Replace("~", ""),
                    CurrentPageStatus = cPage,
                    ControlerName = FeatureName
                });
            }
        }

   

        #endregion

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



        public List<SelectListItem> ModuleList()
        {
            //List<SelectListItem> state = new List<SelectListItem>();
            //state.Add(new SelectListItem
            //{
            //    Text = "Select Module",
            //    Value = ""
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Admin",
            //    Value = "Admin"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Inventory",
            //    Value = "Inventory"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Operations",
            //    Value = "Operations"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Purchase",
            //    Value = "Purchase"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "SWOF",
            //    Value = "SWOF"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Requisition",
            //    Value = "Requisition"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Foreign Purchase",
            //    Value = "Foreign Purchase"
            //});
            //state.Add(new SelectListItem
            //{
            //    Text = "Mushak",
            //    Value = "Mushak"
            //});
            AdmMasterfeatureEntity obj = new AdmMasterfeatureEntity();
            obj.isDistinct = true;
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmMasterfeatureRecord, obj);
            List<SelectListItem> Items = new List<SelectListItem>();

            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "Select Module....", Value = "" });

                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["ModuleName"].ToString(), Value = dr["ModuleName"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "Select Module....", Value = "" });
            }
            return Items;
        }

        public List<SelectListItem> getModuleName(string moduleName)
        {

            AdmMasterfeatureEntity obj = new AdmMasterfeatureEntity();

            if (moduleName != "0")
                obj.Modulename = moduleName;

            else
                obj = null;


            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmMasterfeatureRecord, obj);
            List<SelectListItem> Items = new List<SelectListItem>();

            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });

                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["TabName"].ToString(), Value = dr["ID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }
            return Items;
        }
        public List<SelectListItem> GetModuleList()
        {

            AdmMasterfeatureEntity obj = new AdmMasterfeatureEntity();

            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmMasterfeatureRecord, null);
            List<SelectListItem> Items = new List<SelectListItem>();

            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "Select Module....", Value = "" });

                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["ModuleName"].ToString(), Value = dr["ID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "Select Module....", Value = "" });
            }
            return Items;
        }

        public JsonResult SubModuleList(string TabId = "", string ModuleName = "")
        {
            AdmSubfeatureEntity obj = new AdmSubfeatureEntity
            {
                ModuleName = ModuleName,
                Tabid = TabId
            };
            DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllAdmSubfeatureRecord, obj);
            List<SelectListItem> Items = new List<SelectListItem>();

            if (dt.Rows.Count > 0)
            {
                Items.Add(new SelectListItem { Text = "", Value = "" });

                foreach (DataRow dr in dt.Rows)
                {
                    Items.Add(new SelectListItem { Text = dr["SubFeatureName"].ToString(), Value = dr["ID"].ToString() });
                }
            }
            else
            {
                Items = new List<SelectListItem>();
                Items.Add(new SelectListItem { Text = "", Value = "" });
            }

            return Json(Items);

        }

        //public List<SelectListItem> GetRCList()
        //{
        //    AccCostcenterEntity obj = new AccCostcenterEntity();
        //    obj.isList = true;
        //    obj.isAdmin = true;
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.ACC,ERPTask.AG_GetAllAccCostcenterRecord, obj);

        //    List<SelectListItem> Items = new List<SelectListItem>();

        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["MCode"].ToString() + "-" + dr["MName"].ToString(), Value = dr["Id"].ToString() });
        //        }
        //    }
        //    else
        //    {
        //        Items = new List<SelectListItem>();
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //    }
        //    return Items;
        //}


        //public List<SelectListItem> GetLCList()
        //{
        //    DataTable dt;
        //    AccCompanyEntity obj = new AccCompanyEntity();

        //    dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.ACC, ERPTask.AG_GetAllAccCompanyRecord, obj);


        //    List<SelectListItem> Items = new List<SelectListItem>();

        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["CompanyCode"].ToString() + "-" + dr["Company"].ToString(), Value = dr["Id"].ToString() });
        //        }
        //    }

        //    else
        //    {
        //        Items = new List<SelectListItem>();
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //    }



        //    return Items;
        //}

        public void GetAdmUserPermissionSubFeature(string ModuleName, string FeatureName)
        {
            GetUserPermission(ModuleName);
            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
            List<FeatureName> SubFeature = new List<FeatureName>();
            DataTable dt;
            obj.ModuleName = ModuleName;
            obj.TabName = FeatureName;

            if (Session["UserId"].ToString() == "2c7a06a2-49ff-4166-81cc-b43cd38a8d2b")
            {
                obj.GetAllAdmUserpermissionDetail = true;
                dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllAdmUserpermissionRecord, obj);
                obj.Userid = "2c7a06a2-49ff-4166-81cc-b43cd38a8d2b";
            }

            else
            {
                obj.Userid = Session["UserId"].ToString();
                obj.GetAllAdmUserpermissionDetail_UserWise = true;
                dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllAdmUserpermissionRecord, obj);
            }

            foreach (DataRow dr in dt.Rows)
            {
                SubFeature.Add(new FeatureName()
                {
                    Id = "",
                    Name = dr["SubFeatureName"].ToString(),
                    FeatureURL = dr["SubFetURL"].ToString().Replace("~", "")
                });


            }


            Session["FeatureName"] = FeatureName;
            Session["Adm_Sub_Feature"] = SubFeature;
        }
        public void GetUserPermission(string ModuleName)
        {

            AdmUserpermissionEntity obj = new AdmUserpermissionEntity();
            List<FeatureName> tempFeature = new List<FeatureName>();
            List<FeatureName> Feature = new List<FeatureName>();
            DataTable dt;

            obj.ModuleName = ModuleName;

            if (Session["UserId"].ToString() == "2c7a06a2-49ff-4166-81cc-b43cd38a8d2b")
                obj.GetAllAdmUserpermissionDetail = true;
            else
            {
                obj.Userid = Session["UserId"].ToString();
                obj.GetAllAdmUserpermissionDetail_UserWise = true;
            }
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
                        FeatureURL = dr["TabUrl"].ToString().Replace("~", "")
                    });
                }

            }

            Session["HR_Main_Feature"] = tempFeature;
        }

     

      
        //public List<SelectListItem> GetEmployeeNamelist()
        //{
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.HRM, ERPTask.AG_GetAllHrEmployeeinfoRecord, null);
        //    List<SelectListItem> Items = new List<SelectListItem>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["EmpName"].ToString(), Value = dr["EmpId"].ToString() });
        //        }
        //    }
        //    else
        //    {
        //        Items = new List<SelectListItem>();
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //    }
        //    return Items;
        //}

        //public List<SelectListItem> GetEmployeeIdlist()
        //{
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.HRM, ERPTask.AG_GetAllHrEmployeeinfoRecord, null);
        //    List<SelectListItem> Items = new List<SelectListItem>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["EmpName"].ToString(), Value = dr["EmpId"].ToString() });
        //        }
        //    }
        //    else
        //    {
        //        Items = new List<SelectListItem>();
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //    }
        //    return Items;
        //}

        //public List<SelectListItem> GetEmployeeInfolist()
        //{
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.HRM, ERPTask.AG_GetAllHrEmployeeinfoRecord, null);
        //    List<SelectListItem> Items = new List<SelectListItem>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["EmpName"].ToString(), Value = dr["EmpId"].ToString() });
        //        }
        //    }
        //    else
        //    {
        //        Items = new List<SelectListItem>();
        //        Items.Add(new SelectListItem { Text = "", Value = "" });
        //    }
        //    return Items;
        //}
        //public List<SelectListItem> GetEmployeeTypeList()
        //{
        //    //HrmBaseController temp = new HrmBaseController();
        //    //return temp.GetEmployeeTypeList(Session["UserId"].ToString());

      
        //    return obj.GetEmployeeTypeList(Session["UserId"].ToString(), Session["ssnActiveCompanyID"].ToString());

        //    //DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.HRM, ERPTask.AG_GetAllHrEmployeetypeRecord, null);
        //    //List<SelectListItem> Items = new List<SelectListItem>();
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    Items.Add(new SelectListItem { Text = "", Value = "" });
        //    //    foreach (DataRow dr in dt.Rows)
        //    //    {
        //    //        Items.Add(new SelectListItem { Text = dr["Name"].ToString(), Value = dr["Id"].ToString() });
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    Items = new List<SelectListItem>();
        //    //    Items.Add(new SelectListItem { Text = "", Value = "" });
        //    //}
        //    //return Items;
        //}

        //GetIsActiveList
        public List<SelectListItem> GetIsActiveList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                 new SelectListItem
                {
                    Text = "-----Select-----",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "Active",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Inactive",
                    Value = "0"
                }
            };

            return status;

        }

        public List<SelectListItem> GetScopeList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                 new SelectListItem
                {
                    Text = "All",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "Customer",
                    Value = "Customer"
                },
                new SelectListItem
                {
                    Text = "Supplier",
                    Value = "Supplier"
                }
            };

            return status;

        }

        public List<SelectListItem> GetIsActiveList_()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Yes",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "No",
                    Value = "0"
                }
            };

            return status;

        }
        public List<SelectListItem> GetToggleList_()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Yes",
                    Value = "Yes"
                },
                new SelectListItem
                {
                    Text = "No",
                    Value = "No"
                }
            };

            return status;

        }

        public List<SelectListItem> GetReturnTypeList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Main Return (Law 64)",
                    Value = "1"
                },
                new SelectListItem
                {
                    Text = "Revised Return (Law 66)",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "Complete/Aditional/Alternate Return (Law 67)",
                    Value = "3"
                }
            };

            return status;

        }
        public List<SelectListItem> GetCodeTypeList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "HS Code",
                    Value = "HS Code"
                },
                new SelectListItem
                {
                    Text = "Service Code",
                    Value = "Service Code"
                },
                new SelectListItem
                {
                    Text = "3rd Schedule",
                    Value = "3rd Schedule"
                }
            };

            return status;

        }

        public List<SelectListItem> GetMushakList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Mushak 6.3",
                    Value = "Mushak 6.3"
                },
                new SelectListItem
                {
                    Text = "Mushak 6.9",
                    Value = "Mushak 6.9"
                }
            };

            return status;

        }

        public List<SelectListItem> GetBusinessTypeList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Dealer",
                    Value = "Dealer"
                },
                new SelectListItem
                {
                    Text = "Retailer",
                    Value = "Retailer"
                },
                new SelectListItem
                {
                    Text = "Dealer & Retailer",
                    Value = "Dealer & Retailer"
                }
            };

            return status;

        }

        public List<SelectListItem> GetOwnerTypeList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Properietorship",
                    Value = "Properietorship"
                },
                new SelectListItem
                {
                    Text = "Partnership",
                    Value = "Partnership"
                },
                new SelectListItem
                {
                    Text = "Private Limited",
                    Value = "Private Limited"
                },
                new SelectListItem
                {
                    Text = "Public Limited",
                    Value = "Public Limited"
                },
                new SelectListItem
                {
                    Text = "NGO",
                    Value = "NGO"
                }
            };

            return status;

        }

        public List<SelectListItem> GetEconomicActvList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Manufacturing",
                    Value = "Manufacturing"
                },
                new SelectListItem
                {
                    Text = "Services",
                    Value = "Services"
                },
                new SelectListItem
                {
                    Text = "Imports",
                    Value = "Imports"
                },
                new SelectListItem
                {
                    Text = "Exports",
                    Value = "Exports"
                },
                new SelectListItem
                {
                    Text = "Other",
                    Value = "Other"
                }
            };

            return status;

        }

        public List<SelectListItem> GetDistrictList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Bandarban",
                    Value = "Bandarban"
                },
                new SelectListItem
                {
                    Text = "Barguna",
                    Value = "Barguna"
                },
                new SelectListItem
                {
                    Text = "Barisal",
                    Value = "Barisal"
                }
            };

            return status;

        }



        /// <summary>
        /// Gets all company category list.
        /// </summary>
        /// <param name="IsActiveStatus">The status.</param>
        /// <returns>Returns all company category list</returns>
    

  

     
        public List<SelectListItem> GetCurrencySymbolList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-----Select-----",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "USD",
                    Value = "$"
                },
                new SelectListItem
                {
                    Text = "BDT",
                    Value = "৳"
                },
                new SelectListItem
                {
                    Text = "SD",
                    Value = "S$"
                }
            };
            return status;
        }

        public List<SelectListItem> GetCurrencyNameList()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-----Select-----",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "USD",
                    Value = "USD"
                },
                new SelectListItem
                {
                    Text = "BDT",
                    Value = "BDT"
                },
                new SelectListItem
                {
                    Text = "SD",
                    Value = "SD"
                },
                new SelectListItem
                {
                    Text = "EURO",
                    Value = "EURO"
                },
                new SelectListItem
                {
                    Text = "GBP",
                    Value = "GBP"
                }

            };
            return status;
        }
        public List<SelectListItem> GetTransactionType()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Purchase",
                    Value = "Purchase>2Lac"
                },
                new SelectListItem
                {
                    Text = "Sale",
                    Value = "Sale>2Lac"
                }

            };
            return status;
        }


        //public List<SelectListItem> GetAllVATCategory(string Status)
        //{
        //    VatVatcategoryEntity iSet = new VatVatcategoryEntity
        //    {
        //        Isactive = Status
        //    };
        //    DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatVatcategoryRecord, iSet);
        //    List<SelectListItem> Items = new List<SelectListItem>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        Items.Add(new SelectListItem { Text = "-----Select-----", Value = "" });
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Items.Add(new SelectListItem { Text = dr["MushakName"].ToString(), Value = dr["ID"].ToString() });
        //        }
        //    }
        //    else
        //    {
        //        Items = new List<SelectListItem>
        //        {
        //            new SelectListItem { Text = "", Value = "" }
        //        };
        //    }
        //    return Items;
        //}
        public List<SelectListItem> TreasuryDepositMonthlyItems()
        {
            List<SelectListItem> status = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "-----Select-----",
                    Value = ""
                },
                new SelectListItem
                {
                    Text = "Vat Deposit for the Current Tax Period",
                    Value = "58"
                },
                new SelectListItem
                {
                    Text = "SD Deposit for the Current Tax Period",
                    Value = "59"
                },
                 new SelectListItem
                {
                    Text = "Excise Duty",
                    Value = "60"
                },
                new SelectListItem
                {
                    Text = "Development Surcharge",
                    Value = "61"
                },
                 new SelectListItem
                {
                    Text = "ICT Development Surcharge",
                    Value = "62"
                },
                new SelectListItem
                {
                    Text = "Health Care Surcharge",
                    Value = "63"
                },
                 new SelectListItem
                {
                    Text = "Environmental Protection Surcharge",
                    Value = "63"
                },

            };
            return status;
        }

    }
}

