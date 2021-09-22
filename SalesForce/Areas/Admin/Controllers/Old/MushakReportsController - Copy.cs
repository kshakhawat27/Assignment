using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Mvc;
using SalesForce.Areas.Inventory.Controllers;
using SalesForce.Areas.Operations.Controllers;
using SalesForce.Domain.Inventory;
using SalesForce.Domain.Model.Inventory;
using SalesForce.Domain.Operations;
using SalesForce.Structure;

namespace SalesForce.Areas.Admin.Controllers
{
    public class MushakReportsController : AdmBaseController
    {
        // GET: Admin/MushakReports
        ManageStockController objInv = new ManageStockController();
        OperationsBaseController objOp = new OperationsBaseController();

        #region Mushak 4.1 : Advanced Tax Withdrawn
        public ActionResult AdvancedTaxWithdrawn()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "AdvancedTaxWithdrawn");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 4.1 : Advance Tax Withdrawn";
            Session["PageHeader"] = "Mushak 4.1 : Advance Tax Withdrawn";
            ViewData["IsReturn"] = GetIsActiveList_();
            return View();
        }
        //New
        //Mushak_4_1Report
        public ActionResult Mushak_4_1Report()
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "AdvancedTaxWithdrawn");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 4.1 : Advance Tax Withdrawn";
            Session["PageHeader"] = "Mushak 4.1 : Advance Tax Withdrawn";

            string FullFormData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
            <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
            </div>
            <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>আইনের ধারা ৩১ এর উপ ধারা (৪) এর অধীন আমদানি পর্যায়ে পরিশোধিত অগ্রিম কর ফেরত প্রাপ্তির আবেদন</h6>
            <h6>[বিধি ১৯ এর উপ বিধি (৩) এর দফা (খ) দ্রষ্টব্য]</h6>
            </div>
            <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

            </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr>
                    <th>
                        <b>মূসক ৪.১</b>
                    </th>
                </tr>

            </table>
            </div>
            </div>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:50px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <td style='width: 30%;'>
                        আবেদনকারীর নাম
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        Pakiza Technovation Ltd.
                    </td>

                </tr>
                <tr>
                    <td style='width: 30%;'>
                        নৈমিত্তিক ব্যবসায় সনাক্তকরণ সংখ্যা
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        00086861616-0306
                    </td>
                </tr>
                <tr>
                    <td>
                        ঠিকানা
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        1094, NOWPARA,RASULPUR,NARSINGDI
                    </td>
                </tr>
                <tr>
                    <td>
                        বিল অব এন্ট্রি নম্বর
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        BL-001
                    </td>
                </tr>
                <tr>
                    <td>
                        যে দেশ হইতে পণ্য আমদানি করা হইয়াছে
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        Singapore
                    </td>
                </tr>
                <tr>
                    <td>
                        আমদানিকৃত পণ্যের বিবরণ
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        Monitor HS:293434430
                    </td>
                </tr>
                <tr>
                    <td>
                        পরিশোধিত অগ্রিম মূসকের পরিমাণ
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        233,328.75
                    </td>
                </tr>
                <tr>
                    <td>
                        অগ্রিম মূসক পরিশোধের তারিখ
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        18/11/2019
                    </td>
                </tr>
                <tr>
                    <td>
                        রিলিজ অর্ডার নম্বর
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
            </table>
            </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:50px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <p>ঘোষণা</p>
            <p>আমি ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বতোভাবে সম্পূর্ণ সত্য ও নির্ভুল।</p>

            <table id='tableAnnc'>
                <tr>
                    <td style='width: 30%;'>
                        নাম
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        পদবি
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        স্বাক্ষর ও সীল
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
            </table>
            </div>
            </div>
            <div class='footer'>
            <p>Page 1 of 1</p>
            </div>
            <div class='footer2'>
            <p>Print Date: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"</p>
            </div>
            </form>";

            ViewBag.FormData = FullFormData;

            return View();

        }
        #endregion

        #region Mushak 4.2 : Loan Transfer Application
        public ActionResult LoanTransferApplication()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "LoanTransferApplication");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 4.2 : Loan Transfer Application";
            Session["PageHeader"] = "Mushak 4.2 : Loan Transfer Application";
            ViewData["IsReturn"] = GetIsActiveList_();
            return View();
        }
        public ActionResult Mushak_4_2Report()
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "LoanTransferApplication");
            Session["PageHeader"] = "Mushak 4.2 : Loan Transfer Application";

            /*string FullFormData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>আইনের ধারা ৩১ এর উপ ধারা (৪) এর অধীন আমদানি পর্যায়ে পরিশোধিত আগাম কর ফেরত প্রাপ্তির আবেদন</h6>
            <h6>[বিধি ১৯ এর উপ বিধি (৩) এর দফা (খ) দ্রষ্টব্য]</h6>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr>
                    <th>
                        <b>মূসক ৪.১</b>
                    </th>
                </tr>

            </table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <td style='width: 30%;'>
                        আবেদনকারীর নাম
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        Pakiza Technovation Ltd.
                    </td>

                </tr>
                <tr>
                    <td style='width: 30%;'>
                        নৈমিত্তিক ব্যবসায় সনাক্তকরণ সংখ্যা
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        003548546375475
                    </td>
                </tr>
                <tr>
                    <td>
                        ঠিকানা
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        House #52/A, Road #9/A, Dhanmondi, Dhaka-1209, Bangladesh
                    </td>
                </tr>
                <tr>
                    <td>
                        বিল অব এন্ট্রি নম্বর
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        BL-001
                    </td>
                </tr>
                <tr>
                    <td>
                        যে দেশ হইতে পণ্য আমদানি করা হইয়াছে
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        Uganda
                    </td>
                </tr>
                <tr>
                    <td>
                        আমদানিকৃত পণ্যের বিবরণ
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        Monitor HS:293434430
                    </td>
                </tr>
                <tr>
                    <td>
                        পরিশোধিত আগাম মূসকের পরিমাণ
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        233,328.75
                    </td>
                </tr>
                <tr>
                    <td>
                        আগাম কর পরিশোধের তারিখ
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>
                        18/11/2019
                    </td>
                </tr>
                <tr>
                    <td>
                        রিলিজ অর্ডার নম্বর
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
            </table>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <p>ঘোষণা</p>
            <p>আমি ঘোষণা করিতেছি যে, এই আবেদনে প্রদত্ত তথ্য সর্বতোভাবে সম্পূর্ণ সত্য ও নির্ভুল।</p>

            <table id='tableAnnc'>
                <tr>
                    <td style='width: 30%;'>
                        নাম
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        পদবি
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        স্বাক্ষর ও সীল
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
            </table>
        </div>
    </div>
    <div class='footer'>
        <p>Page 1 of 1</p>
    </div>
    <div class='footer2'>
        <p>Print Date: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"</p>
    </div>
</form>";

            ViewBag.FormData = FullFormData;*/

            return View();

        }
        #endregion

        #region Mushak 4.3 : Input Output Co-Efficient
        public ActionResult InputOutputCoEfficient()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "InputOutputCoEfficient");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 4.3 : Input Output Co-Efficient";
            Session["PageHeader"] = "Mushak 4.3 : Input Output Co-Efficient";
            ViewData["IsReturn"] = GetIsActiveList_();
            return View();
        }

        //GetPriceDeclaration
        [HttpPost]
        public JsonResult GetDeclaredPriceList()
        {
            try
            {
                InvBomMasterEntity iSet = new InvBomMasterEntity();
                DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvBomMasterRecord, null);

                int iCount = 1;
                string TableData = "", Edit = "";
                foreach (DataRow dr in dt.Rows)
                {
                    Edit = "<i onclick=\"GoToReportView('" + dr["ID"] + "');\" title='Go To Print' class='md-icon md-24 material-icons md-color-red-400'>&#XE85D;</i>";

                    string dlYear = dr["BOMDate"].ToString().Substring(6, 4);

                    TableData = TableData + "<tr>"
                                          + "<td>" + Edit + "</td>"
                                          + "<td>" + iCount + "</td>"
                                          + "<td>" + (dlYear + "-PD-" + Convert.ToDouble(dr["DeclarationNo"]).ToString("000000")) + "</td>"
                                          + "<td>" + dr["BOMName"] + "</td>"
                                          + "<td>" + dr["BOMDate"] + "</td>"
                                          + "<td>" + dr["Description"] + "</td>"
                                          + "<td>" + dr["TotalRawMatPrice"] + "</td>"
                                          + "<td>" + dr["TotalOverHeadCost"] + "</td>"
                                          + "</tr>";

                    iCount += 1;
                }

                string tHead = "<tr><th style='width:15px;'></th><th style='width:15px;'>SL</th><th>Declaration No</th><th>BOM Name</th><th>BOM Date</th><th>Product Type</th><th>Raw Material Cost</th><th>Over-head Cost</th></tr>";

                TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

                return Json(TableData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        //Mushak_4_3_Report
        public ActionResult Mushak_4_3_Report(string DeclId)
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "InputOutputCoEfficient");
            Session["PageHeader"] = "Mushak 4.3 : Input Output Co-Efficient";

            InvBomMasterEntity iSet = new InvBomMasterEntity
            {
                Id = DeclId
            };
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvBomMasterRecord, iSet);
            string dlYear = dt.Rows[0]["BOMDate"].ToString().Substring(6, 4);
            string TableData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>উপকরণ-উৎপাদ সহগ (Input-Output Coefficient) ঘোষণা</h6>
            <h6>[বিধি ২১ দ্রষ্টব্য]</h6>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 15%; float: right; margin-right:80px;'>
                <tr>
                    <th>
                        <b>মূসক-৪.৩</b>
                    </th>
                </tr>
                <tr>
                    <th>
                        <b>Declaration No<br/>" + (dlYear + "-PD-" + Convert.ToDouble(dt.Rows[0]["DeclarationNo"]).ToString("000000")) + @"</b>
                    </th>
                </tr>

            </table>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>

            <table id='tableIntr' style='width: 100%;'>
                <tr>
                    <th style='width: 50%;'>
                        প্রতিষ্ঠানের নাম
                    </th>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'> Pakiza Technovation Ltd. </td>
                </tr>
                <tr>
                    <th style='width: 50%;'>
                        ঠিকানা
                    </th>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'> 1094, NOWPARA,RASULPUR,NARSINGDI </td>
                </tr>
                <tr>
                    <th style='width: 50%;'>
                        বিন(BIN)
                    </th>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'> 00086861616-0306 </td>
                </tr>
                <tr>
                    <th style='width: 50%;'>
                        দাখিলের তারিখ
                    </th>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>" + dt.Rows[0]["BOMDate"] + @"</td>
                </tr>
                <tr>
                    <th style='width: 50%;'>
                        ঘোষিত সহগ অনুযায়ী পণ্য/সেবার প্রথম সরবরাহের তারিখ
                    </th>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'>" + dt.Rows[0]["BOMDate"] + @"</td>
                </tr>
            </table>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <th rowspan='2'> ক্রমিক নং </th>
                    <th rowspan='2'> পণ্যের এইচ এস কোড </th>
                    <th rowspan='2'> সরবরাহতব্য পণ্যের নাম ও বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নামসহ)</th>
                    <th rowspan='2'> সরবরাহের একক </th>
                    <th colspan='5'>
                        একক পণ্য সরবরাহে ব্যবহার্য যাবতীয় উপকরণের/কাঁচামালের ও প্যাকিং
                        সামগ্রীর বিবরণ, পরিমাণ  ও ক্রয়মূল্য (উপকরণ ভিত্তিক অপচয়ের শতকরা
                        হারসহ)
                    </th>
                    <th colspan='2'> মূল্য সংযোজনের বিবরণ </th>
                    <th rowspan='2'> মন্তব্য </th>
                </tr>
                <tr>
                    <th>
                        বিবরণ
                    </th>
                    <th>
                        অপচয়সহ
                        পরিমাণ
                    </th>
                    <th>
                        ক্রয়মূল্য
                    </th>
                    <th>
                        অপচয়ের
                        পরিমাণ
                    </th>
                    <th>
                        শতকরা
                        হার
                    </th>
                    <th>
                        মূল্য সংযোজনের খাত
                    </th>
                    <th>
                        মূল্য
                    </th>

                </tr>
                <tr>
                    <th> (১) </th>
                    <th> (২) </th>
                    <th> (৩) </th>
                    <th> (৪) </th>
                    <th> (৫) </th>
                    <th> (৬) </th>
                    <th> (৭) </th>
                    <th> (৮) </th>
                    <th> (৯) </th>
                    <th> (১০) </th>
                    <th> (১১) </th>
                    <th> (১২) </th>
                </tr>";


            DataTable dtRawMatData = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvRawmatmappingRecord, DeclId);

            InvProductionvaiEntity iSetVAI = new InvProductionvaiEntity();
            iSetVAI.Refid = DeclId;
            DataTable dtValueAddedItems = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvProductionvaiRecord, iSetVAI);

            int countTR = dtValueAddedItems.Rows.Count < dtRawMatData.Rows.Count ? dtRawMatData.Rows.Count : dtValueAddedItems.Rows.Count + 1;

            double dlTotalBuyingPrice = 0;
            double dlTotalVPrice = 0;

            foreach (DataRow Dr in dtValueAddedItems.Rows)
            {
                dlTotalVPrice += Convert.ToDouble(Dr["TotalPrice"]);
            }
            foreach (DataRow Dr in dtRawMatData.Rows)
            {
                dlTotalBuyingPrice += Convert.ToDouble(Dr["TotalPrice"]);
            }

            double totProfit = (Convert.ToDouble(dt.Rows[0]["TradePrice"]) - (dlTotalVPrice + dlTotalBuyingPrice));

            double dlTotalQtyWas = 0;
            double dlTotalWas = 0;
            double dlTotalWasPer = 0;
            double dlTotalFinalPrice = 0;
            for (int i = 0; i < countTR; i++)
            {
                var UnitName = "";
                string Val1 = (i + 1).ToString(), Val2 = "", Val3 = "", Val4 = "", Val5 = "", Val6 = "", Val7 = "", Val8 = "", Val9 = "", Val10 = "", Val11 = "", Val12 = "";
                if (i == 0)
                {
                    Val2 = dt.Rows[0]["Code"].ToString();
                    Val3 = dt.Rows[0]["FinishedItemName"].ToString();//GetProductHsCodeById(dt.Rows[0]["FinishedItemId"].ToString());
                    Val4 = dt.Rows[0]["UnitName"].ToString();
                }
                try
                {
                    UnitName = dtRawMatData.Rows[i]["Unit"].ToString();
                    Val5 = GetProductHsCodeById(dtRawMatData.Rows[i]["ItemId"].ToString());
                    Val6 = (Convert.ToDouble(dtRawMatData.Rows[i]["ReqQty"]) + Convert.ToDouble(dtRawMatData.Rows[i]["Wastage"])).ToString();
                    //Val6 += " " + UnitName;

                    Val7 = dtRawMatData.Rows[i]["TotalPrice"].ToString();
                    Val8 = dtRawMatData.Rows[i]["Wastage"].ToString();
                    Val9 = dtRawMatData.Rows[i]["Percentage"].ToString();

                    //dlTotalBuyingPrice += Convert.ToDouble(dtRawMatData.Rows[i]["TotalPrice"]);
                    dlTotalQtyWas += Convert.ToDouble(Val6);
                    dlTotalWas += Convert.ToDouble(Val8);
                    dlTotalWasPer += Convert.ToDouble(Val9);
                }
                catch { }

                try
                {
                    Val10 = dtValueAddedItems.Rows[i]["ItemName"].ToString();
                    Val11 = dtValueAddedItems.Rows[i]["TotalPrice"].ToString();

                    //dlTotalVPrice += Convert.ToDouble(dtValueAddedItems.Rows[i]["TotalPrice"]);
                }
                catch { }

                dlTotalFinalPrice = dlTotalBuyingPrice + dlTotalVPrice;

                if (dtValueAddedItems.Rows.Count == i)
                {
                    Val10 = "Profit";
                    Val11 = totProfit.ToString("0.00");
                }


                TableData += "<tr><td>" + Val1 + "</td><td>" + Val2 + "</td><td>" + Val3 + "</td><td>" + Val4 + "</td><td>" + Val5 + "</td><td>" + Val6 + " " + UnitName + "</td>"
                    + "<td>" + Val7 + "</td><td>" + Val8 + " " + UnitName + "</td><td>" + Val9 + "</td><td>" + Val10 + "</td><td>" + Val11 + "</td><td>" + Val12 + "</td></tr>";
            }

            TableData += "<tr><td></td><td></td><td></td><td></td><td> মোট মূল্য </td><td>" + dlTotalQtyWas + "</td>"
                    + "<td><b>" + dlTotalBuyingPrice + "</b></td><td>" + dlTotalWas + "</td><td>" + dlTotalWasPer + "</td><td></td><td><b>" + (dlTotalVPrice + totProfit).ToString("0.00") + "</b></td><td><b>" + (dlTotalFinalPrice + totProfit) + "</b></td></tr>";
            TableData = TableData + @"</table>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            
            <table id='tableAnnc' style='float:right;'>
                <tr>
                    <td style='width: 30%;'>
                       প্রতিষ্ঠানের দায়িত্তপ্রাপ্ত ব্যক্তির নাম
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        পদবি
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        স্বাক্ষর ও সীল
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
                <tr>
                    <td style='width: 30%;'>
                        সীল
                    </td>
                    <td style='width: 5%;'>
                        :
                    </td>
                    <td style='text-align: left;'></td>
                </tr>
            </table>
        </div>
    </div>


    <div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <p><b>বিশেষ দ্রষ্টব্যঃ</b></p>
            <p>১ | যেকোনো পণ্য প্রথম সরবরাহের পূর্ববর্তী পনের কার্যদিবসের মধ্যে অনলাইনে মূসক কম্পিউটার সিস্টেমে বা সংশ্লিষ্ট বিভাগীয় কর্মকর্তার দপ্তরে উপকরণ-উৎপাদ সহগ ঘোষণা দাখিল করিতে হইবে।</p>
            <p>২ | পণ্য মূল্য বা মোট উপকরণ/কাঁচামালের মূল্য ৭.৫% এর বেশী পরিবর্তন হইলে নূতন ঘোষণা দাখিল করিতে হইবে।</p>
            <p>৩ | উপকরণ ক্রয়ের স্বপক্ষে প্রামাণিক দলিল হিসাবে বিল অব এন্ট্রি বা মূসক চালানপত্রের কপি সংযুক্ত করিতে হইবে।</p>
        </div>
    </div>

    <div class='footer'>
        <p>Page 1 of 1</p>
    </div>
    <div class='footer2'>
        <p>Print Date: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"</p>
    </div>
</form>";
            ViewBag.FullFormData = TableData;
            return View();

        }
        #endregion

        #region Mushak 6.3 : Sales Tax Challan
        public ActionResult SalesTaxChallan()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "SalesTaxChallan");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.3 : Sales Tax Challan";
            Session["PageHeader"] = "Mushak 6.3 : Sales Tax Challan";
            OperationsBaseController objOp = new OperationsBaseController();
            ViewData["IsReturn"] = GetIsActiveList_();
            ViewData["CustomerList"] = objOp.GetCustomerlist();
            SfInvoicemasterEntity setObj = new SfInvoicemasterEntity
            {
                StartDate = DateTime.Now.ToString("01/MM/yyyy"),
                EndDate = DateTime.Now.ToString("dd/MM/yyyy")
            };

            return View(setObj);
        }
        //GetTAXChallanInvoiceList
        public JsonResult GetTAXChallanInvoiceList(string StartDate = "", string EndDate = "", string Client = "", string InvNo = "")
        {
            SfInvoicemasterEntity objGet = new SfInvoicemasterEntity();

            objGet.Customerid = Client;
            objGet.Invoiceno = InvNo;

            if (string.IsNullOrEmpty(InvNo))
            {
                objGet.Invoicedate = StartDate;
                objGet.EndDate = EndDate;
            }
            else
            {
                objGet.Invoicedate = "";
                objGet.EndDate = "";
            }

            //objGet.GenerateInvoiceBill = true;
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicemasterRecord, objGet);

            string TableData = "";
            int iCount = 1;

            foreach (DataRow dr in dt.Rows)
            {
                TableData = TableData + "<tr>"
                      + "<td>" + iCount + "</td>"
                      + "<td><i onclick=\"GoToReportView('" + dr["Id"] + "','" + dr["Duplicate"] + "');\" class='md-24 material-icons md-color-green-500' title='View Report'>&#XE85D;</i></td>"
                      + "<td>" + dr["ChallanNo"] + "</td>"
                      + "<td>" + dr["InvoiceDate"] + "</td>"
                      + "<td>" + dr["SalesTypes"] + "</td>"
                      + "<td>" + dr["CustomerName"] + "</td>"
                      + "<td>" + dr["TotalAmount"] + "</td>"
                      + "</tr>";
                iCount = iCount + 1;
            }

            string tHead = "";

            tHead = "<tr><th>Sl</th><th></th><th>Invoice No</th><th>Invoice Date</th><th>Sales Type</th><th>Client Name</th><th>Total Amount</th></tr>";

            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>"
                + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        public JsonResult UpdateDuplicates(string Ids = "", string Dups = "")
        {
            int newDups = 0;
            if (!string.IsNullOrEmpty(Dups) && Convert.ToInt16(Dups) >= 1)
            {
                newDups = Convert.ToInt16(Dups) + 1;
            }
            SfInvoicemasterEntity iSet = new SfInvoicemasterEntity
            {
                Id = Ids,
                Duplicate = newDups.ToString(),
                DuplicateUpdate = true
            };
            bool isSave = (bool)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_UpdateSfInvoicemasterInfo, iSet);

            if (isSave)
            {
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
        public ActionResult Mushak_6_3_Report(string Id = "", string Dups = "")
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "SalesTaxChallan");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.3 : Sales Tax Challan";
            Session["PageHeader"] = "Mushak 6.3 : Sales Tax Challan";

            SfInvoicemasterEntity iDup = new SfInvoicemasterEntity();
            iDup.Id = Id;
            SfInvoicemasterEntity iDupGet = (SfInvoicemasterEntity)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetSingleSfInvoicemasterRecordById, iDup);
            if (Convert.ToInt16(iDupGet.Duplicate) == 0)
            {
                SfInvoicemasterEntity iSet = new SfInvoicemasterEntity
                {
                    Id = Id,
                    Duplicate = (Convert.ToInt16(iDupGet.Duplicate) + 1).ToString(),
                    DuplicateUpdate = true
                };
                bool isSave = (bool)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_UpdateSfInvoicemasterInfo, iSet);
            }

            SfInvoicemasterEntity iMst = new SfInvoicemasterEntity();
            iMst.Id = Id;
            SfInvoicemasterEntity iBillGet = (SfInvoicemasterEntity)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetSingleSfInvoicemasterRecordById, iMst);
            string dupes = "";

            if (Convert.ToInt16(iBillGet.Duplicate) > 0)
            {
                dupes = @"<tr>
                    <th>
                        <span style='font-size: 10px;'><b>DUPLICATE-" + iBillGet.Duplicate + @"</b></span>
                    </th>
                </tr>";
            }
            string TableData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6><sup>১</sup>[গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>কর চালানপত্র</h6>
            <h6>[বিধি ৪০ এর উপ-বিধি (১) এর দফা (গ) ও দফা (চ) দ্রষ্টব্য ]</h6>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr>
                    <th>
                        <b>মূসক-৬.৩</b>
                    </th>
                </tr>
                " + dupes + @"

            </table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div style='margin-left:auto;margin-right:auto;'>
                <table class='CompanyInfo'>
                <tr><td>নিবন্ধিত ব্যক্তির নাম</td>
                    <td> : </td>
                    <td>Pakiza Technovation Limited</td>
                </tr>
                <tr><td>নিবন্ধিত ব্যক্তির বিআইএন</td>
                    <td> : </td>
                    <td>00086861616-0306</td>
                </tr>
                <tr><td>চালানপত্র ইস্যুর ঠিকানা</td>
                    <td> : </td>
                    <td>1094, NOWPARA,RASULPUR,NARSINGDI</td>
                </tr></table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div style='margin-left:auto;margin-right:auto;'>
        <table class='buyInfo'>
                <tr>
                    <td>
                        ক্রেতার নাম
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        " + iBillGet.CustomerName + @"
                    </td>
                </tr>
                <tr>
                    <td>
                        ক্রেতার বিআইএন
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        " + iBillGet.NID + @"
                    </td>
                </tr>
                <tr>
                    <td>
                        ক্রেতার ঠিকানা
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        " + iBillGet.CustomerNewAddress + @"
                    </td>
                </tr>
                <tr>
                    <td>
                        সরবরাহের গন্তব্যস্থল
                    </td>
                    <td>
                        :
                    </td>
                    <td class='wrappable'>
                        " + iBillGet.CustomerNewAddress + @"
                    </td>
                </tr>
                <tr>
                    <td>
                        যানবাহনের প্রকৃতি ও নম্বর
                    </td>
                    <td>
                        :
                    </td>
                    <td class='wrappable'>

                    </td>
                </tr>
            </table>

        <table class='chlInfo'>
                <tr>
                    <td>
                        চালানপত্র নম্বর
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        " + iBillGet.Invoiceno + @"
                    </td>
                </tr>
                <tr>
                    <td>
                        ইস্যুর তারিখ
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        " + iBillGet.Invoicedate + @"
                    </td>
                </tr>
                <tr>
                    <td>
                        ইস্যুর সময়
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        " + iBillGet.Createddate + @"
                    </td>
                </tr>

            </table></div></div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <th>
                        ক্রমিক নম্বর
                    </th>
                    <th>
                        পণ্য বা সেবার বর্ণনা (প্রযোজ্য ক্ষেত্রে ব্র্যান্ড নাম সহ)
                    </th>
                    <th>
                        সরবরাহের একক
                    </th>
                    <th>
                        পরিমাণ
                    </th>
                    <th>
                        একক মূল্য <sup>*</sup>(টাকায়)
                    </th>
                    <th>
                        মোট মূল্য <sup>*</sup> (টাকায়)
                    </th>
                    <th>
                        সম্পূরক
                        শুল্কের
                        হার
                    </th>
                    <th>
                        সম্পূরক
                        শুল্কের
                        পরিমাণ
                        (টাকায়)
                    </th>
                    <th>
                        মূল্য
                        সংযোজন
                        করের হার
                        / সুনিদৃষ্ট
                        কর
                    </th>
                    <th>
                        মূল্য
                        সংযোজন
                        কর / সুনিদৃষ্ট
                        কর এর
                        পরিমাণ
                        (টাকায়)
                    </th>
                    <th>
                        সকল প্রকার
                        শুল্ক ও করসহ
                        মূল্য
                    </th>
                </tr>";



            SfInvoicedetailsEntity iRet = new SfInvoicedetailsEntity
            {
                Refid = Id,

            };
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicedetailsRecord, iRet);
            int iCount = 1;
            double dlTotal = 0.0;
            double dlVatCalc = 0.0;
            double dlNetVatCalc = 0.0;
            double dlTotalSD = 0.0;
            foreach (DataRow dr in dt.Rows)
            {

                string ProdName = "";
                //if (iBillGet.isWarrantyActive == "1")
                //{
                //    ProdName = dr["BrandName"] + " - " + GetProductHsCodeById(dr["Productid"].ToString()) + "<br/> Warranty Year: " + dr["WarrantyYrs"];
                //}
                //else
                //{
                ProdName = GetProductHsCodeById(dr["Productid"].ToString());
                //}
                double VatAmt = Convert.ToDouble(dr["VATPer"]);
                double vatCalc = (Convert.ToDouble(dr["VatAmnt"]));
                double netVatCalc = (Convert.ToDouble(dr["Totalprice"]) + Convert.ToDouble(dr["VatAmnt"]) + Convert.ToDouble(dr["SD"]));
                TableData = TableData + @"<tr>
                                        <td>" + iCount + @"</td>
                                        <td>" + ProdName + @"</td>
                                        <td>" + dr["UnitName"] + @"</td>
                                        <td>" + dr["Quantity"] + @"</td>
                                        <td>" + string.Format("{0:n}", dr["Unitprice"]) + @"</td>
                                        <td>" + string.Format("{0:n}", dr["TotalPrice"]) + @"</td>
                                        <td>" + string.Format("{0:n}", dr["SDRate"]) + @"</td>
                                        <td>" + string.Format("{0:n}", dr["SD"]) + @"</td>
                                        <td>" + string.Format("{0:n}", VatAmt) + @"</td>
                                        <td>" + string.Format("{0:n}", vatCalc) + @"</td>
                                        <td>" + string.Format("{0:n}", netVatCalc) + @"</td>
                                    </tr>";

                iCount += 1;

                dlTotal += Convert.ToDouble(dr["Totalprice"]);
                dlVatCalc += vatCalc;
                dlNetVatCalc += netVatCalc;
                dlTotalSD += Convert.ToDouble(dr["SD"]);
                //}
                //}
            }

            TableData = TableData + @"<tr>
                    <td colspan='5'><span style='margin-right:100px;'>সর্বমোট :</span></td>
                    <td>" + string.Format("{0:n}", dlTotal) + @"</td>
                    <td>

                    </td>
                    <td>
                        " + string.Format("{0:n}", dlTotalSD) + @"
                    </td>
                    <td></td>
                    <td>" + string.Format("{0:n}", dlVatCalc) + @"</td>
                    <td>" + string.Format("{0:n}", dlNetVatCalc) + @"</td>
                </tr>
            </table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <div class='CompanyInfoFooter'>
                <p>প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যক্তির নাম <span style='margin-left: 20px;margin-right: 10px;'>:</span></p>
                <p>পদবী <span style='margin-left: 192px;margin-right: 10px;'>:</span></p>
                <p>স্বাক্ষর  <span style='margin-left: 190px;margin-right: 10px;'>:</span></p>
                <p>সীল   <span style='margin-left: 200px;margin-right: 10px;'>:</span></p>
            </div>

        </div>
        <p style='font-size:11px;'>
            ০ উৎসে কর্তন যোগ্য সরবরাহের ক্ষেত্রে ফরমটি সমন্বিত কর চালানপত্র ও উৎসে কর কর্তন সনদপত্র হিসেবে বিবেচিত হইবে এবং উহা
            উৎসে কর কর্তনযোগ্য সরবরাহের ক্ষেত্রে প্রযোজ্য হবে।
        </p><br />
        <p style='margin-top:100px; font-size:11px;'>
            <sup>*</sup> সকল প্রকার কর ব্যতীত মূল্য;
        </p>


    </div>

    <div class='footerLine'>
                <div class='uk-width-1-3'><hr style='border: 1px solid black;'></div>
                <table style='width: 100%' id='totalField'>
                    <tr>
                        <td>
                            <sup>১ </sup><b>এসআরও নং- ২২৬-আইন/২০১৯/৬২-মূসক, তারিখঃ ৩০ জুন, ২০১৯ দ্বারা প্রতিস্থাপিত । </b>
                        </td>
                        <td>
                            Page 1 of 1
                        </td>
                        <td>
                            Print Date:" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"
                        </td>
                    </tr>
                </table>
            </div>
    </form>";
            ViewBag.FormData = TableData;


            return View(iBillGet);

        }
        private string GetMergeItemsNameBill(DataTable dt, string Ids, string refSl, string isWarrant)
        {
            string PName = "";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BatchNo"].ToString() == Ids && dr["RefInvoiceSL"].ToString() == refSl)
                {
                    PName = PName + "<br />" + dr["BrandName"] + " - " + GetProductHsCodeById(dr["Productid"].ToString());
                    if (isWarrant == "1" && !string.IsNullOrEmpty(dr["WarrantyYrs"].ToString()))
                    {
                        PName = PName + "<br /> Warranty Year: " + dr["WarrantyYrs"];
                    }

                }
            }
            return PName;
        }

        #endregion

        #region Mushak 6.4 : Contract Manufacture Challan
        public ActionResult ContractManufactureChallan()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "ContractManufactureChallan");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.4 : Contract Manufacture Challan";
            Session["PageHeader"] = "Mushak 6.4 : Contract Manufacture Challan";
            ViewData["IsReturn"] = GetIsActiveList_();
            InvSubcontactmasterEntity iSet = new InvSubcontactmasterEntity();
            iSet.Issuedate = DateTime.Today.ToString("dd/MM/yyyy");
            iSet.EndDate = DateTime.Today.ToString("dd/MM/yyyy");
            return View(iSet);
        }
        public ActionResult Mushak_6_4_Report(string Id = "")
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "ContractManufactureChallan");
            Session["PageHeader"] = "Mushak 6.4 : Contract Manufacture Challan";
            string TabData = "";
            if (!string.IsNullOrEmpty(Id))
            {
                TabData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>চুক্তিভিত্তিক উৎপাদনের চালানপত্র</h6>
            <h6>[ বিধি ৪০ এর উপ-বিধি (১) এর দফা (ঘ) দ্রষ্টব্য ]</h6>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr style='width: 100%;'>
                    <th style='width: 100%; margin: 0 auto; margin-top:10px; font-size: 15px;'>
                        <b>মূসক-৬.৪</b>
                    </th>
                </tr>
                <tr style='width: 100%;'>
                    <th style='width: 100%; margin: 0 auto; margin-top:10px; font-size: 10px;'>
                        
                    </th>
                </tr>

            </table>
        </div>
    </div>";
                InvSubcontactmasterEntity iSet = new InvSubcontactmasterEntity();
                iSet.Id = Id;
                DataTable dtMaster = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvSubcontactmasterRecord, iSet);

                TabData = TabData + @"<div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:30px;'>
        <div class='EntryCompanyInfo'>
            <p>নিবন্ধিত ব্যক্তির নাম <span style='margin-left: 30px;margin-right: 10px;'>:</span> Pakiza Technovation Ltd. </p>
            <p>নিবন্ধিত ব্যক্তির বিআইএ <span style='margin-left: 10px;margin-right: 10px;'>:</span> 00086861616-0306 </p>
            <p>চালানপত্র ইস্যুর ঠিকানা <span style='margin-left: 14px;margin-right: 10px;'>:</span> 1094, NOWPARA,RASULPUR,NARSINGDI </p>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='BuyerInfo'>
            <p>পণ্য গ্রহীতার নাম <span style='margin-left: 15px;margin-right: 10px;'>:</span> " + dtMaster.Rows[0]["SupplierName"] + @" </p>
            <p>গ্রহীতার বিআইএন <span style='margin-left: 10px;margin-right: 10px;'>:</span> " + dtMaster.Rows[0]["NID"] + @" </p>
            <p>গন্তব্যস্থল <span style='margin-left: 55px;margin-right: 10px;'>:</span> " + dtMaster.Rows[0]["IssueAddress"] + @" </p>
        </div>
        <div class='ChallanInfo'>
            <p>চালান নম্বর <span style='margin-left: 12px;margin-right: 10px;'>:</span> " + dtMaster.Rows[0]["IssueChallanNo"] + @" </p>
            <p>ইস্যুর তারিখ  <span style='margin-left: 9px;margin-right: 10px;'>:</span> " + dtMaster.Rows[0]["IssueDate"] + @" </p>
            <p>ইস্যুর সময় <span style='margin-left: 14px;margin-right: 10px;'>:</span> " + dtMaster.Rows[0]["IssueTime"] + @" </p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:50px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <th>
                        ক্রমিক নম্বর
                    </th>
                    <th>
                        প্রকৃতি (উপকরণ বা উৎপাদিত পণ্য)
                    </th>
                    <th>
                        পণ্যের বিবরণ
                    </th>
                    <th>
                        পরিমাণ
                    </th>
                    <th>
                        মন্তব্য
                    </th>
                </tr>
                <tr>
                    <th>(১)</th>
                    <th>(২)</th>
                    <th>(৩)</th>
                    <th>(৪)</th>
                    <th>(৫)</th>
                </tr>";

                InvSubcontactmasterEntity iSetDet = new InvSubcontactmasterEntity();
                iSetDet.ReportName = "SubConStockForMushak";
                iSetDet.RefID = Id;
                DataTable dtDetails = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvSubcontactmasterRecord, iSetDet);
                int iCounter = 1;
                int countTR = dtDetails.Rows.Count;
                //foreach (DataRow dr in dtDetails.Rows)
                //{
                //    TabData = TabData + @"<tr>
                //    <td> " + iCounter + @" </td>
                //    <td> " + dtMaster.Rows[0]["FinItemName"] + " - " + dtMaster.Rows[0]["Prdqty"]+ " " + dtMaster.Rows[0]["UnitName"] + @" </td>
                //    <td> " + GetProductHsCodeById(dr["RawMatId"].ToString()) + @"  </td>
                //    <td> " + dr["SubCon_Qty"].ToString() + " " + dr["UnitName"] + @" </td>
                //    <td> </td>
                //    </tr>";

                //    iCounter++;
                //}

                for (int i = 0; i < countTR; i++)
                {
                    string Val2 = "";
                    if (i == 0)
                    {
                        Val2 = dtMaster.Rows[0]["FinItemName"] + " - " + dtMaster.Rows[0]["Prdqty"] + " " + dtMaster.Rows[0]["UnitName"];
                    }
                    TabData = TabData + @"<tr>
                    <td> " + iCounter + @" </td>
                    <td> " + Val2 + @" </td>
                    <td> " + GetProductHsCodeById(dtDetails.Rows[i]["RawMatId"].ToString()) + @"  </td>
                    <td> " + dtDetails.Rows[i]["SubCon_Qty"].ToString() + " " + dtDetails.Rows[i]["UnitName"] + @" </td>
                    <td> </td>
                    </tr>";
                }

                TabData = TabData + @"</table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <div class='CompanyInfoFooter'>
                <p>
                    দায়িত্বপ্রাপ্ত কর্মকর্তার স্বাক্ষর <span style='margin-left: 20px;margin-right: 10px;'>:</span>
                </p>
                <p>নাম  <span style='margin-left: 131px;margin-right: 10px;'>:</span></p>

            </div>

        </div>
    </div>

    <div class='footer'>
        <p>Page 1 of 1</p>
    </div>
    <div class='footer2'>
        <p>Print Date: </p>
    </div>
</form>";
            }

            ViewBag.FormData = TabData;
            return View();

        }
        #endregion

        #region Mushak 6.5
        public ActionResult GoodsTransferChallan()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "GoodsTransferChallan");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.5 : Goods Transfer Challan";
            Session["PageHeader"] = "Mushak 6.5 : Goods Transfer Challan";
            ViewData["IsReturn"] = GetIsActiveList_();
            InvStocktransfermasterEntity iSet = new InvStocktransfermasterEntity
            {
                StartDate = DateTime.Now.ToString("01/MM/yyyy"),
                EndDate = DateTime.Now.ToString("dd/MM/yyyy")
            };
            return View(iSet);
        }
        //GetGoodsTransferRecordList
        [HttpPost]
        public JsonResult GetGoodsTransferRecordList(string StartDate = "", string EndDate = "")
        {
            InvStocktransfermasterEntity iSet = new InvStocktransfermasterEntity();

            iSet.StartDate = StartDate;
            iSet.EndDate = EndDate;
            //iSet.Approvalstatus = "1";
            //iSet.DispatchStatus = "1";
            //iSet.ChallanStatus = "1";

            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStocktransfermasterRecord, iSet);

            int iCount = 1;
            string TableData = "";
            foreach (DataRow dr in dt.Rows)
            {
                string prntBtn = "<i onclick=\"GoToReportView('" + dr["Id"] + "');\" class='md-24 material-icons md-color-green-500' title='Print Report'>&#XE8AD;</i>";

                TableData = TableData + "<tr>"
                                  + "<td>" + prntBtn + "</td>"
                                  + "<td>" + iCount + "</td>"
                                  + "<td>" + Convert.ToDouble(dr["TransferNo"]).ToString("0000") + "</td>"
                                  + "<td>" + dr["TransferDate"] + "</td>"
                                  + "<td>" + (!string.IsNullOrEmpty(dr["ChallanNo"].ToString()) ? Convert.ToDouble(dr["ChallanNo"]).ToString("0000") : "") + "</td>"
                                  + "<td>" + dr["ChallanDate"] + "</td>"
                                  + "<td>" + dr["CurrBranchTxt"] + "</td>"
                                  + "<td>" + dr["TrToTxt"] + "</td>"
                                  + "</tr>";


                iCount = iCount + 1;
            }
            string tHead = "<tr><th></th><th>SL</th><th>Transfer No</th><th>Transfer Date</th><th>Challan No</th><th>Challan Date</th><th>Transfer From</th><th>Transfer To</th></tr>";

            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>"
                        + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Mushak_6_5_Report(string Id)
        {
            //mm
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "GoodsTransferChallan");
            Session["PageHeader"] = "Mushak 6.5 :  Goods Transfer Challan";

            InvStocktransfermasterEntity iRet = new InvStocktransfermasterEntity();
            iRet.Id = Id;
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStocktransfermasterRecord, iRet);

            string TableData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>কেন্দ্রীয় নিবন্ধিত প্রতিষ্ঠানের পণ্য স্থানান্তরের চালানপত্র</h6>
            <h6>[ বিধি ৪০ এর উপ বিধি (১) এর দফা (ঙ) দ্রষ্টব্য ]</h6>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr>
                    <th>
                        <b>মূসক  ৬.৫</b>
                    </th>
                </tr>
            </table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='EntryCompanyInfo'>
            <p>নিবন্ধিত ব্যক্তির নাম <span style='margin-left: 168px;margin-right: 10px;'>:</span> Pakiza Technovation Ltd. </p>
            <p>নিবন্ধিত ব্যক্তির বিআইএন <span style='margin-left: 148px;margin-right: 10px;'>:</span> 00086861616-0306 </p>
            <p>প্রেরণকারী ইউনিট/শাখা/পণ্যাগারের নাম ও ঠিকানা <span style='margin-left: 16px;margin-right: 10px;'>:</span> " + dt.Rows[0]["CurrBranchTxt"] + @" </p>
            <p>গ্রহীতা ইউনিট/শাখা/পণ্যাগারের নাম ও ঠিকানা <span style='margin-left: 36px;margin-right: 10px;'>:</span> " + dt.Rows[0]["TrToTxt"] + @" </p>
        </div>
    </div>
    <div class='BuyerInfo'>
        <p>চালান নম্বর <span style='margin-left: 18px;margin-right: 15px;'>:</span>" + Convert.ToDouble(dt.Rows[0]["ChallanNo"]).ToString("0000") + @"</p>
        <p>ইস্যুর তারিখ <span style='margin-left: 15px;margin-right: 15px;'>:</span>" + dt.Rows[0]["ChallanDate"] + @"</p>
        <p>ইস্যুর সময় <span style='margin-left: 20px;margin-right: 15px;'>:</span>" + dt.Rows[0]["IssueTime"] + @"</p>
        <p>যানবাহনের প্রকৃতি ও নম্বর <span style='margin-left: 20px;margin-right: 15px;'>:</span></p>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:100px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <th>
                        ক্রমিক নম্বর
                    </th>
                    <th>
                        পণ্যের (প্রযোজ্য ক্ষেত্রে সুনিদৃষ্ট ব্র্যান্ড নাম সহ) বর্ণনা
                    </th>
                    <th>
                        পরিমাণ
                    </th>
                    <th>
                        মূল্য
                    </th>
                    <th>
                        মন্তব্য
                    </th>
                </tr>
                <tr>
                    <th>(১)</th>
                    <th>(২)</th>
                    <th>(৩)</th>
                    <th>(৪)</th>
                    <th>(৫)</th>
                </tr>";

            int colCount = 1;
            DataTable dtDetail = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStocktransferdetailsRecord, Id);
            if (dtDetail.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetail.Rows)
                {
                    TableData = TableData + @"<tr>
                    <td>" + colCount + @"</td>
                    <td>" + GetProductHsCodeById(dr["ItemId"].ToString()) + @"</td>
                    <td>" + dr["Quantity"].ToString() + @"</td>
                    <td>" + GetCommaFormat(Convert.ToDouble(dr["UnitPrice"]) + Convert.ToDouble(dr["VatAmnt"])) + @"</td>
                    <td> </td>
                    </tr>";
                    colCount += 1;
                }

            }
            else
            {
                TableData = TableData + @"<tr>
                    <td colspan='6'> Something Went Wrong!! </td>
                    </tr>";
            }


            TableData = TableData + @"</table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <div class='CompanyInfoFooter'>
                <p>প্রতিষ্ঠান কর্তৃপক্ষের দায়িত্বপ্রাপ্ত ব্যক্তির নাম <span style='margin-left: 20px;margin-right: 10px;'>:</span></p>
                <p>পদবী <span style='margin-left: 192px;margin-right: 10px;'>:</span></p>
                <p>স্বাক্ষর  <span style='margin-left: 190px;margin-right: 10px;'>:</span></p>
                <p>সীল   <span style='margin-left: 200px;margin-right: 10px;'>:</span></p>
            </div>
        </div>
    </div>

    <div class='footer'>
        <p>Page 1 of 1</p>
    </div>
    <div class='footer2'>
        <p>Print Date: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"</p>
    </div>
</form>";
            ViewBag.FullFormData = TableData;
            return View();
        }
        #endregion

        #region Mushak 6.5 (A)
        public ActionResult GoodsTransferRegister()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "GoodsTransferRegister");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.5 (A) : Goods Transfer Register";
            Session["PageHeader"] = "Mushak 6.5 (A) : Goods Transfer Register";
            ViewData["IsReturn"] = GetIsActiveList_();
            InvStocktransfermasterEntity iSet = new InvStocktransfermasterEntity
            {
                StartDate = DateTime.Now.ToString("01/MM/yyyy"),
                EndDate = DateTime.Now.ToString("dd/MM/yyyy")
            };
            return View(iSet);
        }
        //GetGoodsTransferRecordListForRegister
        [HttpPost]
        public JsonResult GetGoodsTransferRecordListForRegister(string StartDate = "", string EndDate = "")
        {
            InvStocktransfermasterEntity iSet = new InvStocktransfermasterEntity();
            iSet.StartDate = StartDate;
            iSet.EndDate = EndDate;
            iSet.Approvalstatus = "1";
            iSet.DispatchStatus = "1";
            iSet.ChallanStatus = "1";
            //iSet.ReportFlag = "TransferRegister";
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStocktransfermasterRecord, iSet);

            int iCount = 1;
            string TableData = "";
            foreach (DataRow dr in dt.Rows)
            {
                //string prntBtn = "<i onclick=\"GoToReportView('" + dr["Id"] + "');\" class='md-24 material-icons md-color-green-500' title='Print Report'>&#XE8AD;</i>";

                TableData = TableData + "<tr>"
                                  + "<td>" + iCount + "</td>"
                                  + "<td>" + Convert.ToDouble(dr["TransferNo"]).ToString("0000") + "</td>"
                                  + "<td>" + dr["TransferDate"] + "</td>"
                                  + "<td>" + (!string.IsNullOrEmpty(dr["ChallanNo"].ToString()) ? Convert.ToDouble(dr["ChallanNo"]).ToString("0000") : "") + "</td>"
                                  + "<td>" + dr["ChallanDate"] + "</td>"
                                  + "<td>" + dr["CurrBranchTxt"] + "</td>"
                                  + "<td>" + dr["TrToTxt"] + "</td>"
                                  + "</tr>";


                iCount = iCount + 1;
            }
            string tHead = "<tr><th>SL</th><th>Transfer No</th><th>Transfer Date</th><th>Challan No</th><th>Challan Date</th><th>Transfer From</th><th>Transfer To</th></tr>";

            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>"
                        + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Mushak_6_5A_Report(string StartDate = "", string EndDate = "")
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "GoodsTransferRegister");
            Session["PageHeader"] = "Mushak 6.5 (A) :  Goods Transfer Register ";
            string TableData = "";
            TableData = TableData + @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='headerInfo'>
            <h6>'ছক-ক'</h6>
            <h6>কেন্দ্রীয় ইউনিট হইতে বিক্রয় ইউনিট স্থানান্তরিত পণ্য/সেবা বিবরণী</h6>
            <h6>[বিধি ৭ দ্রষ্টব্য]</h6>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:50px;'>
        <table id='tableMain'>
            <tr>
                <th>
                    কেন্দ্রীয় নিবন্ধিত ব্যাক্তির নাম ও
                    বিআইএন
                </th>
                <th>
                    পণ্য/সেবা প্রেরণকারী ইউনিটের নাম ও
                    ঠিকানা
                </th>
                <th>
                    পণ্য/সেবা গ্রহীতা ইউনিটের নাম ও ঠিকানা
                </th>
                <th>
                    কেন্দ্রীয় ইউনিট হইতে
                    ইস্যুকৃত পণ্য/সেবা
                    স্থানান্তর চালানপত্র
                    বইয়ের নম্বর ও ইস্যুর
                    তারিখ
                </th>
                <th>
                    পণ্য/সেবা স্থানান্তর
                    চালানপত্র ফরম
                    'মূসক-৬.৫' নম্বর ও
                    তারিখ
                </th>
                <th>
                    স্থানান্তরিত পণ্য বা সেবার
                    বিবরণ (প্রযোজ্য ক্ষেত্রে
                    সুনির্দিষ্ট ব্র্যান্ড নামসহ)
                </th>
                <th>
                    স্থানান্তরিত পণ্য বা
                    সেবার পরিমাণ
                </th>
                <th>
                    স্থানান্তরিত পণ্য বা
                    সেবার কর ব্যাতীত
                    মূল্য
                </th>
                <th>
                    স্থানান্তরিত পণ্য বা
                    সেবার ক্ষেত্রে
                    প্রযোজ্য করের
                    পরিমাণ
                </th>
            </tr>
            <tr>
                <th>(১)</th>
                <th>(২)</th>
                <th>(৩)</th>
                <th>(৪)</th>
                <th>(৫)</th>
                <th>(৬)</th>
                <th>(৭)</th>
                <th>(৮)</th>
                <th>(৯)</th>
            </tr>";

            InvStocktransfermasterEntity iSet = new InvStocktransfermasterEntity();
            iSet.StartDate = StartDate;
            iSet.EndDate = EndDate;
            iSet.Approvalstatus = "1";
            iSet.DispatchStatus = "1";
            iSet.ChallanStatus = "1";
            iSet.ReportFlag = "TransferRegister";
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStocktransfermasterRecord, iSet);
            int iCount = 1;
            foreach (DataRow dr in dt.Rows)
            {
                TableData = TableData + @"<tr>
                        <td>
                           Pakiza Technovation Ltd.,
                            00086861616-0306
                        </td>
                        <td>
                            " + dr["CurrBranchTxt"] + ", " + dr["TrFromAddress"] + @"
                        </td>
                        <td>
                            " + dr["TrToTxt"] + ", " + dr["TrToAddress"] + @"
                        </td>
                        <td>
                            " + Convert.ToDouble(dr["TransferNo"]).ToString("0000") + ", " + dr["TransferDate"] + @"
                        </td>
                        <td>
                            " + Convert.ToDouble(dr["ChallanNo"]).ToString("0000") + ", " + dr["ChallanDate"] + @"
                        </td>
                        <td>
                            " + GetProductHsCodeById(dr["ItemId"].ToString()) + @"
                        </td>
                        <td>
                            " + dr["Quantity"].ToString() + @"
                        </td>
                        <td>
                            " + dr["UnitPrice"].ToString() + @"
                        </td>
                        <td>
                            " + dr["VatAmnt"].ToString() + @"
                        </td>
                    </tr>";
                iCount += 1;
            }


            TableData = TableData + @"</table>
                                        </div>  
                                        <div class='footer'>
                                            <p>Page 1 of 1</p>
                                        </div>
                                        <div class='footer2'>
                                            <p>Print Date: </p>
                                        </div>
                                    </form>";

            ViewBag.FormData = TableData;
            return View();
        }
        #endregion

        #region Mushak 6.5 (B)
        public ActionResult GoodsSalesRegister()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "GoodsSalesRegister");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.5 (B) : Goods Sales Register";
            Session["PageHeader"] = "Mushak 6.5 (B) : Goods Sales Register";
            ViewData["IsReturn"] = GetIsActiveList_();
            return View();
        }
        public ActionResult Mushak_6_5B_Report()
        {

            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "GoodsSalesRegister");
            Session["PageHeader"] = "Mushak 6.5 (B) :  Goods Sales Register ";
            return View();

        }
        #endregion

        #region 6.6 VDS Certificate
        public ActionResult VDSCertificate()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "VDSCertificate");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.6 : VDS Certificate";
            Session["PageHeader"] = "Mushak 6.6 : VDS Certificate";
            ViewData["IsReturn"] = GetIsActiveList_();
            return View();
        }

        public ActionResult VDSCertificate6_6(string Id)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "VDSCertificate");
            Session["PageHeader"] = "Mushak 6.6 : VDS Certificate";

            string fullData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
                <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
                    <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
                </div>
                <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
                    <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
                    <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
                    <h6>উৎসে কর কর্তন সনদপত্র</h6>
                    <h6>[ বিধি ৪০ এর উপ বিধি (১) এর দফা (চ) দ্রষ্টব্য ]</h6>
                </div>
                <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

                </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                    <table style='width: 10%; float: right; margin-right:80px;'>
                        <tr>
                            <th>
                                <b>মূসক ৬.৬</b>
                            </th>
                        </tr>

                    </table>
                </div>
            </div>";

            VatVdsIssueEntity iSet = new VatVdsIssueEntity();
            iSet.Id = Id;
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllVatVdsIssueRecord, iSet);
            string dlYear = "", CertificateNo = "";
            if (!string.IsNullOrEmpty(dt.Rows[0]["CertificateDate"].ToString()))
            {
                dlYear = dt.Rows[0]["CertificateDate"].ToString().Substring(8, 2);
            }
            if (!string.IsNullOrEmpty(dlYear))
            {
                CertificateNo = dlYear + "-CF-" + Convert.ToDouble(dt.Rows[0]["CertificateNo"]).ToString("000000");
            }

            fullData = fullData + @"<div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top:50px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                    <table id='tableIntr'>
                        <tr>
                            <th style='width: 50%;'>
                                উৎসে কর কর্তনকারী সত্তার নাম
                            </th>
                            <td style='width: 5%;'>
                                :
                            </td>
                            <td style='text-align: left;'>Pakiza Technovation Limited</td>
                        </tr>
                        <tr>
                            <th style='width: 50%;'>
                                উৎসে কর কর্তনকারী সত্তার ঠিকানা
                            </th>
                            <td style='width: 5%;'>
                                :
                            </td>
                            <td style='text-align: left;'> 1094, NOWPARA,RASULPUR,NARSINGDI </td>
                        </tr>
                        <tr>
                            <th style='width: 50%;'>
                                উৎসে কর কর্তনকারী সত্তার বিআইএন (প্রযোজ্য ক্ষেত্রে)
                            </th>
                            <td style='width: 5%;'>
                                :
                            </td>
                            <td style='text-align: left;'> 00086861616-0306 </td>
                        </tr>
                    </table>
                    <p style='margin-top:30px;float:left;width:70%;'>উৎসে কর কর্তন সনদপত্র নং <span style='margin-left: 20px;margin-right: 10px;'>:</span>" + CertificateNo + @"</p>
                    <p style='margin-top:30px;float:right;width:30%;'>জারির তারিখ <span style='margin-left: 20px;margin-right: 10px;'>:</span>" + dt.Rows[0]["CertificateDate"] + @"</p>
                    <p>
                        এই মর্মে প্রত্যয়ন করা যাইতেছে যে, আইনের ধারা ৪৯ অনুযায়ী উৎসে কর কর্তনযোগ্য সরবরাহ হইতে প্রযোজ্য মূল্য সংযোজন কর বাবদ উৎসে কর
                        কর্তন করা হইল। কর্তনকৃত মূল্য সংযোজন করের অর্থ বুক ট্রান্সফার/ট্রেজারি চালান/দাখিলপত্রে বৃদ্ধিকারী সমন্বয়ের মাধ্যমে সরকারি কোষাগারে জমা
                        প্রদান করা হইয়াছে। কপি এতদসংগে সংযুক্ত করা হইল (প্রযোজ্য ক্ষেত্রে)।
                    </p>
                </div>
            </div>


            <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:50px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                    <table id='tableMain'>
                        <tr>
                            <th rowspan='2'>
                                ক্রমিক
                                নং
                            </th>
                            <th colspan='2'>
                                সরবরাহকারীর
                            </th>
                            <th colspan='2'>
                                সংশ্লিষ্ট কর চালানপত্র
                            </th>
                            <th rowspan='2'>
                                মোট সরবরাহ
                                মূল্য ১ (টাকা)
                            </th>
                            <th rowspan='2'>
                                মূসকের
                                পরিমাণ
                                (টাকা)
                            </th>
                            <th rowspan='2'>
                                উৎসে
                                কর্তনকৃত
                                মূসকের
                                পরিমাণ
                                (টাকা)
                            </th>
                        </tr>

                        <tr>
                            <th>
                                নাম
                            </th>
                            <th>
                                বিআইএন
                            </th>
                            <th>
                                নম্বর
                            </th>
                            <th>
                                ইস্যুর
                                তারিখ
                            </th>
                        </tr>";
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                fullData = fullData + @"<tr>
                            <td>" + i + @"</td>
                            <td>" + dr["SupplierName"] + @"</td>
                            <td>" + dr["NID"] + @"</td>
                            <td>" + dr["ChallanNo"] + @"</td>
                            <td>" + dr["ChallanData"] + @"</td>
                            <td>" + dr["TotalAmount"] + @"</td>
                            <td>" + dr["TotalVAT"] + @"</td>
                            <td>" + dr["TotalVDS"] + @"</td>
                        </tr>";

                i += 1;
            }

            fullData = fullData + @" </table>
                </div>

            </div>
            <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:50px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                    <p style='margin-left: 5%;'>ক্ষমতাপ্রাপ্ত কর্মকর্তার </p>
                    <p style='margin-left: 5%;'>স্বাক্ষর <span style='margin-left: 20px;margin-right: 10px;'>:</span>  </p>
                    <p style='margin-left: 5%;'>নাম <span style='margin-left: 32px;margin-right: 10px;'>:</span>  </p>
                    <p style='margin-left: 5%;margin-top: 10%;'>_____________________________________________________________________ </p>
                    <p style='margin-left: 5%;margin-top: -1%;'>১ মূসক ও সম্পূরক শুল্ক (যদি থাকে) সহ মূল্য। </p>
                </div>
            </div>
            <div class='footer'>
                <p>Page 1 of 1</p>
            </div>
            <div class='footer2'>
                <p>Print Date: </p>
            </div>
        </form>";
            ViewBag.FullFormData = fullData;
            return View();

        }
        #endregion

        #region 6.7 Credit Note
        public ActionResult CreditNotes()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "CreditNotes");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.7 : Credit Notes";
            Session["PageHeader"] = "Mushak 6.7: Credit Notes";

            InventoryBaseController objBase = new InventoryBaseController();
            InventoryBaseController objInventoryBase = new InventoryBaseController();
            AdmBaseController objAdmBase = new AdmBaseController();
            OperationsBaseController objOperationBase = new OperationsBaseController();

            ViewData["IsReturn"] = GetIsActiveList_();
            //ViewData["ProductLists"] = aBase.GetItemslist(); ViewData["CustomerList"] = GetCustomerlist();
            ViewData["CustomerList"] = objOperationBase.GetCustomerlist();
            //Inventory.Controllers.InventoryBaseController iInv = new Inventory.Controllers.InventoryBaseController();
            ViewData["SalesLeadList"] = objBase.GetSalesLeadList();
            ViewData["SalespointList"] = objOperationBase.GetSalesPointList();

            List<SfInvoicedetailsEntity> ItemList = new List<SfInvoicedetailsEntity>();
            Session["ssnListData"] = ItemList;

            List<SelectListItem> Items = new List<SelectListItem>
            {
                new SelectListItem { Text = "-----Select-----", Value = "" }
            };
            ViewData["CategoryList"] = objInventoryBase.GetCategorylist();
            ViewData["LOBList"] = objInventoryBase.GetLobListData();
            ViewData["BrandList"] = objInventoryBase.GetBrandlist();
            ViewData["NumberCountList"] = objInventoryBase.GetNumericCountlist();
            ViewData["BlankList"] = Items;
            ViewData["ModelLists"] = Items;
            ViewData["ItemsList"] = objInventoryBase.GetItemslist("2");
            ViewData["VATCategoryList"] = objAdmBase.GetAllVATCategoryList("1");
            ViewData["GetBranchlist"] = objAdmBase.GetAllBranchList("1");
            Session["ssnAttachmentName"] = "";

            SfInvoicemasterEntity obj = new SfInvoicemasterEntity
            {
                Id = "0",
                Vatper = "0",
                Invoicedate = DateTime.Now.ToString("dd/MM/yyyy"),
                EndDate = DateTime.Today.ToString("dd/MM/yyyy"),
                StartDate = DateTime.Now.ToString("dd/MM/yyyy"),
                ReceivedateSearch = DateTime.Now.ToString("dd/MM/yyyy"),
                Updateddate = DateTime.Today.ToString("dd/MM/yyyy"),
            };

            //obj.Id = "0";
            //obj.Vatper = "0";
            //obj.EndDate = DateTime.Now.ToString("dd/MM/yyyy");
            //obj.StartDate = DateTime.Now.ToString("01/MM/yyyy");

            return View(obj);
        }

        [HttpPost]
        public JsonResult GetCreditNoteList(string StartDate = "", string EndDate = "", string CreditStatus = "")
        {
            try
            {
                SfInvoicemasterEntity iSet = new SfInvoicemasterEntity();
                iSet.ReceivedateSearch = StartDate;
                iSet.EndDate = EndDate;
                iSet.ReportName = "CreditNoteRpt";
                DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicemasterRecord, iSet);

                int iCount = 1;
                string TableData = "", Edit = "";
                foreach (DataRow dr in dt.Rows)
                {
                    //Edit = "<i onclick=\"OpenPopupModel('" + dr["ID"] + "');\" title='Send for Debit Note' class='md-icon md-24 material-icons md-color-red-400'>&#XE254;</i>";
                    string dlYear = "", dbNoteNo = "", ChlnNo = "", ChlnDate = "";
                    if (!string.IsNullOrEmpty(dr["EntryDate"].ToString()))
                    {
                        dlYear = dr["EntryDate"].ToString().Substring(8, 2);
                    }
                    ChlnNo = dr["InvoiceNo"].ToString();
                    ChlnDate = dr["InvoiceDate"].ToString();

                    if (!string.IsNullOrEmpty(dlYear))
                    {
                        dbNoteNo = dlYear + "-CN-" + Convert.ToDouble(dr["CreditNoteNo"]).ToString("000000");
                    }


                    Edit = "<i onclick=\"GoToReportView('" + dr["CN_ID"] + "');\" title='Debit Note' class='md-icon md-24 material-icons md-color-green-400'>&#XE85D;</i>";


                    TableData = TableData + "<tr>"
                                          + "<td>" + Edit + "</td>"
                                          + "<td>" + iCount + "</td>"
                                          + "<td>" + dbNoteNo + "</td>"
                                          + "<td>" + dr["EntryDate"] + "</td>"
                                          + "<td>" + ChlnNo + "</td>"
                                          + "<td>" + dr["CustomerName"] + "</td>"
                                          + "<td>" + dr["BranchName"] + "</td>"
                                          + "<td>" + dr["CreditNoteReason"] + "</td>"
                                          + "</tr>";

                    iCount += 1;
                }

                string tHead = "<tr><th style='width:15px;'></th><th style='width:15px;'>SL</th><th>Credit Note No</th><th>Entry Date</th><th>Invoice No</th><th>Supplier Name</th><th>From Store</th><th>Credit Note Reason</th></tr>";

                TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

                return Json(TableData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public ActionResult CreditNotes6_7_Old(string Id = "")
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "CreditNotes");
            ViewBag.PageModule = "Mushak";
            ViewBag.PageModuleName = "Mushak";
            Session["PageHeader"] = "Mushak 6.7 : Credit Notes";
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.7 : Credit Notes";
            SfInvoicemasterEntity objInvoiceMaster = new SfInvoicemasterEntity
            {
                Id = Id,
                ReportName = "CreditNoteRpt"
            };
            DataTable dtInvoiceMaster = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicemasterRecord, objInvoiceMaster);
            string dlYear = dtInvoiceMaster.Rows[0]["EntryDate"].ToString().Substring(8, 2);
            string CNNoteNo = dlYear + "-CN-" + Convert.ToDouble(dtInvoiceMaster.Rows[0]["CreditNoteNo"]).ToString("000000");

            string FormData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
            <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
            </div>
            <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>ক্রেডিট নোট</h6>
            <h6>
                [ বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ) দ্রষ্টব্য ]
            </h6>
            </div>
            <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

            </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr style='width: 100%;'>
                    <th style='width: 100%; margin: 0 auto; margin-top:10px; font-size: 15px;'>
                       <b>মূসক-৬.৭</b>
                    </th>
                </tr>
            </table>
            </div>
            </div>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
            <div class='EntryCompanyInfo'>
             <p><u>ফেরত প্রদানকারী ব্যক্তির -</u> </p>
            </div>
            </div>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
            <div class='BuyerInfo'>
            <p>নাম <span style='margin-left: 113px;margin-right: 10px;'>:</span> " + dtInvoiceMaster.Rows[0]["CustomerName"] + @" </p>
            <p>বিআইএন <span style='margin-left: 84px;margin-right: 10px;'>:</span></p>
            <p>মূল চালান নম্বর <span style='margin-left: 55px;margin-right: 10px;'>:</span> " + dtInvoiceMaster.Rows[0]["InvoiceNo"] + @" </p>
            <p>মূল চালান ইস্যুর তারিখ <span style='margin-left: 18px;margin-right: 10px;'>:</span> " + dtInvoiceMaster.Rows[0]["InvoiceDate"] + @" </p>
            </div>
            <div class='ChallanInfo'>
            <p style='margin-top: -11%;margin-bottom: 9%;'>
                <u>
                    ফেরত গ্রহণকারী ব্যক্তির -
                </u>
            </p>
            <p>নাম <span style='margin-left: 82px;margin-right: 10px;'>:</span> Pakiza Technovation Ltd. </p>
            <p>বিআইএন <span style='margin-left: 53px;margin-right: 10px;'>:</span> 00086861616-0306 </p>
            <p>ক্রেডিট নোট নম্বর <span style='margin-left: 14px;margin-right: 10px;'>:</span> " + CNNoteNo + @" </p>
            <p>ইস্যুর তারিখ <span style='margin-left: 45px;margin-right: 10px;'>:</span> " + dtInvoiceMaster.Rows[0]["EntryDate"] + @" </p>
            <p>ইস্যুর সময় <span style='margin-left: 51px;margin-right: 10px;'>:</span> 12:44:28 pm </p>
            </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:80px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <th>
                        ক্রমিক নম্বর
                    </th>
                    <th>
                        ফেরতপ্রাপ্ত সরবরাহের বিবরণ
                    </th>
                    <th>
                        সরবরাহের একক
                    </th>
                    <th>
                        পরিমাণ
                    </th>
                    <th>
                        একক মূল্য <sup>১</sup>
                        (টাকায়)
                    </th>
                    <th>
                        মোট মূল্য
                        (টাকায়)
                    </th>
                </tr>";

            SfInvoicedetailsEntity objInvoiceDetails = new SfInvoicedetailsEntity
            {
                Refid = Id,
                ReportName = "6.7"
            };
            DataTable dtInvoiceDetails = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicedetailsRecord, objInvoiceDetails);
            int iCounter = 1;

            double dlTotalPrice = 0.00;
            double dlDeduct = 0.00;
            double dlTotalVat = 0.00;
            double dlTotalSD = 0.00;
            double dlNetTotalWMushak = 0.00;
            string reasons = "";
            foreach (DataRow dr in dtInvoiceDetails.Rows)
            {
                double unitSd = Convert.ToDouble(dr["CN_SD"]) / Convert.ToDouble(dr["CN_Qty"]);
                double unitVat = Convert.ToDouble(dr["CN_VatAmnt"]) / Convert.ToDouble(dr["CN_Qty"]);

                FormData = FormData + @"<tr>
                    <td> " + iCounter + @"</td>
                    <td>" + GetProductHsCodeById(dr["ProductId"].ToString()) + @"</td>
                    <td>" + dr["UnitName"].ToString() + @"</td>
                    <td>" + dr["CN_Qty"].ToString() + @"</td>
                    <td>" + (Convert.ToDouble(dr["CN_UnitPrice"]) + unitSd + unitVat).ToString("0.000") + @"</td>
                    <td>" + dr["CN_NetAmnt"].ToString() + @"</td>
                </tr>";
                iCounter += 1;

                dlTotalPrice += Convert.ToDouble(dr["CN_TotalPrice"]);
                dlTotalSD += Convert.ToDouble(dr["CN_SD"]);
                dlTotalVat += Convert.ToDouble(dr["CN_VatAmnt"]);
                dlNetTotalWMushak += Convert.ToDouble(dr["CN_NetAmnt"]);

                reasons = reasons + dr["Reason"].ToString() + "<br/>";
            }
            FormData = FormData + @"<tr>
            <td colspan='5' style='text-align:right'>
            মোট মূল্য
            </td>
            <td>" + dlTotalPrice.ToString("0.000") + @"</td>
            </tr>
            <tr>
            <td colspan='5' style='text-align:right'>
            বাদ কর্তন <sup>২</sup>
            </td>
            <td> 0.00</td>
            </tr>
            <tr>
            <td colspan='5' style='text-align:right'>
            মূসকসহ মূল্য
            </td>
            <td>" + dlNetTotalWMushak.ToString("0.000") + @"</td>
            </tr>
            <tr>
            <td colspan='5' style='text-align:right'>
            মূসকের পরিমাণ
            </td>
            <td>" + dlTotalVat.ToString("0.000") + @"</td>
            </tr>
            <tr>
            <td colspan='5' style='text-align:right'>
            সম্পূরক শুল্কের পরিমাণ
            </td>
            <td>" + dlTotalSD.ToString("0.000") + @"</td>
            </tr>
            <tr>
            <td colspan='5' style='text-align:right'>
            মোট কর <sup>৩</sup>
            </td>
            <td>" + (dlTotalVat + dlTotalSD).ToString("0.000") + @"</td>
            </tr>
            </table>
            <div class='RerurnCouse'>
            <br />
            <p>ফেরতের কারণ</p>
            <table style='width:100%'>
            <tr>
            <td style='font-weight:normal;padding:15px'>" + reasons + @"</td>
            </tr>
            </table>
            </div>
            </div>
            </div>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <div class='CompanyInfoFooter'>
            <p style='margin-top:-15%'>
            দায়িত্বপ্রাপ্ত ব্যক্তির স্বাক্ষর
            </p>
            <p style='margin-top:20%;'><hr class='hrStyle'></p>
            <p>১ প্রতি একক পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
            <p>
            ২ ফেরত প্রদানের জন্য কোনো ধরণের কর্তন থাকিলে উহার পরিমান।
            </p>
            <p>

            ৩ মূসক ও সম্পূরক শুল্কের যোগফল।
            </p>

            </div>

            </div>
            </div>

            <div class='footer'>
            <p>Page 1 of 1</p>
            </div>
            <div class='footer2'>
            <p>Print Date: </p>
            </div>
            </form>";

            ViewBag.FormDataFull = FormData;

            return View("CreditNotes6_7_NewFormat");

        }

        public ActionResult CreditNotes6_7(string Id = "")
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "CreditNotes");
            ViewBag.PageModule = "Mushak";
            ViewBag.PageModuleName = "Mushak";
            Session["PageHeader"] = "Mushak 6.7 : Credit Notes";
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.7 : Credit Notes";
            SfInvoicemasterEntity objInvoiceMaster = new SfInvoicemasterEntity
            {
                Id = Id,
                ReportName = "CreditNoteRpt"
            };
            DataTable dtInvoiceMaster = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicemasterRecord, objInvoiceMaster);
            string dlYear = dtInvoiceMaster.Rows[0]["EntryDate"].ToString().Substring(8, 2);
            string CNNoteNo = dlYear + "-CN-" + Convert.ToDouble(dtInvoiceMaster.Rows[0]["CreditNoteNo"]).ToString("000000");

            string FormData = @"<form id='InputForm' action=''>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <p id='corners2'><b>মূসক-৬.৭</b></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-1' style='text-align:center;'>
            <h6><b>ক্রেডিট নোট</b></h6>
            <h6> [ বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ) দ্রষ্টব্য ]</h6>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-3' style='text-align:left;'>

        </div>
        <div class='uk-width-medium-1-6' style='text-align:center;'>

        </div>
        <div class='uk-width-medium-1-3' style='text-align:right; border-left: 3px solid black;'>
            <p style='text-align:left;'>ক্রেডিট নোট নম্বর<span style='margin-left: 14px;margin-right: 10px;'>:</span>" + CNNoteNo + @"</p>
            <p style='text-align:left;'>ইস্যুর তারিখ<span style='margin-left: 14px;margin-right: 10px;'>:</span>" + dtInvoiceMaster.Rows[0]["EntryDate"] + @"</p>
            <p style='text-align:left;'>ইস্যুর সময়<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-1' style='text-align:left;'>
            <p style='text-align:left;'>নিবন্ধিত ব্যক্তির নাম<span style='margin-left: 14px;margin-right: 10px;'>:</span>Pakiza Technovation Ltd.</p>
            <p style='text-align:left;'>নিবন্ধিত ব্যক্তির বিআইএন<span style='margin-left: 14px;margin-right: 10px;'>:</span>00086861616-0306</p>
            <p style='text-align:left;'>নিবন্ধিত ব্যক্তির ঠিকানা<span style='margin-left: 14px;margin-right: 10px;'>:</span>1094, NOWPARA,RASULPUR,NARSINGDI</p>
            <p style='text-align:left;'>ক্রেতা/গ্রহিতার নাম<span style='margin-left: 14px;margin-right: 10px;'>:</span>" + dtInvoiceMaster.Rows[0]["CustomerName"] + @"</p>
            <p style='text-align:left;'>ক্রেতা/গ্রহিতার বিআইএন<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>ঠিকানা<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>যানবাহনের প্রকৃতি ও নম্বর<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tableMain'>
                <tr>
                    <th rowspan='2'>ক্রমিক নং</th>
                    <th rowspan='2'>কর চালানপত্রের নম্বর ও তারিখ</th>
                    <th rowspan='2'>ক্রেডিট নোট ইস্যুর কারণ</th>
                    <th colspan='4'>চালানপত্রে উল্লিখিত সরবরাহের</th>
                    <th colspan='4'>হ্রাসকারী সমন্বয়ের সহিত সংশ্লিষ্ট</th>
                </tr>
                <tr>
                    <th>মূল্য<sup>১</sup></th>
                    <th>পরিমাণ</th>
                    <th>মূল্য সংযোজন করের পরিমাণ</th>
                    <th>সম্পূরক শুল্কের পরিমাণ</th>
                    <th>মূল্য<sup>১</sup></th>
                    <th>পরিমাণ</th>
                    <th>মূল্য সংযোজন করের পরিমাণ</th>
                    <th>সমন্বয়যোগ্য সম্পূরক শুল্কের পরিমাণ</th>
                </tr>
                <tr>
                    <th>(১)</th>
                    <th>(২)</th>
                    <th>(৩)</th>
                    <th>(৪)</th>
                    <th>(৫)</th>
                    <th>(৬)</th>
                    <th>(৭)</th>
                    <th>(৮)</th>
                    <th>(৯)</th>
                    <th>(১০)</th>
                    <th>(১১)</th>
                </tr>";

            SfInvoicedetailsEntity objInvoiceDetails = new SfInvoicedetailsEntity
            {
                Refid = Id,
                ReportName = "6.7"
            };
            DataTable dtInvoiceDetails = (DataTable)ServerManager.GetTaskManager.Execute(Module.Operations, ERPTask.AG_GetAllSfInvoicedetailsRecord, objInvoiceDetails);
            int iCounter = 1;

            double dlTotalPrice = 0.00;
            double dlTotalVat = 0.00;
            double dlTotalSD = 0.00;
            double dlNetTotalWMushak = 0.00;
            string reasons = "";
            foreach (DataRow dr in dtInvoiceDetails.Rows)
            {
                double unitSd = Convert.ToDouble(dr["CN_SD"]) / Convert.ToDouble(dr["CN_Qty"]);
                double unitVat = Convert.ToDouble(dr["CN_VatAmnt"]) / Convert.ToDouble(dr["CN_Qty"]);

                FormData = FormData + @"<tr>
                    <td> " + iCounter + @"</td>
                    <td>" + dr["InvoiceNo"] + ", " + dr["InvoiceDate"] + @"</td>
                    <td>" + dr["Reason"].ToString() + @"</td>

                    <td>" + dr["NetAmount"].ToString() + @"</td>
                    <td>" + dr["Quantity"].ToString() + @"</td>
                    <td>" + dr["VatAmnt"].ToString() + @"</td>
                    <td>" + dr["SD"].ToString() + @"</td>

                    <td>" + dr["CN_NetAmnt"].ToString() + @"</td>
                    <td>" + dr["CN_Qty"].ToString() + @"</td>
                    <td>" + dr["CN_VatAmnt"].ToString() + @"</td>
                    <td>" + dr["CN_SD"].ToString() + @"</td>
                </tr>";

                iCounter += 1;

                dlTotalPrice += Convert.ToDouble(dr["CN_TotalPrice"]);
                dlTotalSD += Convert.ToDouble(dr["CN_SD"]);
                dlTotalVat += Convert.ToDouble(dr["CN_VatAmnt"]);
                dlNetTotalWMushak += Convert.ToDouble(dr["CN_NetAmnt"]);

                reasons = reasons + dr["Reason"].ToString() + "<br/>";
            }
            FormData = FormData + @"</table>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-3' style='text-align:left;'>

        </div>
        <div class='uk-width-medium-1-6' style='text-align:center;'>

        </div>
        <div class='uk-width-medium-1-3' style='text-align:right;'>
            <p style='text-align:left;'>দায়িত্বপ্রাপ্ত ব্যক্তির নাম<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>পদবি<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>স্বাক্ষর<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>সিল<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 40px;'>
        <div class='uk-width-medium-1-3' style='text-align:left;'>
            <p><sup>১</sup>পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
        </div>
    </div>

</form>";

            ViewBag.FormDataFull = FormData;

            return View("CreditNotes6_7_NewFormat");

        }
        #endregion

        #region DebitNotes
        public ActionResult DebitNotes()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "DebitNotes");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.8 : Debit Notes";
            Session["PageHeader"] = "Mushak 6.8: Debit Notes";
            ViewData["IsReturn"] = GetIsActiveList_();
            InvStockmasterEntity iRet = new InvStockmasterEntity
            {
                ReceivedateSearch = DateTime.Today.ToString("01/MM/yyyy"),
                EndDate = DateTime.Today.ToString("dd/MM/yyyy"),
            };
            return View(iRet);
        }
        [HttpPost]
        public JsonResult GetRcvDataForDebitNote(string StartDate = "", string EndDate = "", string DNStatus = "")
        {
            try
            {
                InvStockmasterEntity iSet = new InvStockmasterEntity();
                iSet.ReceivedateSearch = StartDate;
                iSet.EndDate = EndDate;
                iSet.ReportName = "DebitNoteRpt";
                DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iSet);

                int iCount = 1;
                string TableData = "", Edit = "";
                foreach (DataRow dr in dt.Rows)
                {
                    //Edit = "<i onclick=\"OpenPopupModel('" + dr["ID"] + "');\" title='Send for Debit Note' class='md-icon md-24 material-icons md-color-red-400'>&#XE254;</i>";
                    string dlYear = "", dbNoteNo = "", ChlnNo = "", ChlnDate = "";
                    if (!string.IsNullOrEmpty(dr["EntryDate"].ToString()))
                    {
                        dlYear = dr["EntryDate"].ToString().Substring(8, 2);
                    }
                    if (!string.IsNullOrEmpty(dlYear))
                    {
                        dbNoteNo = dlYear + "-DN-" + Convert.ToDouble(dr["DebitNoteNo"]).ToString("000000");
                    }
                    if (!string.IsNullOrEmpty(dr["RcvRemarks"].ToString()) && dr["RcvRemarks"].ToString() == "Import Purchase")
                    {
                        ChlnNo = dr["BOENo"].ToString();
                        ChlnDate = dr["BOEDate"].ToString();
                    }
                    else
                    {
                        ChlnNo = dr["ChallanNo"].ToString();
                        ChlnDate = dr["ChallanData"].ToString();
                    }

                    Edit = "<i onclick=\"GoToReportView('" + dr["DN_ID"] + "');\" title='Debit Note' class='md-icon md-24 material-icons md-color-green-400'>&#XE85D;</i>";


                    TableData = TableData + "<tr>"
                                          + "<td>" + Edit + "</td>"
                                          + "<td>" + iCount + "</td>"
                                          + "<td>" + dbNoteNo + "</td>"
                                          + "<td>" + dr["EntryDate"] + "</td>"
                                          + "<td>" + ChlnNo + "</td>"
                                          + "<td>" + dr["SupplierName"] + "</td>"
                                          + "<td>" + dr["BranchName"] + "</td>"
                                          + "<td>" + dr["DebitNoteReason"] + "</td>"
                                          + "</tr>";

                    iCount += 1;
                }

                string tHead = "<tr><th style='width:15px;'></th><th style='width:15px;'>SL</th><th>Debit Note No</th><th>Entry Date</th><th>Purchase Challan No</th><th>Supplier Name</th><th>From Store</th><th>Debit Note Reason</th></tr>";

                TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

                return Json(TableData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }
        public ActionResult DebitNotes6_8_Old(string Id = "")
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "DebitNotes");
            Session["PageHeader"] = "Mushak 6.8 :  Debit Notes ";
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.8 : Debit Notes";
            InvStockmasterEntity iSet = new InvStockmasterEntity
            {
                ReportName = "DebitNoteRpt",
                Id = Id
            };
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iSet);

            string dlYear = dt.Rows[0]["EntryDate"].ToString().Substring(8, 2);
            string dbNoteNo = dlYear + "-DN-" + Convert.ToDouble(dt.Rows[0]["DebitNoteNo"]).ToString("000000");

            string FormData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
            <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
            </div>
            <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>ডেবিট নোট</h6>
            <h6>
                [ বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ) দ্রষ্টব্য ]
            </h6>
            </div>
            <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

            </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr style='width: 100%;'>
                    <th style='width: 100%; margin: 0 auto; margin-top:10px; font-size: 15px;'>
                        <b>মূসক-৬.৮</b>
                    </th>
                </tr>
            </table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='EntryCompanyInfo'>
            <p><u>ফেরত গ্রহণকারী ব্যক্তির -</u> </p>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='BuyerInfo'>
            <p>নাম <span style='margin-left: 113px;margin-right: 10px;'>:</span> " + dt.Rows[0]["SupplierName"] + @" </p>
            <p>বিআইএন <span style='margin-left: 84px;margin-right: 10px;'>:</span></p>
            <p>মূল চালান নম্বর <span style='margin-left: 55px;margin-right: 10px;'>:</span> " + dt.Rows[0]["ChallanNo"] + @" </p>
            <p>মূল চালান ইস্যুর তারিখ <span style='margin-left: 18px;margin-right: 10px;'>:</span> " + dt.Rows[0]["ChallanData"] + @" </p>
        </div>
        <div class='ChallanInfo'>
            <p style='margin-top: -11%;margin-bottom: 9%;'>
                <u>ফেরত প্রদানকারী ব্যক্তির -</u>
            </p>
            <p>নাম <span style='margin-left: 82px;margin-right: 10px;'>:</span> Pakiza Technovation Ltd. </p>
            <p>বিআইএন <span style='margin-left: 53px;margin-right: 10px;'>:</span> 00086861616-0306 </p>
            <p>ডেবিট নোট নম্বর <span style='margin-left: 14px;margin-right: 10px;'>:</span> " + dbNoteNo + @" </p>
            <p>ইস্যুর তারিখ <span style='margin-left: 45px;margin-right: 10px;'>:</span> " + dt.Rows[0]["EntryDate"] + @" </p>
            <p>ইস্যুর সময় <span style='margin-left: 51px;margin-right: 10px;'>:</span> 12:44:28 pm </p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:80px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <th>
                        ক্রমিক নম্বর
                    </th>
                    <th>
                        ফেরতপ্রাপ্ত সরবরাহের বিবরণ
                    </th>
                    <th>
                        সরবরাহের একক
                    </th>
                    <th>
                        পরিমাণ
                    </th>
                    <th>
                        একক মূল্য <sup>১</sup>
                        (টাকায়)
                    </th>
                    <th>
                        মোট মূল্য
                        (টাকায়)
                    </th>
                </tr>";

            InvStockdetailsEntity iDet = new InvStockdetailsEntity();
            iDet.DNMasterId = Id;
            iDet.ReportName = "6.8";
            //iDet.GetDataForDN = true;
            DataTable dtDet = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockdetailsRecord, iDet);
            int iCounter = 1;

            double dlTotalPrice = 0.00;
            double dlDeduct = 0.00;
            double dlTotalVat = 0.00;
            double dlTotalSD = 0.00;
            double dlNetTotalWMushak = 0.00;
            string reasons = "";
            foreach (DataRow dr in dtDet.Rows)
            {
                double unitSd = Convert.ToDouble(dr["DN_SD"]) / Convert.ToDouble(dr["DN_Qty"]);
                double unitVat = Convert.ToDouble(dr["DN_VatAmnt"]) / Convert.ToDouble(dr["DN_Qty"]);

                FormData = FormData + @"<tr>
                    <td> " + iCounter + @"</td>
                    <td>" + GetProductHsCodeById(dr["ProductId"].ToString()) + @"</td>
                    <td>" + dr["UnitName"].ToString() + @"</td>
                    <td>" + dr["DN_Qty"].ToString() + @"</td>
                    <td>" + (Convert.ToDouble(dr["DN_UnitPrice"]) + unitSd + unitVat).ToString("0.000") + @"</td>
                    <td>" + dr["DN_NetAmnt"].ToString() + @"</td>
                </tr>";
                iCounter += 1;

                dlTotalPrice += Convert.ToDouble(dr["DN_NetAmnt"]);
                dlTotalSD += Convert.ToDouble(dr["DN_SD"]);
                dlTotalVat += Convert.ToDouble(dr["DN_VatAmnt"]);
                dlNetTotalWMushak += Convert.ToDouble(dr["DN_NetAmnt"]);

                reasons = reasons + dr["Reason"].ToString() + "<br/>";
            }
            FormData = FormData + @"<tr>
                    <td colspan='5' style='text-align:right'>
                        মোট মূল্য
                    </td>
                    <td>" + dlTotalPrice.ToString("0.000") + @"</td>
                </tr>
                <tr>
                    <td colspan='5' style='text-align:right'>
                        বাদ কর্তন <sup>২</sup>
                    </td>
                    <td> 0.000</td>
                </tr>
                <tr>
                    <td colspan='5' style='text-align:right'>
                        মূসকসহ মূল্য
                    </td>
                    <td>" + dlNetTotalWMushak.ToString("0.000") + @"</td>
                </tr>
                <tr>
                    <td colspan='5' style='text-align:right'>
                        মূসকের পরিমাণ
                    </td>
                    <td>" + dlTotalVat.ToString("0.000") + @"</td>
                </tr>
                <tr>
                    <td colspan='5' style='text-align:right'>
                        সম্পূরক শুল্কের পরিমাণ
                    </td>
                    <td>" + dlTotalSD.ToString("0.000") + @"</td>
                </tr>
                <tr>
                    <td colspan='5' style='text-align:right'>
                        মোট কর <sup>৩</sup>
                    </td>
                    <td>" + (dlTotalVat + dlTotalSD).ToString("0.000") + @"</td>
                </tr>
            </table>
            <div class='RerurnCouse'>
                <br />
                <p>ফেরতের কারণ</p>
                <table style='width:100%'>
                    <tr>
                        <td style='font-weight:normal;padding:15px'>" + reasons + @"</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <div class='CompanyInfoFooter'>
                <p style='margin-top:-15%'>
                    দায়িত্বপ্রাপ্ত ব্যক্তির স্বাক্ষর
                </p>
                <p style='margin-top:20%;'><hr class='hrStyle'></p>
                <p>১ প্রতি একক পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
                <p>
                    ২ ফেরত প্রদানের জন্য কোনো ধরণের কর্তন থাকিলে উহার পরিমান।
                </p>
                <p>

                    ৩ মূসক ও সম্পূরক শুল্কের যোগফল।
                </p>

            </div>

        </div>
    </div>

    <div class='footer'>
        <p>Page 1 of 1</p>
    </div>
    <div class='footer2'>
        <p>Print Date: </p>
    </div>
</form>";
            ViewBag.FormDataFull = FormData;

            return View("DebitNotes6_8_NewFormat");

        }

        public ActionResult DebitNotes6_8(string Id = "")
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "DebitNotes");
            Session["PageHeader"] = "Mushak 6.8 :  Debit Notes ";
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.8 : Debit Notes";
            InvStockmasterEntity iSet = new InvStockmasterEntity
            {
                ReportName = "DebitNoteRpt",
                Id = Id
            };
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iSet);

            string dlYear = dt.Rows[0]["EntryDate"].ToString().Substring(8, 2);
            string dbNoteNo = dlYear + "-DN-" + Convert.ToDouble(dt.Rows[0]["DebitNoteNo"]).ToString("000000");

            string FormData = @"<form id='InputForm' action=''>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <p id='corners2'><b>মূসক-৬.৮</b></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-1' style='text-align:center;'>
            <h6><b>ডেবিট নোট</b></h6>
            <h6> [ বিধি ৪০ এর উপ-বিধি (১) এর দফা (ছ) দ্রষ্টব্য ]</h6>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-3' style='text-align:left;'>

        </div>
        <div class='uk-width-medium-1-6' style='text-align:center;'>

        </div>
        <div class='uk-width-medium-1-3' style='text-align:right; border-left: 3px solid black;'>
            <p style='text-align:left;'>ডেবিট নোট নম্বর<span style='margin-left: 14px;margin-right: 10px;'>:</span>" + dbNoteNo + @"</p>
            <p style='text-align:left;'>ইস্যুর তারিখ<span style='margin-left: 14px;margin-right: 10px;'>:</span>" + dt.Rows[0]["EntryDate"] + @"</p>
            <p style='text-align:left;'>ইস্যুর সময়<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-1' style='text-align:left;'>
            <p style='text-align:left;'>নিবন্ধিত ব্যক্তির নাম<span style='margin-left: 14px;margin-right: 10px;'>:</span>Pakiza Technovation Ltd.</p>
            <p style='text-align:left;'>নিবন্ধিত ব্যক্তির বিআইএন<span style='margin-left: 14px;margin-right: 10px;'>:</span>00086861616-0306</p>
            <p style='text-align:left;'>নিবন্ধিত ব্যক্তির ঠিকানা<span style='margin-left: 14px;margin-right: 10px;'>:</span>1094, NOWPARA,RASULPUR,NARSINGDI</p>
            <p style='text-align:left;'>ক্রেতা/গ্রহিতার নাম<span style='margin-left: 14px;margin-right: 10px;'>:</span>" + dt.Rows[0]["SupplierName"] + @"</p>
            <p style='text-align:left;'>ক্রেতা/গ্রহিতার বিআইএন<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>ঠিকানা<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>যানবাহনের প্রকৃতি ও নম্বর<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tableMain'>
                <tr>
                    <th rowspan='2'>ক্রমিক নং</th>
                    <th rowspan='2'>কর চালানপত্রের নম্বর ও তারিখ</th>
                    <th rowspan='2'>ডেবিট নোট ইস্যুর কারণ</th>
                    <th colspan='4'>চালানপত্রে উল্লিখিত সরবরাহের</th>
                    <th colspan='4'>বৃদ্ধিকারী সমন্বয়ের সহিত সংশ্লিষ্ট</th>
                </tr>
                <tr>
                    <th>মূল্য<sup>১</sup></th>
                    <th>পরিমাণ</th>
                    <th>মূল্য সংযোজন করের পরিমাণ</th>
                    <th>সম্পূরক শুল্কের পরিমাণ</th>
                    <th>মূল্য<sup>১</sup></th>
                    <th>পরিমাণ</th>
                    <th>মূল্য সংযোজন করের পরিমাণ</th>
                    <th>সমন্বয়যোগ্য সম্পূরক শুল্কের পরিমাণ</th>
                </tr>
                <tr>
                    <th>(১)</th>
                    <th>(২)</th>
                    <th>(৩)</th>
                    <th>(৪)</th>
                    <th>(৫)</th>
                    <th>(৬)</th>
                    <th>(৭)</th>
                    <th>(৮)</th>
                    <th>(৯)</th>
                    <th>(১০)</th>
                    <th>(১১)</th>
                </tr>";

            InvStockdetailsEntity iDet = new InvStockdetailsEntity();
            iDet.DNMasterId = Id;
            iDet.ReportName = "6.8";
            //iDet.GetDataForDN = true;
            DataTable dtDet = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockdetailsRecord, iDet);
            int iCounter = 1;

            double dlTotalPrice = 0.00;
            double dlDeduct = 0.00;
            double dlTotalVat = 0.00;
            double dlTotalSD = 0.00;
            double dlNetTotalWMushak = 0.00;
            string reasons = "";
            foreach (DataRow dr in dtDet.Rows)
            {
                double unitSd = Convert.ToDouble(dr["DN_SD"]) / Convert.ToDouble(dr["DN_Qty"]);
                double unitVat = Convert.ToDouble(dr["DN_VatAmnt"]) / Convert.ToDouble(dr["DN_Qty"]);

                FormData = FormData + @"<tr>
                    <td> " + iCounter + @"</td>
                    <td>" + dr["ChallanNo"] + ", " + dr["ChallanData"] + @"</td>
                    <td>" + dr["Reason"].ToString() + @"</td>

                    <td>" + dr["NetAmount"].ToString() + @"</td>
                    <td>" + dr["Quantity"].ToString() + @"</td>
                    <td>" + dr["VatAmnt"].ToString() + @"</td>
                    <td>" + dr["SD"].ToString() + @"</td>

                    <td>" + dr["DN_NetAmnt"].ToString() + @"</td>
                    <td>" + dr["DN_Qty"].ToString() + @"</td>
                    <td>" + dr["DN_VatAmnt"].ToString() + @"</td>
                    <td>" + dr["DN_SD"].ToString() + @"</td>
                </tr>";
                iCounter += 1;

                dlTotalPrice += Convert.ToDouble(dr["DN_NetAmnt"]);
                dlTotalSD += Convert.ToDouble(dr["DN_SD"]);
                dlTotalVat += Convert.ToDouble(dr["DN_VatAmnt"]);
                dlNetTotalWMushak += Convert.ToDouble(dr["DN_NetAmnt"]);

                reasons = reasons + dr["Reason"].ToString() + "<br/>";
            }

            FormData += @"</table>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 20px;'>
        <div class='uk-width-medium-1-3' style='text-align:left;'>

        </div>
        <div class='uk-width-medium-1-6' style='text-align:center;'>

        </div>
        <div class='uk-width-medium-1-3' style='text-align:right;'>
            <p style='text-align:left;'>দায়িত্বপ্রাপ্ত ব্যক্তির নাম<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>পদবি<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>স্বাক্ষর<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
            <p style='text-align:left;'>সিল<span style='margin-left: 14px;margin-right: 10px;'>:</span></p>
        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;margin-top : 40px;'>
        <div class='uk-width-medium-1-3' style='text-align:left;'>
            <p><sup>১</sup>পণ্য/সেবার মূসক ও সম্পূরক শুল্কসহ মূল্য।</p>
        </div>
    </div>

</form>";

            ViewBag.FormDataFull = FormData;

            return View("DebitNotes6_8_NewFormat");

        }
        #endregion

        #region PurchaseAndSalesChallan>2Lac
        public ActionResult PurchaseAndSalesChallan2Lac()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "PurchaseAndSalesChallan2Lac");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Purchase And Sales Challan > 2 Lac";
            Session["PageHeader"] = "Mushak 6.10: Purchase And Sales Challan > 2 Lac";
            ViewData["IsReturn"] = GetIsActiveList_();

            ViewData["SupplierList"] = objInv.GetSupplierList();
            ViewData["CustomerList"] = objOp.GetCustomerlist();
            ViewData["TypeList"] = GetTransactionType();

            InvStockmasterEntity iSet = new InvStockmasterEntity
            {
                ReceivedateSearch = DateTime.Now.ToString("01/MM/yyyy"),
                EndDate = DateTime.Now.ToString("dd/MM/yyyy")
            };

            return View(iSet);
        }

        //GetPurchaseRegisterDataList
        public JsonResult GetSalePurchaseRecordData(string StartDate = "", string EndDate = "", string Supplier = "", string Client = "", string Type = "")
        {
            InvStockmasterEntity objGet = new InvStockmasterEntity();
            objGet.ReceivedateSearch = StartDate;
            objGet.EndDate = EndDate;
            objGet.Supplierid = Supplier;
            objGet.ReportName = Type;
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, objGet);

            string TableData = "";
            int iCount = 1;

            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrEmpty(Type) && Type == "Purchase>2Lac")
                {
                    TableData = TableData + "<tr>"
                          + "<td>" + iCount + "</td>"
                          + "<td>" + StartDate + "</td>"
                          + "<td>" + EndDate + "</td>"
                          + "<td>" + dr["ChallanNo"] + "</td>"
                          + "<td>" + dr["ChallanData"] + "</td>"
                          + "<td>" + dr["SupplierName"] + "</td>"
                          + "<td>" + dr["TotalAmount"] + "</td>"
                          //+ "<td>" + GetProductHsCodeById(dr["ProductId"].ToString()) + "</td>"
                          + "</tr>";
                }
                else if (!string.IsNullOrEmpty(Type) && Type == "Sale>2Lac")
                {
                    TableData = TableData + "<tr>"
                          + "<td>" + iCount + "</td>"
                          + "<td>" + StartDate + "</td>"
                          + "<td>" + EndDate + "</td>"
                          + "<td>" + dr["InvoiceNo"] + "</td>"
                          + "<td>" + dr["InvoiceDate"] + "</td>"
                          + "<td>" + dr["CustomerName"] + "</td>"
                          + "<td>" + dr["TotalAmount"] + "</td>"
                          //+ "<td>" + GetProductHsCodeById(dr["ProductId"].ToString()) + "</td>"
                          + "</tr>";
                }

                iCount = iCount + 1;
            }

            string tHead = "";

            tHead = "<tr><th>Sl</th><th>From</th><th>To</th><th>Challan No</th><th>Challan Date</th><th>Supplier/Client Name</th><th>Total Amount</th></tr>";

            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>"
                + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult PurchaseAndSalesChallan2Lac6_10(string StartDate = "", string EndDate = "", string Supplier = "", string Client = "", string Type = "")
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "PurchaseAndSalesChallan2Lac");
            Session["PageHeader"] = "Mushak 6.10 : Purchase And Sales Challan > 2 Lac ";
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Purchase And Sales Challan > 2 Lac";

            string TableData = "";
            int saleRows = 1;
            int PuchaseRows = 1;
            if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate))
            {

                InvStockmasterEntity objGet = new InvStockmasterEntity
                {
                    ReceivedateSearch = StartDate,
                    EndDate = EndDate,
                    Supplierid = Supplier,
                    ReportName = "Purchase>2Lac"
                };
                DataTable dtPurchase = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, objGet);

                InvStockmasterEntity objSales = new InvStockmasterEntity
                {
                    ReceivedateSearch = StartDate,
                    EndDate = EndDate,
                    Supplierid = Supplier,
                    ReportName = "Sale>2Lac"
                };
                DataTable dtSales = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, objSales);

                TableData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>
            <img src='/Images/nbr_logo.png' alt='Sample Photo' style='margin-left: 60px;' />
        </div>
        <div class='uk-width-medium-1-2' style='width: 50%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h5><b>জাতীয় রাজস্ব বোর্ড</b></h5>
            <h6>২ (দুই) লক্ষ টাকার অধিক মূল্যমানের ক্রয়-বিক্রয় চালানপত্রের তথ্য</h6>
            <h6>
                [ বিধি ৪২ এর উপ-বিধি (১) দ্রষ্টব্য ]
            </h6>
        </div>
        <div class='uk-width-medium-1-6' style='width: 20%; margin: 0 auto;'>

        </div>
    </div>

    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table style='width: 10%; float: right; margin-right:80px;'>
                <tr style='width: 100%;'>
                    <th style='width: 100%; margin: 0 auto; margin-top:10px; font-size: 15px;'>
                        <b>মূসক ৬.১০</b>
                    </th>
                </tr>
            </table>
        </div>
    </div>
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='BuyerInfo'>
            <p>নিবন্ধিত /তালিকাভুক্ত ব্যক্তির নাম <span style='margin-left: 10px;margin-right: 10px;'>:</span> Pakiza Technovation Ltd. </p>          
        </div>
        <div class='ChallanInfo'>
            <p>বিআইএন <span style='margin-left: 10px;margin-right: 10px;'>:</span>00086861616-0306</p>
        </div>
    </div>
    
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:30px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
        
            <table id='tableMain'>
                <tr><td colspan='7' style='text-align:left;font-weight:bold'>অংশ-ক : ক্রয় হিসাব তথ্য</td></tr>
                <tr>
                    <td colspan='6'> ক্রয় </td>
                    <td rowspan='2'>
                        বিক্রেতার বিআইএন / জাতীয় পরিচয়পত্র নং
                    </td>
                </tr>
                <tr>
                    <td>
                        ক্রমিক নং
                    </td>
                    <td>
                        চালানপত্র নং
                    </td>
                    <td>
                        ইস্যুর তারিখ
                    </td>
                    <td>
                        মূল্য
                    </td>
                    <td>
                        বিক্রেতার নাম
                    </td>
                    <td>
                        বিক্রেতার ঠিকানা
                    </td>
                </tr>
                <tr>
                    <td>
                        (১)
                    </td>
                    <td>
                        (২)
                    </td>
                    <td>
                        (৩)
                    </td>
                    <td>
                        (৪)
                    </td>
                    <td>
                        (৫)
                    </td>
                    <td>
                        (৬)
                    </td>
                    <td>
                        (৭)
                    </td>
                </tr>";

                foreach (DataRow DrPurchase in dtPurchase.Rows)
                {
                    TableData = TableData + "<tr>"
                                            + "<td>" + PuchaseRows + "</td>"
                                            + "<td>" + DrPurchase["ChallanNo"] + "</td>"
                                            + "<td>" + DrPurchase["ChallanData"] + "</td>"
                                            + "<td>" + DrPurchase["TotalAmount"] + "</td>"
                                            + "<td>" + DrPurchase["SupplierName"] + "</td>"
                                            + "<td>" + DrPurchase["Address"] + "</td>"
                                            + "<td>" + DrPurchase["NID"] + "</td>"
                                            + "</tr>";
                    PuchaseRows += 1;
                }
                TableData = TableData + @" </table>
        </div>
    </div>
    
    <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:70px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr><td colspan='7' style='text-align:left;font-weight:bold'>অংশ-খ : বিক্রয় হিসাব তথ্য</td></tr>
                <tr>
                    <td colspan='6'> বিক্রয় </td>
                    <td rowspan='2'>
                        ক্রেতার বিআইএন / জাতীয় পরিচয়পত্র নং
                    </td>
                </tr>
                <tr>
                    <td>
                        ক্রমিক নং
                    </td>
                    <td>
                        চালানপত্র নং
                    </td>
                    <td>
                        ইস্যুর তারিখ
                    </td>
                    <td>
                        মূল্য
                    </td>
                    <td>
                        ক্রেতার নাম
                    </td>
                    <td>
                        ক্রেতার ঠিকানা
                    </td>
                </tr>
                <tr>
                    <td>
                        (১)
                    </td>
                    <td>
                        (২)
                    </td>
                    <td>
                        (৩)
                    </td>
                    <td>
                        (৪)
                    </td>
                    <td>
                        (৫)
                    </td>
                    <td>
                        (৬)
                    </td>
                    <td>
                        (৭)
                    </td>
                </tr>";

                foreach (DataRow DrSale in dtSales.Rows)
                {
                    TableData = TableData + "<tr>"
                                            + "<td>" + saleRows + "</td>"
                                            + "<td>" + DrSale["InvoiceNo"] + "</td>"
                                            + "<td>" + DrSale["InvoiceDate"] + "</td>"
                                            + "<td>" + DrSale["TotalAmount"] + "</td>"
                                            + "<td>" + DrSale["CustomerName"] + "</td>"
                                            + "<td>" + DrSale["CustomerNewAddress"] + "</td>"
                                            + "<td>" + DrSale["NIDNum"] + "</td>"
                                            + "</tr>";
                    saleRows += 1;
                }

                TableData = TableData + @"</table>

                    </div>
                </div>
        <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <div class='CompanyInfoFooter'>
                <p>
                    দায়িত্বপ্রাপ্ত ব্যক্তির স্বাক্ষর
                </p>
                <p>
                    নাম :
                </p>
                <p>
                   তারিখ :
                </p>
                <p style='margin-top:20px;'>
                   <b>*</b>
                </p>
                <p style='margin-top:10px;'><hr class='hrStyle'></p>
                <p><pow>১</pow> এসআরও নং-১৭১-আইন/২০১৯/২৮-মুসক, তারিখঃ ১৩ জুন, ২০১৯ দ্বারা প্রতিস্থাপিত। </p>

            </div>

        </div>
    </div>
                <div class='footer'>
                    <p>Page 1 of 1</p>
                </div>
                <div class='footer2'>
                    <p>Print Date: " + DateTime.Now.ToString("dd/MM/yyyy") + @"</p>
                </div>
            </form>";
            }
            ViewBag.WholeData = TableData;
            return View();

        }
        #endregion

        #region PurchaseRegister
        public ActionResult PurchaseRegister()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "PurchaseRegister");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.1 : Purchase Register";
            Session["PageHeader"] = "Mushak 6.1: Purchase Register";
            ViewData["IsReturn"] = GetIsActiveList_();
            ManageStockController objInv = new ManageStockController();
            InventoryBaseController objBase = new InventoryBaseController();
            ViewData["SupplierList"] = objInv.GetSupplierList();
            ViewData["ItemsList"] = objInv.GetItemslist("1,3");
            ViewData["LOBList"] = objBase.GetLobListData("1,3");
            InvStockmasterEntity iSet = new InvStockmasterEntity
            {
                ReceivedateSearch = DateTime.Now.ToString("dd/MM/yyyy"),
                EndDate = DateTime.Now.ToString("dd/MM/yyyy")
            };
            return View(iSet);
        }

        //GetPurchaseRegisterDataList
        public JsonResult GetPurchaseRegisterDataList(string StartDate = "", string EndDate = "", string Item = "")
        {
            InvStockmasterEntity objGet = new InvStockmasterEntity();
            objGet.ReceivedateSearch = StartDate;
            objGet.EndDate = EndDate;
            objGet.Productid = Item;
            objGet.ReportName = "VAT";
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, objGet);

            string TableData = "";
            int iCount = 1;

            foreach (DataRow dr in dt.Rows)
            {
                //string[] _items = dr["Items"].ToString().Split('+');
                //foreach (string _allItems in _items)
                //{
                //    items = items + _allItems + "<br>";
                //}
                //string items = "";
                //string[] _itemIds = dr["ProductId"].ToString().Split(',');
                //foreach (string _allItems in _itemIds)
                //{
                //    items = items + GetProductHsCodeById(_allItems) + "<br>";
                //}

                TableData = TableData + "<tr>"

                      //+ "<td><i onclick=\"GoToReportView('" + dr["Id"] + "');\" class='md-24 material-icons md-color-green-500' title='View Report'>&#XE85D;</i></td>"
                      + "<td>" + iCount + "</td>"
                      + "<td>" + dr["RcvNo"] + "</td>"
                      + "<td>" + dr["RcvDate"] + "</td>"
                      + "<td>" + dr["SupplierName"] + "</td>"
                      + "<td>" + GetProductHsCodeById(dr["ProductId"].ToString()) + "</td>"
                      + "<td>" + dr["ChallanNo"] + "</td>"
                      + "<td>" + dr["ChallanData"] + "</td>"
                      + "</tr>";

                iCount = iCount + 1;
            }

            string tHead = "";

            tHead = "<tr><th>Sl</th><th>Rcv NO</th><th>Rcv Date</th><th>Supplier Name</th><th>Item Name</th><th>Challan No</th><th>Challan Date</th></tr>";


            TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>"
                + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);

        }
        public string GetProductHsCodeById(string Id)
        {
            InvStockmasterEntity iSet = new InvStockmasterEntity
            {
                Productid = Id,
                ReportName = "HSCode"
            };
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iSet);
            string ReturnStr = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["Name"].ToString()) && !string.IsNullOrEmpty(dt.Rows[0]["CodeNum"].ToString()))
                    ReturnStr = dt.Rows[0]["Name"].ToString() + " HS:" + dt.Rows[0]["CodeNum"].ToString();
                else
                    ReturnStr = dt.Rows[0]["Name"].ToString();
            }

            return ReturnStr;
        }
        public string GetProductNameById(string Id)
        {
            InvStockmasterEntity iSet = new InvStockmasterEntity
            {
                Productid = Id,
                ReportName = "HSCode"
            };
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iSet);
            string ReturnStr = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                ReturnStr = dt.Rows[0]["Name"].ToString();
            }

            return ReturnStr;
        }

        public ActionResult PurchaseRegister6_1(string StartDate = "", string EndDate = "", string Item = "")
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "PurchaseRegister");
            Session["PageHeader"] = "Mushak 6.1 : Purchase Register";
            string TableData = "";

            //DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockdetailsRecord, iDet);

            TableData = @"<form id='InputForm' action='' style='margin: 0 auto;'>
            <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>        
            <div class='uk-width-medium-1-2' style='width: 100%; margin: 0 auto; text-align: center;'>
            <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
            <h6>জাতীয় রাজস্ব বোর্ড</h6>
            <h6>
                <b>Pakiza Technovation Limited, House # 52/A, Road # 09-A, Dhanmondi, Dhaka-1205, Bangladesh, 00086861616-0306</b>
                <span style='border:1px solid;padding:5px;float:right;'><sup>১</sup><b>[ মূসক-৬.১</b></span>
            </h6>
            <h6><b>ক্রয় হিসাব পুস্তক</b></h6>
            <h6>(পণ্য বা সেবা প্রক্রিয়াকরণে সম্পৃক্ত এমন নিবন্ধিত বা তালিকাভুক্ত ব্যক্তির জন্য প্রযোজ্য)</h6>
            <h6>[বিধি ৪০(১) এর দফা (ক) এবং ৪১ এর দফা (ক) দ্রষ্টব্য]</h6>
        </div>       
        </div> 
        <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:30px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>    
        <p style='font-size:14px;font-weight:bold;'>" + GetProductHsCodeById(Item) + @"</p>
        </div>
        </div>
        <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:10px;'>
        <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr>
                    <td colspan='21'>পণ্য/সেবার উপকরণ ক্রয় </td>
                </tr>
                <tr>
                    <td rowspan='3'> ক্রমিক সংখ্যা </td>
                    <td rowspan='3'> তারিখ </td>
                    <td colspan='2'> মজুদ উপকরণের প্রারম্ভিক জের </td>
                    <td colspan='14'> ক্রয়কৃত উপকরণ </td>
                    <td colspan='2'> উপকরণের প্রান্তিক জের </td>
                    <td rowspan='3'> মন্তব্য </td>
                </tr>
                <tr>
                    <td rowspan='2'> পরিমাণ (একক) </td>
                    <td rowspan='2'> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                    <td rowspan='2'> চালানপত্র/ বিল অব এন্ট্রি নম্বর </td>
                    <td rowspan='2'> তারিখ </td>
                    <td colspan='3'> বিক্রেতা/ সরবরাহকারী </td>
                    <td rowspan='2'> বিবরণ </td>
                    <td rowspan='2'> পরিমাণ </td>
                    <td rowspan='2'> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                    <td rowspan='2'> সম্পূরক শুল্ক (যদি থাকে) </td>
                    <td rowspan='2'> মূসক </td>
                    <td colspan='2'> মোট উপকরণের পরিমাণ </td>
                    <td colspan='2'> পণ্য প্রস্তুত/প্রক্রিয়া করণে উপকরণের ব্যবহার </td>
                    <td rowspan='2'> পরিমাণ (একক) </td>
                    <td rowspan='2'> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                </tr>
                <tr>
                    <td>নাম</td>
                    <td>ঠিকানা</td>
                    <td> নিবন্ধন/তালিকাভুক্তি/জাতীয়পরিচয় পত্র নং </td>
                    <td> পরিমাণ (একক) </td>
                    <td> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                    <td> পরিমাণ (একক) </td>
                    <td> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                </tr>
                <tr>
                    <td>(১)</td>
                    <td>(২)</td>
                    <td>(৩)</td>
                    <td>(৪)</td>
                    <td>(৫)</td>
                    <td>(৬)</td>
                    <td>(৭)</td>
                    <td>(৮)</td>
                    <td>(৯)</td>
                    <td>(১০)</td>
                    <td>(১১)</td>
                    <td>(১২)</td>
                    <td>(১৩)</td>
                    <td>(১৪)</td>
                    <td>(১৫)=(৩ + ১১)</td>
                    <td>(১৬)=(৪ + ১২)</td>
                    <td>(১৭)</td>
                    <td>(১৮)</td>
                    <td>(১৯)=(১৫ - ১৭)</td>
                    <td>(২০)=(১৬ - ১৮)</td>
                    <td>(২১)</td>
                </tr>";

            double dlTotalQty = 0.00;
            double dlTotalPrice = 0.00;
            double dlTotalSD = 0.00;
            double dlTotalMushak = 0.00;
            double dlTotalProdQty = 0.00;
            double dlTotalProdAmnt = 0.00;

            if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate) && !string.IsNullOrEmpty(Item))
            {
                int iCount = 0;
                InvProductEntity iPrd = (InvProductEntity)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetSingleInvProductRecordById, Item);
                string Unit = iPrd.UnitName;

                string dateStringStrt = StartDate;
                string dateStringEnd = EndDate;
                string format = "dd/MM/yyyy";

                DateTime fromDate = DateTime.ParseExact(dateStringStrt, format, CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(dateStringEnd, format, CultureInfo.InvariantCulture);

                InvStockmasterEntity iDet = new InvStockmasterEntity();
                iDet.ReceivedateSearch = fromDate.AddDays(-1).ToString("dd/MM/yyyy");
                iDet.EndDate = fromDate.AddDays(-1).ToString("dd/MM/yyyy");
                iDet.Productid = Item;
                iDet.ReportName = "CurrentStock";

                DataTable dtOpening = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iDet);
                string openingQty = "", openingAmt = "";

                if (dtOpening.Rows.Count > 0)
                {
                    openingQty = dtOpening.Rows[0]["Current_Stock_Quantity"].ToString();
                    openingAmt = dtOpening.Rows[0]["Current_Stock_Total_Price"].ToString();
                }
                else
                {
                    openingQty = "0.00";
                    openingAmt = "0.00";
                }

                double buyQty = 0.00;
                double buyAmnt = 0.00;
                double sdAmnt = 0.0;
                double MushakAmnt = 0.00;
                double totCalQty = Convert.ToDouble(openingQty) + buyQty;
                double totCalAmnt = Convert.ToDouble(openingAmt) + buyAmnt;
                double prodQty = 0.0;
                double prodAmnt = 0.0;

                double closingQty = totCalQty - prodQty;
                double closingAmnt = totCalAmnt - prodAmnt;

                string chlBOENo = "";
                string chlBOEDate = "";
                string sdAmntCurrent = "0.00";

                while (fromDate <= toDate)
                {

                    /*-----------------------------------Stock Recieve Data(Import/Local)-----------------------------------------*/
                    InvStockmasterEntity iBuying = new InvStockmasterEntity();
                    iBuying.ReceivedateSearch = fromDate.ToString("dd/MM/yyyy");
                    iBuying.EndDate = fromDate.ToString("dd/MM/yyyy");
                    iBuying.Productid = Item;
                    iBuying.ReportName = "VAT";

                    DataTable dtBuyingDat = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iBuying);

                    if (dtBuyingDat.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtBuyingDat.Rows)
                        {
                            iCount += 1;
                            openingQty = closingQty.ToString();
                            openingAmt = closingAmnt.ToString();

                            chlBOENo = dr["RcvRemarks"].ToString() == "Import Purchase" ? dr["BOENo"].ToString() : dr["ChallanNo"].ToString();
                            chlBOEDate = dr["RcvRemarks"].ToString() == "Import Purchase" ? dr["BOEDate"].ToString() : dr["ChallanData"].ToString();

                            buyQty = Convert.ToDouble(dr["Quantity"]);
                            buyAmnt = Convert.ToDouble(dr["DTotalP"]);
                            //buyAmnt = dr["RcvRemarks"].ToString() == "Import Purchase" ? Convert.ToDouble(dr["DTotalP"]) : (Convert.ToDouble(dr["DTotalP"])- Convert.ToDouble(dr["SD"]));
                            sdAmnt = Convert.ToDouble(dr["SD"]);
                            totCalQty = Convert.ToDouble(openingQty) + buyQty;
                            totCalAmnt = Convert.ToDouble(openingAmt) + buyAmnt;
                            MushakAmnt = Convert.ToDouble(dr["VatAmnt"]);//CalculateMushakAmount(Convert.ToDouble(dr["ActualVatPer"]), Convert.ToDouble(dr["UnitPrice"]));
                            prodQty = 0.0;
                            prodAmnt = 0.0;
                            closingQty = totCalQty - prodQty;
                            closingAmnt = totCalAmnt - prodAmnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>
                            <td>" + Convert.ToDouble(openingQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(openingAmt).ToString("0.00") + @"</td>
                            <td>" + chlBOENo + @"</td>
                            <td>" + chlBOEDate + @"</td>
                            <td>" + dr["SupplierName"] + @"</td>
                            <td>" + dr["SupplierAddress"] + @"</td>
                            <td>" + dr["NID"] + @"</td>
                            <td>" + GetProductNameById(dr["ProductId"].ToString()) + @"</td>
                            <td>" + (buyQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + (buyAmnt).ToString("0.00") + @"</td>
                            <td>" + sdAmnt + @"</td>
                            <td>" + MushakAmnt.ToString("0.00") + @"</td>
                            <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + totCalAmnt.ToString("0.00") + @"</td>
                            <td>" + prodQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + prodAmnt.ToString("0.00") + @"</td>
                            <td>" + closingQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + closingAmnt.ToString("0.00") + @"</td>
                            <td>" + dr["RcvRemarks"] + @"</td>
                        </tr>";

                            dlTotalQty += buyQty;
                            dlTotalPrice += buyAmnt;
                            dlTotalSD += sdAmnt;
                            dlTotalMushak += MushakAmnt;
                            dlTotalProdQty += prodQty;
                            dlTotalProdAmnt += prodAmnt;

                        }
                    }

                    /*-----------------------------------Production Data(In-House)-----------------------------------------*/
                    InvProductionmasterEntity iProduction = new InvProductionmasterEntity();
                    iProduction.StartDate = fromDate.ToString("dd/MM/yyyy");
                    iProduction.EndDate = fromDate.ToString("dd/MM/yyyy");
                    iProduction.ProductId = Item;
                    iProduction.ReportName = "Current_Raw_Production";
                    DataTable dtProductionDat = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvProductionmasterRecord, iProduction);
                    if (dtProductionDat.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtProductionDat.Rows)
                        {
                            iCount += 1;
                            openingQty = closingQty.ToString();
                            openingAmt = closingAmnt.ToString();

                            chlBOENo = "";
                            chlBOEDate = "";

                            buyQty = 0.00;
                            buyAmnt = 0.00;
                            totCalQty = Convert.ToDouble(openingQty) + buyQty;
                            totCalAmnt = Convert.ToDouble(openingAmt) + buyAmnt;

                            prodQty = Convert.ToDouble(dr["Current_Production_Quantity"]);
                            prodAmnt = Convert.ToDouble(dr["Current_Production_Total_Price"]);

                            closingQty = totCalQty - prodQty;
                            closingAmnt = totCalAmnt - prodAmnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>
                            <td>" + Convert.ToDouble(openingQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(openingAmt).ToString("0.00") + @"</td>
                            <td>" + chlBOENo + @"</td>
                            <td>" + chlBOEDate + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + GetProductNameById(dr["ProductId"].ToString()) + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + totCalAmnt.ToString("0.00") + @"</td>
                            <td>" + prodQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + prodAmnt.ToString("0.00") + @"</td>
                            <td>" + closingQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + closingAmnt.ToString("0.00") + @"</td>
                            <td> Production </td>
                        </tr>";

                            dlTotalQty += buyQty;
                            dlTotalPrice += buyAmnt;
                            dlTotalSD += sdAmnt;
                            dlTotalMushak += MushakAmnt;
                            dlTotalProdQty += prodQty;
                            dlTotalProdAmnt += prodAmnt;
                        }
                    }

                    /*-----------------------------------Sub-Contact Manufacturing-----------------------------------------*/
                    InvSubcontactmasterEntity iSubCon = new InvSubcontactmasterEntity();
                    iSubCon.Issuedate = fromDate.ToString("dd/MM/yyyy");
                    iSubCon.EndDate = fromDate.ToString("dd/MM/yyyy");
                    iSubCon.SrcProductId = Item;
                    iSubCon.ReportName = "SubConStockForMushak";
                    DataTable dtSubConDat = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvSubcontactmasterRecord, iSubCon);
                    if (dtSubConDat.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSubConDat.Rows)
                        {
                            iCount += 1;
                            openingQty = closingQty.ToString();
                            openingAmt = closingAmnt.ToString();

                            chlBOENo = dr["IssueChallanNo"].ToString();
                            chlBOEDate = dr["IssueDate"].ToString();

                            buyQty = 0.00;//Convert.ToDouble(dr["SubCon_Qty"]);
                            buyAmnt = 0.00;//Convert.ToDouble(dr["SubCon_Total_Price"]);
                            //buyAmnt = dr["RcvRemarks"].ToString() == "Import Purchase" ? Convert.ToDouble(dr["DTotalP"]) : (Convert.ToDouble(dr["DTotalP"])- Convert.ToDouble(dr["SD"]));
                            sdAmnt = 0.00;
                            totCalQty = Convert.ToDouble(openingQty) + buyQty;
                            totCalAmnt = Convert.ToDouble(openingAmt) + buyAmnt;
                            MushakAmnt = 0.00;
                            prodQty = Convert.ToDouble(dr["SubCon_Qty"]);
                            prodAmnt = Convert.ToDouble(dr["SubCon_Total_Price"]);
                            closingQty = totCalQty - prodQty;
                            closingAmnt = totCalAmnt - prodAmnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>
                            <td>" + Convert.ToDouble(openingQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(openingAmt).ToString("0.00") + @"</td>
                            <td>" + chlBOENo + @"</td>
                            <td>" + chlBOEDate + @"</td>
                            <td>" + dr["SupplierName"] + @"</td>
                            <td>" + dr["IssueAddress"] + @"</td>
                            <td>" + dr["NID"] + @"</td>
                            <td>" + GetProductNameById(dr["RawMatId"].ToString()) + @"</td>
                            <td>" + (buyQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + (buyAmnt).ToString("0.00") + @"</td>
                            <td>" + sdAmnt + @"</td>
                            <td>" + MushakAmnt.ToString("0.00") + @"</td>
                            <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + totCalAmnt.ToString("0.00") + @"</td>
                            <td>" + prodQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + prodAmnt.ToString("0.00") + @"</td>
                            <td>" + closingQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + closingAmnt.ToString("0.00") + @"</td>
                            <td> Issue To Contract Manufacture </td>
                        </tr>";

                            dlTotalQty += buyQty;
                            dlTotalPrice += buyAmnt;
                            dlTotalSD += sdAmnt;
                            dlTotalMushak += MushakAmnt;
                            dlTotalProdQty += prodQty;
                            dlTotalProdAmnt += prodAmnt;

                        }
                    }

                    /*-----------------------------------Material Return From Sub Contract-----------------------------------------*/
                    InvSubcontractmaterialreturnEntity objMaterialRet = new InvSubcontractmaterialreturnEntity();
                    objMaterialRet.Returndate = fromDate.ToString("dd/MM/yyyy");
                    objMaterialRet.EndDate = fromDate.ToString("dd/MM/yyyy");
                    objMaterialRet.Rawmatid = Item;
                    objMaterialRet.ReportName = "RawMatReturn";
                    DataTable dtRawMatRet = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvSubcontractmaterialreturnRecord, objMaterialRet);
                    if (dtRawMatRet.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtRawMatRet.Rows)
                        {
                            iCount += 1;
                            openingQty = closingQty.ToString();
                            openingAmt = closingAmnt.ToString();

                            chlBOENo = dr["ReturnChallanNo"].ToString();
                            chlBOEDate = dr["ReturnDate"].ToString();

                            buyQty = Convert.ToDouble(dr["Ret_Qty"]);
                            buyAmnt = Convert.ToDouble(dr["Ret_Total_Price"]);
                            sdAmnt = 0.00;
                            totCalQty = Convert.ToDouble(openingQty) + buyQty;
                            totCalAmnt = Convert.ToDouble(openingAmt) + buyAmnt;
                            MushakAmnt = 0.00;
                            prodQty = 0.00;//Convert.ToDouble(dr["Ret_Qty"]);
                            prodAmnt = 0.00;//Convert.ToDouble(dr["Ret_Total_Price"]);
                            closingQty = totCalQty + prodQty;
                            closingAmnt = totCalAmnt + prodAmnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>
                            <td>" + Convert.ToDouble(openingQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(openingAmt).ToString("0.00") + @"</td>
                            <td>" + chlBOENo + @"</td>
                            <td>" + chlBOEDate + @"</td>
                            <td>" + dr["SupplierName"] + @"</td>
                            <td>" + dr["ReturnAddress"] + @"</td>
                            <td>" + dr["NID"] + @"</td>
                            <td>" + GetProductNameById(dr["RawMatId"].ToString()) + @"</td>
                            <td>" + (buyQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + (buyAmnt).ToString("0.00") + @"</td>
                            <td>" + sdAmnt + @"</td>
                            <td>" + MushakAmnt.ToString("0.00") + @"</td>
                            <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + totCalAmnt.ToString("0.00") + @"</td>
                            <td>" + prodQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + prodAmnt.ToString("0.00") + @"</td>
                            <td>" + closingQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + closingAmnt.ToString("0.00") + @"</td>
                            <td> Material Return from Contract Manufacturer </td>
                        </tr>";

                            dlTotalQty += buyQty;
                            dlTotalPrice += buyAmnt;
                            dlTotalSD += sdAmnt;
                            dlTotalMushak += MushakAmnt;
                            dlTotalProdQty += prodQty;
                            dlTotalProdAmnt += prodAmnt;
                        }
                    }

                    /*-----------------------------------Debit Note-----------------------------------------*/
                    InvStockmasterEntity objDebitNote = new InvStockmasterEntity();
                    objDebitNote.ReceivedateSearch = fromDate.ToString("dd/MM/yyyy");
                    objDebitNote.EndDate = fromDate.ToString("dd/MM/yyyy");
                    objDebitNote.Productid = Item;
                    objDebitNote.ReportName = "Debit_Note_Purchase_Register";
                    DataTable dtDebitNote = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, objDebitNote);
                    string dlYear = "", dbNoteNo = "";
                    if (dtDebitNote.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtDebitNote.Rows)
                        {
                            iCount += 1;

                            dlYear = dr["EntryDate"].ToString().Substring(8, 2);
                            dbNoteNo = dlYear + "-DN-" + Convert.ToDouble(dr["DebitNoteNo"]).ToString("000000");

                            openingQty = closingQty.ToString();
                            openingAmt = closingAmnt.ToString();

                            chlBOENo = dbNoteNo;
                            chlBOEDate = dr["EntryDate"].ToString();

                            buyQty = 0.00; // Convert.ToDouble(dr["Qty"]);
                            buyAmnt = 0.00; // Convert.ToDouble(dr["TotalPrice"]);
                            sdAmnt = Convert.ToDouble(dr["SD"]);
                            totCalQty = Convert.ToDouble(openingQty) - buyQty;
                            totCalAmnt = Convert.ToDouble(openingAmt) - buyAmnt;
                            MushakAmnt = Convert.ToDouble(dr["VatAmnt"]);
                            prodQty = Convert.ToDouble(dr["Qty"]);
                            prodAmnt = (Convert.ToDouble(dr["TotalPrice"]) - Convert.ToDouble(dr["SD"]));
                            closingQty = totCalQty - prodQty;
                            closingAmnt = totCalAmnt - prodAmnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>
                            <td>" + Convert.ToDouble(openingQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(openingAmt).ToString("0.00") + @"</td>
                            <td>" + chlBOENo + @"</td>
                            <td>" + chlBOEDate + @"</td>
                            <td>" + dr["SupplierName"] + @"</td>
                            <td>" + dr["Address"] + @"</td>
                            <td>" + dr["NID"] + @"</td>
                            <td>" + GetProductNameById(dr["ItemId"].ToString()) + @"</td>
                            <td>" + (buyQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + (buyAmnt).ToString("0.00") + @"</td>
                            <td>" + sdAmnt + @"</td>
                            <td>" + MushakAmnt.ToString("0.00") + @"</td>
                            <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + totCalAmnt.ToString("0.00") + @"</td>
                            <td>" + prodQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + prodAmnt.ToString("0.00") + @"</td>
                            <td>" + closingQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + closingAmnt.ToString("0.00") + @"</td>
                            <td> Debit Note : " + dr["Reason"] + @" </td>
                        </tr>";

                            dlTotalQty += buyQty;
                            dlTotalPrice += buyAmnt;
                            dlTotalSD += sdAmnt;
                            dlTotalMushak += MushakAmnt;
                            dlTotalProdQty += prodQty;
                            dlTotalProdAmnt += prodAmnt;
                        }
                    }

                    if (dtProductionDat.Rows.Count <= 0 && dtBuyingDat.Rows.Count <= 0 && dtSubConDat.Rows.Count <= 0 && dtRawMatRet.Rows.Count <= 0 && dtDebitNote.Rows.Count <= 0)
                    {
                        iCount += 1;
                        //Printing the useless blank cells as per Requirement
                        openingQty = closingQty.ToString();
                        openingAmt = closingAmnt.ToString();

                        chlBOENo = "";
                        chlBOEDate = "";

                        buyQty = Convert.ToDouble(0.00);
                        buyAmnt = Convert.ToDouble(0.00);
                        totCalQty = Convert.ToDouble(openingQty) + buyQty;
                        totCalAmnt = Convert.ToDouble(openingAmt) + buyAmnt;
                        prodQty = 0.0;
                        prodAmnt = 0.0;
                        closingQty = totCalQty - prodQty;
                        closingAmnt = totCalAmnt - prodAmnt;

                        TableData = TableData + @"<tr>
                                <td>" + iCount + @"</td>
                                <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>
                                <td>" + Convert.ToDouble(openingQty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + Convert.ToDouble(openingAmt).ToString("0.00") + @"</td>
                                <td>" + chlBOENo + @"</td>
                                <td>" + chlBOEDate + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + totCalAmnt.ToString("0.00") + @"</td>
                                <td>" + prodQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + prodAmnt.ToString("0.00") + @"</td>
                                <td>" + closingQty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + closingAmnt.ToString("0.00") + @"</td>
                                <td>" + "" + @"</td>
                            </tr>";
                    }
                    //iCount += 1;
                    fromDate = fromDate.AddDays(1);

                }
            }
            // ক্রয়কৃত উপকরণ
            TableData = TableData + "<tr><td colspan='10' style='text-align:right;'>মোট</td><td>" + dlTotalQty.ToString("0.00") + "</td><td>" + dlTotalPrice.ToString("0.00") + "</td><td>" + dlTotalSD.ToString("0.00") + "</td><td>" + dlTotalMushak.ToString("0.00") + "</td><td></td><td></td><td>" + dlTotalProdQty.ToString("0.00") + "</td><td>" + dlTotalProdAmnt.ToString("0.00") + "</td><td colspan='3'></td></tr>";
            TableData = TableData + @"</table>
                </div>
            </div>  
            <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:50px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                    <p> বিশেষ দ্রষ্টব্য : </p>
                    <p> ১| অর্থনৈতিক কার্যক্রম সংশ্লিষ্ট সকল প্রকার ক্রয়ের তথ্য এই ফরমে অন্তর্ভুক্ত করিতে হইবে। </p>
                    <p> ২| যে ক্ষেত্রে অনিবন্ধিত ব্যক্তির নিকট হইতে ক্রয় করা হইবে সেই ক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম, ঠিকানা ও জাতীয় পরিচয়পত্র  নম্বর যথাযথভাবে সংশ্লিষ্ট কলাম [(৭), (৮) ও (৯)] এ আবশ্যিকভাবে উল্লেখ করিতে হইবে। </p>
                    <p> ৩| উপকরণ ক্রয়ের সপক্ষে প্রামাণিক দলিল হিসাবে বিল অব এন্ট্রি বা চালানপত্রের কপি সংরক্ষণ করিতে হইবে। </p>
                </div>
            </div>";

            TableData = TableData + @" 
            
            <div class='footerLine'>
                <div class='uk-width-1-3'><hr style='border: 1px solid black;'></div>
                <table style='width: 100%' id='totalField'>
                    <tr>
                        <td>
                            <sup>১ </sup><b>এসআরও নং- ২২৬-আইন/২০১৯/৬২-মূসক, তারিখঃ ৩০ জুন, ২০১৯ দ্বারা প্রতিস্থাপিত । </b>
                        </td>
                        <td>
                            Page 1 of 1
                        </td>
                        <td>
                            Print Date:" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"
                        </td>
                    </tr>
                </table>
            </div>

            </form>";

            /*
            <div class='footerRule'>
                <div class='uk-width-1-1'>
                <span><sup>১ </sup><b>এসআরও নং- ২২৬-আইন/২০১৯/৬২-মূসক, তারিখঃ ৩০ জুন, ২০১৯ দ্বারা প্রতিস্থাপিত । </b></span>
                </div>
            </div>
            <div class='footer'>
                <p>Page 1 of 1</p>
            </div>
            <div class='footer2'>
                <p>Print Date:" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"</p>
            </div>
            */

            ViewBag.FullData = TableData;
            return View();

        }
        #endregion

        #region TurnOverTaxReturnSubmission
        public ActionResult TurnOverTaxReturnSubmission()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "TurnOverTaxReturnSubmission");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.1 : Turn Over Tax Return Submission";
            Session["PageHeader"] = "Mushak 9.2: Turn Over Tax Return Submission";
            ViewData["IsReturn"] = GetIsActiveList_();
            return View();
        }
        public ActionResult TurnOverTaxReturnSubmission9_2()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "TurnOverTaxReturnSubmission");
            Session["PageHeader"] = "Mushak 9.2 : Turn Over Tax Return Submission";
            return View();

        }
        #endregion

        #region Mushak 9.1 : VAT Return Submission
        //VatReturnSubmission
        public ActionResult VatReturnSubmission()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "VatReturnSubmission");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 9.1 : VAT Return Submission";
            Session["PageHeader"] = "Mushak 9.1 : VAT Return Submission";
            ViewData["YesNo"] = GetIsActiveList_();
            ViewData["ReturnType"] = GetReturnTypeList();
            VatReturnsubmissionEntity iObj = new VatReturnsubmissionEntity
            {
                Returnmonth = DateTime.Now.ToString("dd/MM/yyyy")
            };
            return View(iObj);
        }
        public JsonResult GetSingleReturnSubmissionData(string Id)
        {
            VatReturnsubmissionEntity iGet = (VatReturnsubmissionEntity)ExecuteDB(ERPTask.AG_GetSingleVatReturnsubmissionRecordById, Id);
            return Json(iGet);
        }
        //GetVATReturnNoteList
        [HttpPost]
        public JsonResult GetVATReturnNoteList()
        {
            try
            {
                VatReturnsubmissionEntity iSet = new VatReturnsubmissionEntity();
                DataTable dt = (DataTable)ExecuteDB(ERPTask.AG_GetAllVatReturnsubmissionRecord, null);

                int iCount = 1;
                string TableData = "", Edit = "";
                foreach (DataRow dr in dt.Rows)
                {
                    Edit = "<i onclick=\"OpenPopupModel('" + dr["ID"] + "');\" title='Edit This' class='md-icon md-24 material-icons md-color-orange-400'>&#xE254;</i>" +
                        "<i onclick=\"GoToReportView('" + dr["ID"] + "');\" title='Print' class='md-icon md-24 material-icons md-color-green-400'>&#XE85D;</i>";


                    TableData = TableData + "<tr>"
                                          + "<td>" + Edit + "</td>"
                                          + "<td>" + iCount + "</td>"
                                          + "<td>" + dr["ReturnIdNo"] + "</td>"
                                          + "<td>" + dr["ReturnMonth"] + "</td>"
                                          + "<td>" + dr["TransactionOnLastPeriod"] + "</td>"
                                          + "<td>" + dr["WillingToTakeRefund"] + "</td>"
                                          + "<td>" + dr["RetType"] + "</td>"
                                          + "</tr>";

                    iCount += 1;
                }
                string tHead = "<tr><th style='width:15px;'></th><th style='width:15px;'>SL</th><th>Return Id</th><th>Return Month</th><th>Any Transaction on Last Period</th><th>Willing to take refund money?</th><th>Return Type</th></tr>";
                TableData = "<div class='rk_dtButton2'></div><table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" + "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead><tfoot style='display:none;'>" + tHead + "</tfoot><tbody>" + TableData + "</tbody></table>";

                return Json(TableData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        public JsonResult AddUpdateVatReturnSubmission(VatReturnsubmissionEntity iSet)
        {
            try
            {
                bool issave = false;
                if (iSet.Id != null && iSet.Id == "0")
                {
                    issave = (bool)ExecuteDB(ERPTask.AG_SaveVatReturnsubmissionInfo, iSet);
                }
                else
                {
                    issave = (bool)ExecuteDB(ERPTask.AG_UpdateVatReturnsubmissionInfo, iSet);
                }
                if (issave)
                {
                    return Json(new { Success = true, Msg = "Done" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Success = false, Msg = "Failed" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        //RptVatReturnSubmission_9_1
        public ActionResult RptVatReturnSubmission_9_1(string Id)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "../Home");
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "VatReturnSubmission");
            Session["PageHeader"] = "Mushak 9.1 : VAT Return Submission";

            VatReturnsubmissionEntity iMain = (VatReturnsubmissionEntity)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetSingleVatReturnsubmissionRecordById, Id);

            DateTime geDate = DateTime.ParseExact(iMain.Returnmonth, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            string TaxPeriod = geDate.ToString("MMMM") + "/" + geDate.ToString("yyyy");
            string TypeOfReturn = "";
            string Sec64 = "", Sec66 = "", Sec67 = "", Yes = "", No = "";
            string chkIcon = "<i class='material-icons md-24' style='float: right;font-weight: 900;margin-right: 11px;'>check</i>";
            switch (iMain.Returntype)
            {
                case "1":
                    Sec64 = chkIcon;
                    break;
                case "2":
                    Sec66 = chkIcon;
                    break;
                case "3":
                    Sec67 = chkIcon;
                    break;
            }
            switch (iMain.Transactiononlastperiod)
            {
                case "1":
                    Yes = chkIcon;
                    break;
                default:
                    No = chkIcon;
                    break;
            }
            string TaxPActivity = "";


            string tblPartTwo = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
            <div class='uk-width-medium-1-1' style='width: 100%;'>
            <table id='tableMain'>
                <tr style='text-align:center;'>
                    <td colspan='3' style='text-align:center;background-color:#E2BFF1;'><b> অংশ-২: দাখিলপত্র জমার তথ্য </b></td>
                </tr>
                <tr>
                    <td style='width:400px;'> (১) কর মেয়াদ </td>
                    <td style='width:40px; text-align:center;'> : </td>
                    <td style='width:700px;'> " + TaxPeriod + @" </td>
                </tr>
                <tr>
                    <td> (২) দাখিল পত্রের প্রকার </td>
                    <td style='width:40px; text-align:center;'> : </td>
                    <td>
                        <table id='part2' style='width:500px; border:none;'>
                            <tr><td>(ক) মূল দাখিলপত্র (ধারা ৬৪) </td><td><div class='rectangle'>" + Sec64 + @"</div></td></tr>
                            <tr><td>(খ) সংশোধিত দাখিলপত্র (ধারা ৬৬) </td><td><div class='rectangle'>" + Sec66 + @"</div></td></tr>
                            <tr><td>(খ) (গ) পূর্ণ, অতিরিক্ত বা বিকল্প দাখিলপত্র (ধারা ৬৭) </td><td><div class='rectangle'>" + Sec67 + @"</div></td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td> (৩) বিগত করমেয়াদে কোনো কার্যক্রম সম্পাদিত হইয়াছে কি? </td>
                    <td style='width:40px; text-align:center;'> : </td>
                    <td>
                        <table id='part3' style='width:400px; border:none;'>
                            <tr>
                                <td style='width:10px;'><div class='rectangle'>" + Yes + @"</div></td>
                                <td> হ্যাঁ </td>
                                <td style='width:10px;'><div class='rectangle'>" + No + @"</div></td>
                                <td> না </td>
                            </tr>
                            <tr><td colspan='4'> [যদি 'না' হয় তাহা হইলে অংশ-১, ২ এবং ৮ পূরণ করুন] </td></tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td> (৪) পেশের তারিখ </td>
                    <td style='width:40px; text-align:center;'> : </td>
                    <td>" + iMain.Returnmonth + @"</td>
                </tr>
            </table>
        </div>
    </div>";
            //int NotesForPart3 = 8;
            VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
            iSetMain.Returnmonth = iMain.Returnmonth;
            iSetMain.StartDate = "01/" + iMain.Returnmonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(iMain.Returnmonth);
            iSetMain.ReportName = "Part-3";
            string[] part3Notes = { "1", "2", "3", "4", "5", "6", "7", "8" };

            string tblPartThree = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
            <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr style='text-align:center;'>
                    <td colspan='6' style='text-align:center;background-color:#E2BFF1;'><b> অংশ-৩: সরবরাহ প্রদান - প্রদেয় কর </b></td>
                </tr>
                <tr>
                    <th colspan='2' style='text-align:center'> সরবরাহের প্রকৃতি </th>
                    <th> নোট </th>
                    <th> মূল্য (ক) </th>
                    <th> এসডি (খ) </th>
                    <th> মূসক (গ) </th>
                </tr>";

            string n1Value = "", n1SD = "", n1VAT = "",
                   n2Value = "", n2SD = "", n2VAT = "",
                   n3Value = "", n3SD = "", n3VAT = "",
                   n4Value = "", n4SD = "", n4VAT = "",
                   n5Value = "", n5SD = "", n5VAT = "",
                   n6Value = "", n6SD = "", n6VAT = "",
                   n7Value = "", n7SD = "", n7VAT = "",
                   n8Value = "", n8SD = "", n8VAT = "";

            double part3_Total_Value = 0.00;
            double part3_Total_SD = 0.00;
            double part3_Total_VAT = 0.00;
            foreach (string Notes in part3Notes)
            {
                iSetMain.NoteNo = Notes;
                DataTable dtPartThree = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                if (Notes == "1")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n1Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n1SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n1VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "2")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n2Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n2SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n2VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "3")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n3Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n3SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n3VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "4")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n4Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n4SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n4VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "5")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n5Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n5SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n5VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "6")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n6Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n6SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n6VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "7")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n7Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n7SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n7VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }
                else if (Notes == "8")
                {
                    if (dtPartThree.Rows.Count > 0)
                    {
                        n8Value = dtPartThree.Rows[0]["Sales_Total_Price"].ToString();
                        n8SD = dtPartThree.Rows[0]["Sales_SD_Amount"].ToString();
                        n8VAT = dtPartThree.Rows[0]["Sales_VAT_Amount"].ToString();
                    }
                }

                if (dtPartThree.Rows.Count > 0)
                {
                    part3_Total_Value += Convert.ToDouble(dtPartThree.Rows[0]["Sales_Total_Price"]);
                    part3_Total_SD += Convert.ToDouble(dtPartThree.Rows[0]["Sales_SD_Amount"]);
                    part3_Total_VAT += Convert.ToDouble(dtPartThree.Rows[0]["Sales_VAT_Amount"]);
                }
            }

            tblPartThree = tblPartThree + @"<tr>"
                + "<td rowspan='2' style='width:180px'> শূন্যহার বিশিষ্ট পণ্য/সেবা </td>"
                + "<td> সরাসরি রপ্তানি </td>"
                + "<td> ১ </td>"
                + "<td style='text-align:right;'> " + n1Value + " </td>"
                + "<td style='text-align:right;'> " + n1SD + " </td>"
                + "<td style='text-align:right;'> " + n1VAT + " </td>"
                + "<td onclick='goToSubForm_A(1)' class='subForms'> সাবফর্ম </td></tr>";

            tblPartThree = tblPartThree + @"<tr>
                <td> প্রচ্ছন্ন রপ্তানি </td>
                <td> ২ </td>
                <td style='text-align:right;'>  " + n2Value + @"  </td>
                <td style='text-align:right;'>  " + n2SD + @"  </td>
                <td style='text-align:right;'>  " + n2VAT + @"  </td>
                <td onclick='goToSubForm_A(2)' class='subForms'> সাবফর্ম </td>
                </tr>";

            tblPartThree = tblPartThree + @"<tr>
                <td colspan='2'> অব্যাহতিপ্রাপ্ত পণ্য /সেবা </td>
                <td> ৩ </td>
                <td style='text-align:right;'> " + n3Value + @" </td>
                <td style='text-align:right;'> " + n3SD + @" </td>
                <td style='text-align:right;'> " + n3VAT + @" </td>
                <td onclick='goToSubForm_A(3)' class='subForms'> সাবফর্ম </td>
                </tr>";
            tblPartThree = tblPartThree + @"<tr>
                <td colspan='2'> আদর্শহরের পণ্য /সেবা </td>
                <td> ৪ </td>
                <td style='text-align:right;'> " + n4Value + @" </td>
                <td style='text-align:right;'> " + n4SD + @" </td>
                <td style='text-align:right;'> " + n4VAT + @" </td>
                <td onclick='goToSubForm_A(4)' class='subForms'> সাবফর্ম </td>
                </tr>";
            tblPartThree = tblPartThree + @"<tr>
                <td colspan='2'> সর্বোচ্চ খুচরা মূল্যভিত্তিক পণ্য </td>
                <td> ৫ </td>
                <td style='text-align:right;'> " + n5Value + @" </td>
                <td style='text-align:right;'> " + n5SD + @" </td>
                <td style='text-align:right;'> " + n5VAT + @" </td>
                <td onclick='goToSubForm_A(5)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                <td colspan='2'> সুনির্দিষ্ট কর ভিত্তিক পণ্য/সেবা </td>
                <td> ৬ </td>
                <td style='text-align:right;'> " + n6Value + @" </td>
                <td style='text-align:right;'> " + n6SD + @" </td>
                <td style='text-align:right;'> " + n6VAT + @" </td>
                <td onclick='goToSubForm_C(6)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                <td colspan='2'> আদর্শকরহার ব্যাতীত ভিন্ন করহার ভিত্তিক পণ্য/সেবা </td>
                <td> ৭ </td>
                <td style='text-align:right;'> " + n7Value + @" </td>
                <td style='text-align:right;'> " + n7SD + @" </td>
                <td style='text-align:right;'> " + n7VAT + @" </td>
                <td onclick='goToSubForm_A(7)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                <td colspan='2'> খুচরা/পাইকারী/ব্যাবসায়ী ভিত্তিক সরবরাহ  </td>
                <td> ৮ </td>
                <td style='text-align:right;'> " + n8Value + @" </td>
                <td style='text-align:right;'> " + n8SD + @" </td>
                <td style='text-align:right;'> " + n8VAT + @" </td>
                <td onclick='goToSubForm_B(8)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                <th colspan='2'> মোট বিক্রয় মূল্য ও মোট প্রদেয় কর </th>
                <th> ৯ </th>
                <th style='text-align:right;'> " + GetCommaFormat(part3_Total_Value) + @" </th>
                <th style='text-align:right;'> " + GetCommaFormat(part3_Total_SD) + @" </th>
                <th style='text-align:right;'> " + GetCommaFormat(part3_Total_VAT) + @" </th>
                </tr>
                </table>
                </div>
                </div>";

            //int NotesForPart4 = 13;

            string[] part4Notes = { "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22" };
            string tblPartFour = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr style='text-align:center;'>
                    <td colspan='5' style='text-align:center;background-color:#E2BFF1;'><b> অংশ-৪: ক্রয় উপকরণ কর </b></td>
                </tr>
                <tr>
                    <th colspan='2' style='text-align:center'> ক্রয়ের প্রকৃতি </th>
                    <th> নোট </th>
                    <th> মূল্য (ক) </th>
                    <th> মূসক (খ) </th>
                </tr>";

            string n10Value = "", n10VAT = "",
                   n11Value = "", n11VAT = "",
                   n12Value = "", n12VAT = "",
                   n13Value = "", n13VAT = "",
                   n14Value = "", n14VAT = "",
                   n15Value = "", n15VAT = "",
                   n16Value = "", n16VAT = "",
                   n17Value = "", n17VAT = "",
                   n18Value = "", n18VAT = "",
                   n19Value = "", n19VAT = "",
                   n20Value = "", n20VAT = "",
                   n21Value = "", n21VAT = "",
                   n22Value = "", n22VAT = "";

            double part4_Total_Value = 0.00;
            double part4_Total_VAT = 0.00;

            iSetMain.StartDate = "01/" + iMain.Returnmonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(iMain.Returnmonth);
            iSetMain.ReportName = "Part-4";
            foreach (string Notes in part4Notes)
            {
                iSetMain.NoteNo = Notes;
                DataTable dtPartFour = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                switch (Notes)
                {
                    case "10":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n10Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n10VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "11":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n11Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n11VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "12":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n12Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n12VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "13":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n13Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n13VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "14":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n14Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n14VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "15":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n15Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n15VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "16":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n16Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n16VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "17":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n17Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n17VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "18":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n18Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n18VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "19":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n19Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n19VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "20":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n20Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n20VAT = dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "21":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n21Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n21VAT = "0"; //dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                    case "22":
                        if (dtPartFour.Rows.Count > 0)
                        {
                            n22Value = dtPartFour.Rows[0]["Purchase_Total_Price"].ToString();
                            n22VAT = "0"; //dtPartFour.Rows[0]["Purchase_VAT_Amount"].ToString();
                        }

                        break;
                }

                if (dtPartFour.Rows.Count > 0)
                {
                    part4_Total_Value += Convert.ToDouble(dtPartFour.Rows[0]["Purchase_Total_Price"]);
                    part4_Total_VAT += Convert.ToDouble(dtPartFour.Rows[0]["Purchase_VAT_Amount"]);
                }
            }

            tblPartFour = tblPartFour + @"<tr>
                    <td rowspan='2' style='width:300px'> শূন্যহার বিশিষ্ট পণ্য/সেবা </td>
                    <td> স্থানীয় ক্রয় </td>
                    <td> ১০ </td>
                    <td style='text-align:right;'>  " + n10Value + @"  </td>
                    <td style='text-align:right;'>  " + n10VAT + @"  </td>
                    <td onclick='goToSubForm_A(10)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আমদানি </td>
                    <td> ১১ </td>
                    <td style='text-align:right;'> " + n11Value + @" </td>
                    <td style='text-align:right;'> " + n11VAT + @" </td>
                    <td onclick='goToSubForm_A(11)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td rowspan='2' style='width:300px'> অব্যাহতিপ্রাপ্ত পণ্য/সেবা </td>
                    <td> স্থানীয় ক্রয় </td>
                    <td> ১২ </td>
                    <td style='text-align:right;'> " + n12Value + @" </td>
                    <td style='text-align:right;'> " + n12VAT + @" </td>
                    <td onclick='goToSubForm_A(12)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আমদানি </td>
                    <td> ১৩ </td>
                    <td style='text-align:right;'> " + n13Value + @" </td>
                    <td style='text-align:right;'> " + n13VAT + @" </td>
                    <td onclick='goToSubForm_A(13)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td rowspan='2' style='width:300px'> আদর্শহরের পণ্য /সেবা </td>
                    <td> স্থানীয় ক্রয় </td>
                    <td> ১৪ </td>
                    <td style='text-align:right;'> " + n14Value + @" </td>
                    <td style='text-align:right;'> " + n14VAT + @" </td>
                    <td onclick='goToSubForm_A(14)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আমদানি </td>
                    <td> ১৫ </td>
                    <td style='text-align:right;'> " + n15Value + @" </td>
                    <td style='text-align:right;'> " + n15VAT + @" </td>
                    <td onclick='goToSubForm_A(15)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td rowspan='2' style='width:300px'> আদর্শকরহার ব্যাতীত ভিন্ন করহার ভিত্তিক পণ্য/সেবা </td>
                    <td> স্থানীয় ক্রয় </td>
                    <td> ১৬ </td>
                    <td style='text-align:right;'> " + n16Value + @" </td>
                    <td style='text-align:right;'> " + n16VAT + @"  </td>
                    <td onclick='goToSubForm_A(16)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আমদানি </td>
                    <td> ১৭ </td>
                    <td style='text-align:right;'> " + n17Value + @" </td>
                    <td style='text-align:right;'> " + n17VAT + @" </td>
                    <td onclick='goToSubForm_A(17)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> সুনিদৃষ্ট কর </td>
                    <td> স্থানীয় ক্রয় </td>
                    <td> ১৮ </td>
                    <td style='text-align:right;'> " + n18Value + @" </td>
                    <td style='text-align:right;'> " + n18VAT + @" </td>
                    <td onclick='goToSubForm_A(18)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td rowspan='2' style='width:300px'> রেয়াতযোগ্য নয় এরুপ পণ্য/সেবা (স্থানীয় ক্রয়) </td>
                    <td> টার্নওভার প্রতিষ্ঠান হইতে </td>
                    <td> ১৯ </td>
                    <td style='text-align:right;'> " + n19Value + @" </td>
                    <td style='text-align:right;'> " + n19VAT + @" </td>
                    <td onclick='goToSubForm_A(19)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> অনিবন্ধিত প্রতিষ্ঠান হইতে </td>
                    <td> ২০ </td>
                    <td style='text-align:right;'> " + n20Value + @" </td>
                    <td style='text-align:right;'> " + n20VAT + @" </td>
                    <td onclick='goToSubForm_A(20)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td rowspan='2' style='width:300px'>
                        রেয়াতযোগ্য নয় এরুপ পণ্য/সেবা
                        (যেসকল করদাতা শুধু মাত্র
                        অব্যাহতিপ্রাপ্ত/ প্রমিত হার  ব্যাতিত
                        অনন্যা হারের বিপরীত পণ্য/সেবা
                    </td>
                    <td> স্থানীয় ক্রয় </td>
                    <td> ২১ </td>
                    <td style='text-align:right;'> " + n21Value + @" </td>
                    <td style='text-align:right;'> " + n21VAT + @" </td>
                    <td onclick='goToSubForm_A(21)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আমদানি </td>
                    <td> ২২ </td>
                    <td style='text-align:right;'> " + n22Value + @" </td>
                    <td style='text-align:right;'> " + n22VAT + @" </td>
                    <td onclick='goToSubForm_A(22)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <th colspan='2'> মোট উপকরণ কর রেয়াত </th>
                    <th> ২৩ </th>
                    <th style='text-align:right;'> " + GetCommaFormat(part4_Total_Value) + @" </th>
                    <th style='text-align:right;'> " + GetCommaFormat(part4_Total_VAT) + @" </th>
                </tr>
            </table>
        </div>

    </div>";

            string[] part5Notes = { "24", "25", "26", "27" };
            double total_Increasing_Amnt = 0.00;
            string n24Value = "", n25Value = "", n26Value = "", n27Value = "";
            iSetMain.StartDate = "01/" + iMain.Returnmonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(iMain.Returnmonth);
            iSetMain.ReportName = "Part-5";
            foreach (string Notes in part5Notes)
            {
                iSetMain.NoteNo = Notes;
                if (Notes == "24")
                {
                    DataTable dtPartFive_N24 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartFive_N24.Rows.Count > 0)
                    {
                        n24Value = dtPartFive_N24.Rows[0]["TotalVDS"].ToString();
                        total_Increasing_Amnt = total_Increasing_Amnt + Convert.ToDouble(n24Value);
                    }
                }
                else if (Notes == "25")
                {
                    n25Value = "";
                }
                else if (Notes == "26")
                {
                    DataTable dtPartFive_N26 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartFive_N26.Rows.Count > 0)
                    {
                        n26Value = dtPartFive_N26.Rows[0]["NetAmount"].ToString();
                        total_Increasing_Amnt = total_Increasing_Amnt + Convert.ToDouble(n26Value);
                    }
                }
                else if (Notes == "27")
                {
                    DataTable dtPartFive_N27 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartFive_N27.Rows.Count > 0)
                    {
                        n27Value = dtPartFive_N27.Rows[0]["Total_Calculated_VAT_Amount"].ToString();
                        total_Increasing_Amnt = total_Increasing_Amnt + Convert.ToDouble(n27Value);
                    }
                }

            }
            string tblPartFive = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
            <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr style='text-align:center;'>
                    <td colspan='3' style='text-align:center;background-color:#E2BFF1;'><b> অংশ- ৫: বৃদ্ধিকারী সমন্বয় (মূল্য সংযোজন কর) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> সমন্বয় ঘটনা </th>
                    <th> নোট </th>
                    <th> পরিমাণ </th>
                </tr>
                <tr>
                    <td> সরবরাহ গ্রহীতা কর্তৃক উৎসে কর্তনের জন্য </td>
                    <td> ২৪ </td>
                    <td> " + n24Value + @" </td>
                    <td onclick='goToSubForm_D(24)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> ব্যাংকিং চ্যানেলে মূল্য পরিশোধিত হয় নাই এমন সরবরাহের জন্য </td>
                    <td> ২৫ </td>
                    <td> " + n25Value + @" </td>
                </tr>
                <tr>
                    <td> ডেবিট নোটের জন্য </td>
                    <td> ২৬ </td>
                    <td> " + n26Value + @" </td>
                </tr>
                <tr>
                    <td> অন্যকোনো সমন্বয় ঘটনার জন্য (নিচে বর্ণনা করুন) </td>
                    <td> ২৭ </td>
                    <td> " + n27Value + @" </td>
                    <td onclick='detailedViewNote27()' class='detailForms'> বিস্তারিত </td>
                </tr>
                <tr>
                    <th style='text-align:right;'> মোট বৃদ্ধিকারী সমন্বয় </th>
                    <th> ২৮ </th>
                    <th> " + total_Increasing_Amnt.ToString("0.00") + @" </th>
                </tr>
            </table>
        </div>
    </div>";

            string[] part6Notes = { "29", "30", "31", "32" };
            double total_Decreasing_Amnt = 0.00;
            string n29Value = "0", n30Value = "0", n31Value = "0", n32Value = "0", n33Value = "0";
            iSetMain.StartDate = "01/" + iMain.Returnmonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(iMain.Returnmonth);
            iSetMain.ReportName = "Part-6";
            foreach (string Notes in part6Notes)
            {
                iSetMain.NoteNo = Notes;
                if (Notes == "29")
                {
                    DataTable dtPartSix_N29 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSix_N29.Rows.Count > 0)
                    {
                        n29Value = dtPartSix_N29.Rows[0]["TotalVDS"].ToString();
                        total_Decreasing_Amnt = total_Decreasing_Amnt + Convert.ToDouble(n29Value);
                    }
                }
                else if (Notes == "30")
                {
                    DataTable dtPartSix_N30 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSix_N30.Rows.Count > 0)
                    {
                        n30Value = dtPartSix_N30.Rows[0]["ATAmount"].ToString();
                        total_Decreasing_Amnt = total_Decreasing_Amnt + Convert.ToDouble(n30Value);
                    }
                }
                else if (Notes == "31")
                {
                    DataTable dtPartSix_N32 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSix_N32.Rows.Count > 0)
                    {
                        n32Value = dtPartSix_N32.Rows[0]["NetAmount"].ToString();
                        total_Decreasing_Amnt = total_Decreasing_Amnt + Convert.ToDouble(n32Value);
                    }
                }
                else if (Notes == "32")
                {
                    DataTable dtPartSix_N33 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSix_N33.Rows.Count > 0)
                    {
                        n33Value = dtPartSix_N33.Rows[0]["Total_Calculated_VAT_Amount"].ToString();
                        total_Decreasing_Amnt = total_Decreasing_Amnt + Convert.ToDouble(n33Value);
                    }
                }
            }
            string tblPartSix = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr style='text-align:center;'>
                    <td colspan='3' style='text-align:center;background-color:#E2BFF1;'><b> অংশ- ৬: হ্রাসকারী সমন্বয় (মূল্য সংযোজন কর) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> সমন্বয় ঘটনা </th>
                    <th> নোট </th>
                    <th> পরিমাণ </th>
                </tr>
                <tr>
                    <td> প্রদত্ত সরবরাহ হইতে উৎসে কর্তনের জন্য </td>
                    <td> ২৯ </td>
                    <td> " + n29Value + @" </td>
                    <td onclick='goToSubForm_E(29)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আমদানি পর্যায়ে প্রদেয় আগাম কর </td>
                    <td> ৩০ </td>
                    <td> " + n30Value + @" </td>
                    <td onclick='goToSubForm_F(30)' class='subForms'> সাবফর্ম </td>
                </tr>

                <tr>
                    <td> ক্রেডিট নোট ইস্যুর জন্য </td>
                    <td> ৩১ </td>
                    <td> " + n32Value + @" </td>
                </tr>
                <tr>
                    <td> অন্যকোনো সমন্বয় ঘটনার জন্য (নিচে বর্ণনা করুন) </td>
                    <td> ৩২ </td>
                    <td> " + n33Value + @" </td>
                    <td onclick='detailedViewNote32()' class='detailForms'> বিস্তারিত </td>
                </tr>
                <tr>
                    <th style='text-align:right;'> মোট হ্রাসকারী সমন্বয় </th>
                    <th> ৩৩ </th>
                    <th> " + total_Decreasing_Amnt.ToString("0.000") + @" </th>
                </tr>
            </table>
        </div>
    </div>";



            string[] part7Notes = { "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53" };
            string n34Value = "0.00",
                   n35Value = "0.00",
                   n36Value = "0.00",
                   n37Value = "0.00",
                   n38Value = "0.00",
                   n39Value = "0.00",
                   n40Value = "0.0000",
                   n41Value = "0.00",
                   n42Value = "0.00",
                   n43Value = "0.00",
                   n44Value = "0.00",
                   n45Value = "0.00",
                   n46Value = "0.00",
                   n47Value = "0.00",
                   n48Value = "0.00",
                   n49Value = "0.00",
                   n50Value = "0.00",
                   n51Value = "0.00",
                   n52Value = "0.00",
                   n53Value = "0.00";

            //----Get Previous Month Closing
            VatReturnsubmissionEntity thisMonthOpening = new VatReturnsubmissionEntity();
            string currentMonth = iMain.Returnmonth.Substring(3, 2);
            string currentYear = iMain.Returnmonth.Substring(6, 4);
            string prevMonth = "";
            string prevYear = currentYear;
            if (currentMonth == "01" || currentMonth == "1")
            {
                prevMonth = "12";
                prevYear = (Convert.ToDouble(currentYear) - 1).ToString();
            }
            else
                prevMonth = (Convert.ToDouble(currentMonth) - 1).ToString("00");

            thisMonthOpening.StartDate = "01/" + prevMonth + "/" + prevYear;
            thisMonthOpening.EndDate = getEndDateForReturn(thisMonthOpening.StartDate);
            DataTable dtOpeningData = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, thisMonthOpening);
            if (dtOpeningData.Rows.Count > 0)
            {
                n52Value = dtOpeningData.Rows[0]["VATClosing"].ToString();
                n53Value = dtOpeningData.Rows[0]["SDClosing"].ToString();
            }

            iSetMain.StartDate = "01/" + iMain.Returnmonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(iMain.Returnmonth);
            iSetMain.ReportName = "Part-7";
            foreach (string Notes in part7Notes)
            {
                iSetMain.NoteNo = Notes;
                if (Notes == "34")
                {
                    n34Value = (Convert.ToDouble(part3_Total_VAT) - Convert.ToDouble(part4_Total_VAT) + Convert.ToDouble(total_Increasing_Amnt) - Convert.ToDouble(total_Decreasing_Amnt)).ToString("0.00");
                }
                else if (Notes == "38")
                {
                    DataTable dtPartSeven_N38 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSeven_N38.Rows.Count > 0)
                    {
                        n38Value = dtPartSeven_N38.Rows[0]["TotalSD"].ToString();
                    }
                }
                else if (Notes == "39")
                {
                    DataTable dtPartSeven_N39 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSeven_N39.Rows.Count > 0)
                    {
                        n39Value = dtPartSeven_N39.Rows[0]["TotalSD"].ToString();
                    }
                }
                else if (Notes == "40")
                {
                    DataTable dtPartSeven_N40 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                    if (dtPartSeven_N40.Rows.Count > 0)
                    {
                        n40Value = Convert.ToDouble(dtPartSeven_N40.Rows[0]["Total_Calculated_SD_Amount"].ToString()).ToString("0.0000");
                    }
                }
            }
            n36Value = (Convert.ToDouble(part3_Total_SD) - Convert.ToDouble(n38Value) - Convert.ToDouble(n39Value) - Convert.ToDouble(n40Value)).ToString("0.00");

            string[] part8Notes = { "54", "55", "56", "57" };
            string n54Value = "0", n55Value = "0", n56Value = "0", n57Value = "0";
            iSetMain.SrcMonth = iMain.Returnmonth.Substring(3, 2);
            iSetMain.ReportName = "Part-8";
            foreach (string Notes in part8Notes)
            {
                iSetMain.NoteNo = Notes;
                switch (Notes)
                {
                    case "54":
                        {
                            DataTable dtPartEight_N54 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartEight_N54.Rows.Count > 0)
                            {
                                n54Value = dtPartEight_N54.Rows[0]["VAT"].ToString();
                            }

                            break;
                        }
                    case "55":
                        {
                            DataTable dtPartEight_N55 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartEight_N55.Rows.Count > 0)
                            {
                                n55Value = dtPartEight_N55.Rows[0]["SD"].ToString();
                            }

                            break;
                        }
                    case "56":
                        {
                            double n34 = (Convert.ToDouble(part3_Total_VAT) - Convert.ToDouble(part4_Total_VAT) + Convert.ToDouble(total_Increasing_Amnt) - Convert.ToDouble(total_Decreasing_Amnt));
                            if (Convert.ToDouble(n34) > 0)
                            {
                                double tenPer = Convert.ToDouble(n34) * (10 / 100);
                                n56Value = tenPer.ToString();
                            }

                            break;
                        }
                    case "57":
                        {
                            if (Convert.ToDouble(n36Value) > 0)
                            {
                                double tenPer = Convert.ToDouble(n36Value) * (10 / 100);
                                n57Value = tenPer.ToString();
                            }

                            break;
                        }
                }
            }

            n35Value = (Convert.ToDouble(n34Value) - Convert.ToDouble(n52Value) + Convert.ToDouble(n56Value)).ToString();
            n37Value = (Convert.ToDouble(n36Value) - Convert.ToDouble(n53Value) + Convert.ToDouble(n57Value)).ToString();
            n50Value = (Convert.ToDouble(n35Value) + Convert.ToDouble(n41Value) + Convert.ToDouble(n43Value) + Convert.ToDouble(n44Value)).ToString();
            n51Value = (Convert.ToDouble(n37Value) + Convert.ToDouble(n42Value)).ToString();

            string tblPartSeven = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr style='text-align:center;'>
                    <td colspan='3' style='text-align:center;background-color:#E2BFF1;'><b> অংশ-৭: নীট কর হিসাব </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> আইটেম </th>
                    <th> নোট </th>
                    <th> পরিমাণ </th>
                </tr>
                <tr>
                    <td> বর্তমান করমেয়াদে প্রদেয় মোট মূসক (সেকশন-৪৫)(৯গ-২৩খ+২৮-৩৩) </td>
                    <td> ৩৪ </td>
                    <td> " + n34Value + @" </td>
                </tr>
                <tr>
                    <td> সমাপনী জের এবং ফরম ১৮.৬ এর সহিত সমন্বয়ের পর বর্তমান করমেয়াদে প্রদেয় মোট মূসক [৩৪-(৫২+৫৬)] </td>
                    <td> ৩৫ </td>
                    <td> " + n35Value + @" </td>
                </tr>
                <tr>
                    <td> বর্তমান করমেয়াদে প্রদেয় মোট সম্পূরক শুল্ক (সমাপনী জের এর সহিত সমন্বয় ব্যাতীত) (৯খ+৩৮-৩৯-৪০) </td>
                    <td> ৩৬ </td>
                    <td> " + n36Value + @" </td>
                </tr>
                <tr>
                    <td> সমাপনী জের এবং ফরম ১৮.৬ জের এর সহিত সমন্বয়ের পর বর্তমান করমেয়াদে প্রদেয় মোট সম্পূরক শুল্ক [৩৬-(৫৩+৫৭)] </td>
                    <td> ৩৭ </td>
                    <td> " + n37Value + @" </td>
                </tr>
                <tr>
                    <td> ডেবিট নোট ইস্যুর জন্য সমন্বয়কৃত সম্পূরক শুল্ক </td>
                    <td> ৩৮ </td>
                    <td> " + n38Value + @" </td>
                </tr>
                <tr>
                    <td> ক্রেডিট নোট ইস্যুর জন্য সমন্বয়কৃত সম্পূরক শুল্ক </td>
                    <td> ৩৯ </td>
                    <td> " + n39Value + @" </td>
                </tr>
                <tr>
                    <td> রপ্তানিকৃত কাঁচামালের বিপরীতে প্রদেয় সম্পূরক শুল্ক </td>
                    <td> ৪০ </td>
                    <td onclick='detailedViewNote40()' class='detailForms'><b>" + n40Value + @"</b></td>
                </tr>
                <tr>
                    <td> অপরিশোধিত মূসকের জন্য সুদ </td>
                    <td> ৪১ </td>
                    <td> " + n41Value + @" </td>
                </tr>
                <tr>
                    <td> অপরিশোধিত সম্পূরক শুল্ক এর জন্য সুদ </td>
                    <td> ৪২ </td>
                    <td> " + n42Value + @" </td>
                </tr>
                <tr>
                    <td> দাখিলপত্র দাখিল না করার কারনে অর্থদণ্ড ও জরিমানা </td>
                    <td> ৪৩ </td>
                    <td> " + n43Value + @" </td>
                </tr>
                <tr>
                    <td> অন্যান্য অর্থদণ্ড / জরিমানা / সুদ </td>
                    <td> ৪৪ </td>
                    <td> " + n44Value + @" </td>
                </tr>
                <tr>
                    <td> প্রদেয় আবগারি শুল্ক </td>
                    <td> ৪৫ </td>
                    <td> " + n45Value + @" </td>
                </tr>
                <tr>
                    <td> প্রদেয় উন্নয়ন সারচার্জ </td>
                    <td> ৪৬ </td>
                    <td> " + n46Value + @" </td>
                </tr>
                <tr>
                    <td> প্রদেয় তথ্য প্রযুক্তি উন্নয়ন সারচার্জ </td>
                    <td> ৪৭ </td>
                    <td> " + n47Value + @" </td>
                </tr>
                <tr>
                    <td> প্রদেয় স্বাস্থ্য সুরক্ষা সারচার্জ </td>
                    <td> ৪৮ </td>
                    <td> " + n48Value + @" </td>
                </tr>
                <tr>
                    <td> প্রদেয় পরিবেশ সুরক্ষা সারচার্জ </td>
                    <td> ৪৯ </td>
                    <td> " + n49Value + @" </td>
                </tr>
                <tr>
                    <td> নীট প্রদেয় মুসক (ট্রেজারি জমার জন্য) (৩৫+৪১+৪৩+৪৪) </td>
                    <td> ৫০ </td>
                    <td> " + n50Value + @" </td>
                </tr>
                <tr>
                    <td> নীট প্রদেয় সম্পুরক শুল্ক (ট্রেজারি জমার জন্য) (৩৭+৪২) </td>
                    <td> ৫১ </td>
                    <td> " + n51Value + @" </td>
                </tr>
                <tr>
                    <td> শেষ করমেয়াদের সমাপনী জের (মূল্য সংযোজন কর) </td>
                    <td> ৫২ </td>
                    <td> " + n52Value + @" </td>
                </tr>
                <tr>
                    <td> শেষ করমেয়াদের সমাপনী জের (সম্পূরক শুল্ক) </td>
                    <td> ৫৩ </td>
                    <td> " + n53Value + @" </td>
                </tr>
            </table>
        </div>
    </div>";


            string tblPartEight = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
            <div class='uk-width-medium-1-1'>
                <table id='tablePart3'>
                    <tr style='text-align:center;'>
                        <td colspan='3' style='text-align:center;background-color:#E2BFF1;'><b> অংশ-৮ : পুরাতন চলতি হিসাবের সমন্বয় </b></td>
                    </tr>
                    <tr>
                        <th style='text-align:center'> আইটেম </th>
                        <th> নোট </th>
                        <th> পরিমাণ </th>
                    </tr>
                    <tr>
                        <td> মূসক ১৮.৬ এর জের (মূসক) [বিধি ১১৮(৫)] </td>
                        <td> ৫৪ </td>
                        <td> " + n54Value + @" </td>
                    </tr>
                    <tr>
                        <td> মূসক ১৮.৬ এর জের (সম্পূরক শুল্ক) [বিধি ১১৮(৫)] </td>
                        <td> ৫৫ </td>
                        <td> " + n55Value + @" </td>
                    </tr>
                    <tr>
                        <td> হ্রাসকারি সমন্বয় (মূসক) </td>
                        <td> ৫৬ </td>
                        <td> " + n56Value + @" </td>
                    </tr>
                    <tr>
                        <td> হ্রাসকারি সমন্বয় (সম্পূরক শুল্ক) </td>
                        <td> ৫৭ </td>
                        <td> " + n57Value + @" </td>
                    </tr>
                </table>
            </div>
        </div>";

            string[] part9Notes = { "58", "59", "60", "61", "62", "63", "64" };
            double part9Amnt = 0.00;
            string n58Value = "0", n59Value = "0", n60Value = "0", n61Value = "0", n62Value = "0", n63Value = "0", n64Value = "0";
            iSetMain.StartDate = "01/" + iMain.Returnmonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(iMain.Returnmonth);
            iSetMain.ReportName = "Part-9";
            foreach (string Notes in part9Notes)
            {
                iSetMain.NoteNo = Notes;
                switch (Notes)
                {
                    case "58":
                        {
                            DataTable dtPartNine_N58 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N58.Rows.Count > 0)
                            {
                                n58Value = dtPartNine_N58.Rows[0]["TreasuryAmnt"].ToString();

                            }

                            break;
                        }

                    case "59":
                        {
                            DataTable dtPartNine_N59 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N59.Rows.Count > 0)
                            {
                                n59Value = dtPartNine_N59.Rows[0]["TreasuryAmnt"].ToString();
                            }

                            break;
                        }
                    case "60":
                        {
                            DataTable dtPartNine_N60 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N60.Rows.Count > 0)
                            {
                                n60Value = dtPartNine_N60.Rows[0]["TreasuryAmnt"].ToString();
                            }

                            break;
                        }
                    case "61":
                        {
                            DataTable dtPartNine_N61 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N61.Rows.Count > 0)
                            {
                                n61Value = dtPartNine_N61.Rows[0]["TreasuryAmnt"].ToString();
                            }

                            break;
                        }
                    case "62":
                        {
                            DataTable dtPartNine_N62 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N62.Rows.Count > 0)
                            {
                                n62Value = dtPartNine_N62.Rows[0]["TreasuryAmnt"].ToString();
                            }

                            break;
                        }
                    case "63":
                        {
                            DataTable dtPartNine_N63 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N63.Rows.Count > 0)
                            {
                                n63Value = dtPartNine_N63.Rows[0]["TreasuryAmnt"].ToString();
                            }

                            break;
                        }
                    case "64":
                        {
                            DataTable dtPartNine_N64 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartNine_N64.Rows.Count > 0)
                            {
                                n64Value = dtPartNine_N64.Rows[0]["TreasuryAmnt"].ToString();
                            }

                            break;
                        }
                }
            }

            string tblPartNine = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr style='text-align:center;'>
                    <td colspan='4' style='text-align:center;background-color:#E2BFF1;'><b> অংশ- ৯: কর পরিশোধের তফসিল (ট্রেজারী জমা) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> আইটেম </th>
                    <th> নোট </th>
                    <th> অর্থনৈতিক কোড </th>
                    <th> পরিমাণ </th>
                </tr>
                <tr>
                    <td> বর্তমান কর মেয়াদে পরিশোধিত মোট মূসক </td>
                    <td> ৫৮ </td>
                    <td>  </td>
                    <td> " + n58Value + @" </td>
                    <td onclick='goToSubForm_G(58)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> বর্তমান কর মেয়াদে পরিশোধিত মোট সম্পূরক শুল্ক </td>
                    <td> ৫৯ </td>
                    <td>  </td>
                    <td> " + n59Value + @" </td>
                    <td onclick='goToSubForm_G(59)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> আবগারি শুল্ক </td>
                    <td> ৬০ </td>
                    <td>  </td>
                    <td> " + n60Value + @" </td>
                    <td onclick='goToSubForm_G(60)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> উন্নয়ন সারচার্জ </td>
                    <td> ৬১ </td>
                    <td>  </td>
                    <td> " + n61Value + @" </td>
                    <td onclick='goToSubForm_G(61)' class='subForms'> সাবফর্ম </td>
                </tr>

                <tr>
                    <td> তথ্য প্রযুক্তি উন্নয়ন সারচার্জ </td>
                    <td> ৬২ </td>
                    <td>  </td>
                    <td> " + n62Value + @" </td>
                    <td onclick='goToSubForm_G(62)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> স্বাস্থ্য সুরক্ষা সারচার্জ </td>
                    <td> ৬৩ </td>
                    <td>  </td>
                    <td> " + n63Value + @" </td>
                    <td onclick='goToSubForm_G(63)' class='subForms'> সাবফর্ম </td>
                </tr>
                <tr>
                    <td> পরিবেশ সুরক্ষা সারচার্জ </td>
                    <td> ৬৪ </td>
                    <td>  </td>
                    <td> " + n64Value + @" </td>
                    <td onclick='goToSubForm_G(64)' class='subForms'> সাবফর্ম </td>
                </tr>
            </table>
        </div>
    </div>";

            string[] part11Notes = { "67", "68" };
            string n65Value = "0", n66Value = "0", n67Value = "0", n68Value = "0";
            string RefundModVAT = "0", RefundModSD = "0"; //Dis-approved Refund Amount

            iSetMain.SrcMonth = iMain.Returnmonth.Substring(3, 2);
            iSetMain.ReportName = "Part-11";
            foreach (string Notes in part11Notes)
            {
                iSetMain.NoteNo = Notes;
                switch (Notes)
                {
                    case "67":
                        {
                            DataTable dtPartEle_N67 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartEle_N67.Rows.Count > 0)
                            {
                                n67Value = dtPartEle_N67.Rows[0]["VAT"].ToString();
                            }

                            break;
                        }
                    case "68":
                        {
                            DataTable dtPartEle_N68 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                            if (dtPartEle_N68.Rows.Count > 0)
                            {
                                n68Value = dtPartEle_N68.Rows[0]["SD"].ToString();
                            }

                            break;
                        }
                }
            }

            n65Value = (Convert.ToDouble(n58Value) - (Convert.ToDouble(n50Value) + Convert.ToDouble(n67Value)) + RefundModVAT).ToString();
            n66Value = (Convert.ToDouble(n59Value) - (Convert.ToDouble(n51Value) + Convert.ToDouble(n68Value)) + RefundModSD).ToString();

            string tblPart_10_11 = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
                <div class='uk-width-medium-1-1'>
                    <table id='tablePart3'>
                        <tr style='text-align:center;'>
                            <td colspan='3' style='text-align:center;background-color:#E2BFF1;'><b> অংশ- ১০: সমাপনী জের (পরবর্তী কর মেয়াদের প্রারম্ভিক জের) </b></td>
                        </tr>
                        <tr>
                            <th style='text-align:center'> আইটেম </th>
                            <th> নোট </th>
                            <th> পরিমাণ </th>
                        </tr>
                        <tr>
                            <td> সমাপনী জের (মূল্য সংযোজন কর) [৫৮-(৫০+৬৭)+ করদাতা কর্তৃক দাবিকৃত রিফাণ্ডের পরিমাণ যাহা কমিশনার/রিফাণ্ড Module কর্তৃক অনুমোদিত হয়নি] </td>
                            <td> ৬৫ </td>
                            <td><b>" + n65Value + @"</b></td>
                        </tr>
                        <tr>
                            <td> সমাপনী জের (সম্পূরক শুল্ক) [৫৯-(৫১+৬৮)+ করদাতা কর্তৃক দাবিকৃত রিফাণ্ডের পরিমাণ যাহা কমিশনার/রিফাণ্ড Module কর্তৃক অনুমোদিত হয়নি] </td>
                            <td> ৬৬ </td>
                            <td><b>" + n66Value + @"</b></td>
                        </tr>
                    </table>
                </div>
            </div>

            <div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
                <div class='uk-width-medium-1-1'>
                    <table id='tablePart3'>
                        <tr style='text-align:center;'>
                            <td colspan='4' style='text-align:center;background-color:#E2BFF1;'><b> অংশ- ১১: ফেরত </b></td>
                        </tr>
                        <tr style='text-align:center;'>
                            <td rowspan='3' style='width:100px;'><b> আমি সমাপনী জেরে উল্লিখিত অর্থ ফেরৎ গ্রহণে ইচ্ছুক </b></td>
                            <td style='width:10px;'><b> আইটেম </b></td>
                            <td style='width:20px;'><b> নোট </b></td>
                            <td style='width:20px;'><b> হ্যাঁ / না </b></td>
                        </tr>
                        <tr style='text-align:center;'>
                            <td>  ফেরতযোগ্য মুসকের পরিমাণ  </td>
                            <td>  ৬৭  </td>
                            <td><b> " + n67Value + @" </b></td>
                        </tr>
                        <tr style='text-align:center;'>
                            <td>  ফেরতযোগ্য সম্পুরক শুল্কের পরিমাণ  </td>
                            <td> ৬৮ </td>
                            <td><b>" + n68Value + @"</b></td>
                        </tr>
                    </table>
                </div>
            </div>";

            VatReturnsubmissionEntity updateClosing = new VatReturnsubmissionEntity();
            updateClosing.Id = iMain.Id;
            updateClosing.VATClosing = n65Value;
            updateClosing.SDClosing = n66Value;
            updateClosing.ReportName = "UpdateClosing";
            if (!string.IsNullOrEmpty(updateClosing.Id))
                ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_UpdateVatReturnsubmissionInfo, updateClosing);
            //bool isUpdate = (bool)

            #region Subforms
            string[] subFormANotes = { "1", "2", "3", "4", "5", "7", "10", "11", "12", "13", "14", "15", "16", "17", "19", "20", "21", "22", "23" };

            string tblSubFormA = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='7' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম ( নোট ১,২,৩,৪,৫,৭,১০,১১,১২,১৩,১৪,১৫,১৬,১৭,১৯,২০,২১,২২,২৩ এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> পণ্য/সেবার বর্ণনা </th>
                    <th style='text-align:center'> পণ্য/সেবার কোড </th>
                    <th style='text-align:center'> পণ্য/সেবার নাম </th>
                    <th style='text-align:center'> মূল্য (ক) </th>
                    <th style='text-align:center'> সম্পূরক শুল্ক (খ) </th>
                    <th style='text-align:center'> মূল্য সংযোজন কর (গ) </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";
            int rowCount = 1;
            double subformA_Total_Value = 0.00;
            double subformA_Total_SD = 0.00;
            double subformA_Total_VAT = 0.00;
            foreach (string Notes in subFormANotes)
            {
                iSetMain.ReportName = "Subform-A";
                iSetMain.NoteNo = Notes;
                DataTable dtSubformA = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                switch (Notes)
                {
                    case "1":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "2":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "3":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "4":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "5":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "7":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "10":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "11":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "12":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "13":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "14":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "15":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "16":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "17":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "19":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "20":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "21":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "22":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    case "23":
                        {
                            if (dtSubformA.Rows.Count > 0)
                            {
                                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                                rowCount = 1;
                                foreach (DataRow dr in dtSubformA.Rows)
                                {
                                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> - </td>
                            </tr>";
                                    rowCount += 1;
                                }
                            }

                            break;
                        }
                    default: break;
                }

                if (dtSubformA.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubformA.Rows)
                    {
                        subformA_Total_Value += Convert.ToDouble(dr["TotalPrice"]);
                        subformA_Total_SD += Convert.ToDouble(dr["SD"]);
                        subformA_Total_VAT += Convert.ToDouble(dr["VatAmnt"]);
                    }
                }
            }

            tblSubFormA = tblSubFormA + @"<tr>
                    <th colspan='3' style='text-align:right'> মোট </th>
                    <th style='text-align:center'> " + subformA_Total_Value.ToString("0.000") + @" </th>
                    <th style='text-align:center'> " + subformA_Total_SD.ToString("0.000") + @" </th>
                    <th style='text-align:center'> " + subformA_Total_VAT.ToString("0.000") + @" </th>
                    <th style='text-align:center'> - </th>
                    </tr>
                    </table>
                </div>
            </div>";

            string tblSubFormD = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='14' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম - ঘ ( নোট ২৪ -'সরবরাহকারীর সরবরাহ হইতে উৎসে কর্তনের জন্য' এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> ক্রমিক সংখ্যা </th>
                    <th style='text-align:center'> সরবরাহকারীর বিআইএন নম্বর </th>
                    <th style='text-align:center'> সরবরাহকারীর নাম </th>
                    <th style='text-align:center'> সরবরাহকারীর ঠিকানা </th>
                    <th style='text-align:center'> মূল্য </th>
                    <th style='text-align:center'> কর্তিত মূল্য সংযোজন কর </th>
                    <th style='text-align:center'> ইনভয়েস/ চালান / বিল নম্বর </th>
                    <th style='text-align:center'> ইনভয়েস/ চালান / বিল তারিখ </th>
                    <th style='text-align:center'> উৎসে কর কর্তন সনদপত্র নং </th>
                    <th style='text-align:center'> উৎসে কর কর্তন জারির তারিখ </th>
                    <th style='text-align:center'> একাউন্ট কোড </th>
                    <th style='text-align:center'> বই স্থানান্তর ক্রমিক সংখ্যা </th>
                    <th style='text-align:center'> কর জমা দেওয়ার তারিখ </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";



            int rowCountD = 1;
            double subformD_Total_Value = 0.00;
            double subformD_Total_VAT = 0.00;

            iSetMain.ReportName = "Subform-D";
            DataTable dtSubformD = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformD.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformD.Rows)
                {
                    string dlYear = "", CertificateNo = "";
                    if (!string.IsNullOrEmpty(dr["CertificateDate"].ToString()))
                    {
                        dlYear = dr["CertificateDate"].ToString().Substring(8, 2);
                    }
                    if (!string.IsNullOrEmpty(dlYear))
                    {
                        CertificateNo = dlYear + "-CF-" + Convert.ToDouble(dr["CertificateNo"]).ToString("000000");
                    }
                    tblSubFormD = tblSubFormD + "<tr><td>" + rowCountD +
                        "</td><td>" + dr["NID"] +
                        "</td><td>" + dr["SupplierName"] +
                        "</td><td>" + dr["Address"] +
                        "</td><td style='text-align:right'>" + dr["TotalAmount"] +
                        "</td><td  style='text-align:right'>" + dr["TotalVDS"] +
                        "</td><td>" + dr["InvoiceNo"] + "</td><td>" + dr["InvoiceDate"] +
                        "</td><td>" + CertificateNo +
                        "</td><td>" + dr["CertificateDate"] +
                        "</td><td>" + dr["AccountCode"] + "</td><td> </td><td> </td><td> </td></tr>";
                    rowCountD += 1;
                    subformD_Total_VAT += Convert.ToDouble(dr["TotalVDS"]);
                }
            }
            tblSubFormD = tblSubFormD + @" <tr>
                    <th style='text-align:right' colspan='5'> মোট </th>
                    <th style='text-align:right'> " + subformD_Total_VAT.ToString("0.000") + @" </th>
                    <th style='text-align:right' colspan='8'> </th>
                </tr>
            </table>
        </div>
    </div>";

            string tblSubFormE = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='14' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম - ঙ ( নোট ২৯ - 'প্রদত্ত সরবরাহ হইতে উৎসে কর্তনের জন্য' এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> ক্রমিক সংখ্যা </th>
                    <th style='text-align:center'> ক্রেতার বিআইএন নম্বর </th>
                    <th style='text-align:center'> ক্রেতার নাম </th>
                    <th style='text-align:center'> ক্রেতার ঠিকানা </th>
                    <th style='text-align:center'> মূল্য </th>
                    <th style='text-align:center'> কর্তিত মূল্য সংযোজন কর </th>
                    <th style='text-align:center'> ইনভয়েস/ চালান / বিল নম্বর </th>
                    <th style='text-align:center'> ইনভয়েস/ চালান / বিল তারিখ </th>
                    <th style='text-align:center'> উৎসে কর কর্তন সনদপত্র নং </th>
                    <th style='text-align:center'> উৎসে কর কর্তন জারির তারিখ </th>
                    <th style='text-align:center'> একাউন্ট কোড </th>
                    <th style='text-align:center'> বই স্থানান্তর ক্রমিক সংখ্যা </th>
                    <th style='text-align:center'> কর জমা দেওয়ার তারিখ </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";

            int rowCountE = 1;
            double subformE_Total_VAT = 0.00;
            iSetMain.ReportName = "Subform-E";
            DataTable dtSubformE = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformE.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformE.Rows)
                {

                    tblSubFormE = tblSubFormE + "<tr><td>" + rowCountE +
                        "</td><td>" + dr["NIDNum"] +
                        "</td><td>" + dr["CustomerName"] +
                        "</td><td>" + dr["Address"] +
                        "</td><td style='text-align:right'>" + dr["TotalAmount"] +
                        "</td><td  style='text-align:right'>" + dr["TotalVDS"] +
                        "</td><td>" + dr["InvoiceNo"] + "</td><td>" + dr["InvoiceDate"] +
                        "</td><td>" + dr["CertificateNo"] +
                        "</td><td>" + dr["CertificateDate"] +
                        "</td><td>" + dr["AccountCode"] + "</td><td> </td><td> </td><td> </td></tr>";
                    rowCountE += 1;
                    subformE_Total_VAT += Convert.ToDouble(dr["TotalVDS"]);
                }
            }
            tblSubFormE = tblSubFormE + @" <tr>
                    <th style='text-align:right' colspan='5'> মোট </th>
                    <th style='text-align:right'> " + subformE_Total_VAT.ToString("0.000") + @" </th>
                    <th style='text-align:right' colspan='8'> </th>
                </tr>
            </table>
        </div>
    </div>";

            string tblSubFormF = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='6' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম - চ ( নোট ৩০ - 'আমদানি পর্যায়ে প্রদেয় আগাম কর' এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> ক্রমিক সংখ্যা </th>
                    <th style='text-align:center'> বিল অব এন্ট্রি নম্বর </th>
                    <th style='text-align:center'> তারিখ </th>
                    <th style='text-align:center'> শুল্ক স্টেশন </th>
                    <th style='text-align:center'> এটির পরিমাণ </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";

            int rowCountF = 1;
            double subformF_Total_AT = 0.00;
            iSetMain.ReportName = "Subform-F";
            DataTable dtSubformF = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformF.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformF.Rows)
                {
                    tblSubFormF = tblSubFormF + "<tr><td>" + rowCountF +
                        "</td><td>" + dr["BOENo"] +
                        "</td><td>" + dr["BOEDate"] +
                        "</td><td>" + dr["StationName"] +
                        "</td><td style='text-align:right'>" + dr["ATAmount"] +
                        "</td><td>" + dr["Notes"] +
                        "</td></tr>";
                    rowCountF += 1;
                    subformF_Total_AT += Convert.ToDouble(dr["ATAmount"]);
                }
            }
            tblSubFormF = tblSubFormF + @" <tr>
                    <th style='text-align:right' colspan='4'> মোট </th>
                    <th style='text-align:right'> " + subformF_Total_AT.ToString("0.000") + @" </th>
                    <th style='text-align:right'> </th>
                </tr>
            </table>
        </div>
    </div>";


            string tblSubFormG = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='5' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম - ছ ( নোট ৫৮,৫৯,৬০,৬১,৬২,৬৩ এবং ৬৪ এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> চালান নম্বর </th>
                    <th style='text-align:center'> তারিখ </th>
                    <th style='text-align:center'> একাউন্ট কোড </th>
                    <th style='text-align:center'> পরিমাণ </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";
            int rowCountG = 1;
            double subformG_Total_Amnt = 0.00;
            iSetMain.ReportName = "Subform-G";
            DataTable dtSubformG = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformG.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformG.Rows)
                {
                    tblSubFormG = tblSubFormG + "<tr>" +
                        "<td>" + dr["ChallanNo"] +
                        "</td><td>" + dr["ChallanDate"] +
                        "</td><td>" + dr["AccountNo"] +
                        "</td><td style='text-align:right'>" + dr["TreasuryAmnt"] +
                        "</td><td></td></tr>";
                    rowCountG += 1;
                    subformG_Total_Amnt += Convert.ToDouble(dr["TreasuryAmnt"]);
                }
            }

            tblSubFormG = tblSubFormG + @"<tr>
                    <th style='text-align:right' colspan='3'> মোট </th>
                    <th style='text-align:right'> " + subformG_Total_Amnt.ToString("0.00") + @" </th>
                    <th style='text-align:right'> </th>
                </tr></table></div></div>";
            #endregion

            //Sub Parts
            ViewBag.PartTwo = tblPartTwo;
            ViewBag.PartThree = tblPartThree;
            ViewBag.PartFour = tblPartFour;
            ViewBag.PartFive = tblPartFive;
            ViewBag.PartSix = tblPartSix;
            ViewBag.PartSeven = tblPartSeven;
            ViewBag.PartEight = tblPartEight;
            ViewBag.PartNine = tblPartNine;
            ViewBag.PartTen_Eleven = tblPart_10_11;

            //Sub Forms
            ViewBag.SubFormA = tblSubFormA;
            ViewBag.SubFormD = tblSubFormD;
            ViewBag.SubFormE = tblSubFormE;
            ViewBag.SubFormF = tblSubFormF;
            ViewBag.SubFormG = tblSubFormG;



            return View(iSetMain);

        }

        //GetSubFormADataByNote
        //[HttpPost]
        public JsonResult GetSubFormADataByNote(string note = "", string retMonth = "")
        {
            int rowCount = 1;
            string tblSubFormA = @"
                <div class='uk-width-medium-1-1'>
                    <table id='tablePart3'>
                        <tr>
                            <td colspan='7' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম </b></td>
                        </tr>
                        <tr>
                            <th style='text-align:center'> পণ্য/সেবার বর্ণনা </th>
                            <th style='text-align:center'> পণ্য/সেবার কোড </th>
                            <th style='text-align:center'> পণ্য/সেবার নাম </th>
                            <th style='text-align:center'> মূল্য (ক) </th>
                            <th style='text-align:center'> সম্পূরক শুল্ক (খ) </th>
                            <th style='text-align:center'> মূল্য সংযোজন কর (গ) </th>
                            <th style='text-align:center'> মন্তব্য </th>
                        </tr>";

            VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
            iSetMain.ReportName = "Subform-A";
            iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(retMonth);
            iSetMain.NoteNo = note;
            DataTable dtSubformA = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformA.Rows.Count > 0)
            {
                tblSubFormA = tblSubFormA + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformA.Rows[0]["NoteNoBangla"] + @" - " + dtSubformA.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                rowCount = 1;
                foreach (DataRow dr in dtSubformA.Rows)
                {
                    tblSubFormA = tblSubFormA + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> " + dr["VAT_Category"] + @" </td>
                            </tr>";
                    rowCount += 1;
                }
            }

            double subformA_Total_Value = 0.00;
            double subformA_Total_SD = 0.00;
            double subformA_Total_VAT = 0.00;

            if (dtSubformA.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformA.Rows)
                {
                    subformA_Total_Value += Convert.ToDouble(dr["TotalPrice"]);
                    subformA_Total_SD += Convert.ToDouble(dr["SD"]);
                    subformA_Total_VAT += Convert.ToDouble(dr["VatAmnt"]);
                }
            }

            tblSubFormA += @"<tr>
                            <th colspan='3' style='text-align:right'> মোট </th>
                            <th style='text-align:center'> " + subformA_Total_Value.ToString("0.000") + @" </th>
                            <th style='text-align:center'> " + subformA_Total_SD.ToString("0.000") + @" </th>
                            <th style='text-align:center'> " + subformA_Total_VAT.ToString("0.000") + @" </th>
                            <th style='text-align:center'> - </th>
                        </tr>
                    </table>
                </div>";

            return Json(tblSubFormA);
        }

        public JsonResult GetSubFormDDataByNote(string note = "", string retMonth = "")
        {
            int rowCountD = 1;
            int rowCount = 1;
            double subformD_Total_Value = 0.00;
            double subformD_Total_VAT = 0.00;
            string tblSubFormD = @"
                <div class='uk-width-medium-1-1'>
                    <table id='tablePart3'>
                        <tr>
                            <td colspan='7' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম </b></td>
                        </tr>
                        <tr>
                            <th style='text-align:center'> পণ্য/সেবার বর্ণনা </th>
                            <th style='text-align:center'> পণ্য/সেবার কোড </th>
                            <th style='text-align:center'> পণ্য/সেবার নাম </th>
                            <th style='text-align:center'> মূল্য (ক) </th>
                            <th style='text-align:center'> সম্পূরক শুল্ক (খ) </th>
                            <th style='text-align:center'> মূল্য সংযোজন কর (গ) </th>
                            <th style='text-align:center'> মন্তব্য </th>
                        </tr>";

            VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
            iSetMain.ReportName = "Subform-D";
            iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(retMonth);
            iSetMain.NoteNo = note;
            DataTable dtSubformD = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformD.Rows.Count > 0)
            {

                //foreach (DataRow dr in dtSubformA.Rows)
                //{
                //    tblSubFormA = tblSubFormA + @"<tr>
                //                <td style='text-align:left'> " + dr["Description"] + @" </td>
                //                <td style='text-align:center'> " + dr["Code"] + @" </td>
                //                <td style='text-align:center'> " + dr["PName"] + @" </td>
                //                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                //                <td style='text-align:center'> " + dr["SD"] + @" </td>
                //                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                //                <td style='text-align:center'> " + dr["VAT_Category"] + @" </td>
                //            </tr>";
                //    rowCount += 1;
                //}

                tblSubFormD = tblSubFormD + @"<tr>
                            <td colspan='7' style='text-align:left;'><b> নোট " + dtSubformD.Rows[0]["NoteNoBangla"] + @" - " + dtSubformD.Rows[0]["NoteNameBangla"] + @" </b></td>
                            </tr>";
                rowCount = 1;

                foreach (DataRow dr in dtSubformD.Rows)
                {
                    //string dlYear = "", CertificateNo = "";
                    //if (!string.IsNullOrEmpty(dr["CertificateDate"].ToString()))
                    //{
                    //    dlYear = dr["CertificateDate"].ToString().Substring(8, 2);
                    //}
                    //if (!string.IsNullOrEmpty(dlYear))
                    //{
                    //    CertificateNo = dlYear + "-CF-" + Convert.ToDouble(dr["CertificateNo"]).ToString("000000");
                    //}

                    tblSubFormD = tblSubFormD + @"<tr>
                                <td style='text-align:left'> " + dr["Description"] + @" </td>
                                <td style='text-align:center'> " + dr["Code"] + @" </td>
                                <td style='text-align:center'> " + dr["PName"] + @" </td>
                                <td style='text-align:center'> " + dr["TotalPrice"] + @" </td>
                                <td style='text-align:center'> " + dr["SD"] + @" </td>
                                <td style='text-align:center'> " + dr["VatAmnt"] + @" </td>
                                <td style='text-align:center'> " + dr["VAT_Category"] + @" </td>
                            </tr>";
                    rowCount += 1;
                }
            }

            double subformA_Total_Value = 0.00;
            double subformA_Total_SD = 0.00;
            double subformA_Total_VAT = 0.00;

            if (dtSubformD.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformD.Rows)
                {
                    subformA_Total_Value += Convert.ToDouble(dr["TotalPrice"]);
                    subformA_Total_SD += Convert.ToDouble(dr["SD"]);
                    subformA_Total_VAT += Convert.ToDouble(dr["VatAmnt"]);
                }
            }

            tblSubFormD += @"<tr>
                            <th colspan='3' style='text-align:right'> মোট </th>
                            <th style='text-align:center'> " + subformA_Total_Value.ToString("0.000") + @" </th>
                            <th style='text-align:center'> " + subformA_Total_SD.ToString("0.000") + @" </th>
                            <th style='text-align:center'> " + subformA_Total_VAT.ToString("0.000") + @" </th>
                            <th style='text-align:center'> - </th>
                        </tr>
                    </table>
                </div>";

            return Json(tblSubFormD);

            //    tblSubFormD = tblSubFormD + @" <tr>
            //            <th style='text-align:right' colspan='5'> মোট </th>
            //            <th style='text-align:right'> " + subformD_Total_VAT.ToString("0.000") + @" </th>
            //            <th style='text-align:right' colspan='8'> </th>
            //        </tr>
            //    </table>
            //</div>";

            return Json(tblSubFormD);
        }

        public JsonResult GetSubFormFDataByNote(string note = "", string retMonth = "")
        {
            int rowCountF = 1;
            double subformF_Total_VAT = 0.00;
            string tblSubFormF = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='6' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম - চ ( নোট ৩০ - 'আমদানি পর্যায়ে প্রদেয় আগাম কর' এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> ক্রমিক সংখ্যা </th>
                    <th style='text-align:center'> বিল অব এন্ট্রি নম্বর </th>
                    <th style='text-align:center'> তারিখ </th>
                    <th style='text-align:center'> শুল্ক স্টেশন </th>
                    <th style='text-align:center'> এটির পরিমাণ </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";
            VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
            iSetMain.ReportName = "Subform-F";
            iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(retMonth);
            iSetMain.NoteNo = note;
            DataTable dtSubformF = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformF.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformF.Rows)
                {
                    tblSubFormF = tblSubFormF + "<tr><td>" + rowCountF +
                        "</td><td>" + dr["BOENo"] +
                        "</td><td>" + dr["BOEDate"] +
                        "</td><td>" + dr["StationName"] +
                        "</td><td style='text-align:right'>" + dr["ATAmount"] +
                        "</td><td>" + dr["Notes"] +
                        "</td></tr>";
                    rowCountF += 1;
                    subformF_Total_VAT += Convert.ToDouble(dr["ATAmount"]);
                }
            }

            tblSubFormF = tblSubFormF + @" <tr>
                    <th style='text-align:right' colspan='4'> মোট </th>
                    <th style='text-align:right'> " + subformF_Total_VAT.ToString("0.000") + @" </th>
                    <th style='text-align:right'> </th>
                </tr>
            </table>
        </div>
    </div>";

            return Json(tblSubFormF);
        }


        public JsonResult GetSubFormGDataByNote(string note = "", string retMonth = "")
        {
            int rowCountG = 1;
            double subformG_Total_Amnt = 0.00;
            string tblSubFormG = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
        <div class='uk-width-medium-1-1'>
            <table id='tablePart3'>
                <tr>
                    <td colspan='5' height='50' style='text-align:left;background-color:#FAD7A0;'><b> সাবফর্ম - ছ ( নোট ৫৮,৫৯,৬০,৬১,৬২,৬৩ এবং ৬৪ এর জন্য প্রযোজ্য ) </b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> চালান নম্বর </th>
                    <th style='text-align:center'> তারিখ </th>
                    <th style='text-align:center'> একাউন্ট কোড </th>
                    <th style='text-align:center'> পরিমাণ </th>
                    <th style='text-align:center'> মন্তব্য </th>
                </tr>";
            VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
            iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
            iSetMain.EndDate = getEndDateForReturn(retMonth);
            //iSetMain.NoteNo = note;
            iSetMain.ReportName = "Subform-G";
            DataTable dtSubformG = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
            if (dtSubformG.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSubformG.Rows)
                {
                    tblSubFormG = tblSubFormG + "<tr>" +
                        "<td>" + dr["ChallanNo"] +
                        "</td><td>" + dr["ChallanDate"] +
                        "</td><td>" + dr["AccountNo"] +
                        "</td><td style='text-align:right'>" + dr["TreasuryAmnt"] +
                        "</td><td></td></tr>";
                    rowCountG += 1;
                    subformG_Total_Amnt += Convert.ToDouble(dr["TreasuryAmnt"]);
                }
            }

            tblSubFormG = tblSubFormG + @"<tr>
                    <th style='text-align:right' colspan='3'> মোট </th>
                    <th style='text-align:right'> " + subformG_Total_Amnt.ToString("0.00") + @" </th>
                    <th style='text-align:right'> </th>
                </tr></table></div></div>";

            return Json(tblSubFormG);
        }

        public JsonResult GetBreakdownofNote_27ByMonth(string note, string retMonth)
        {
            try
            {
                int rowCountG = 1;
                double DetN27_Total_Amnt = 0.00;

                VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
                iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
                iSetMain.EndDate = getEndDateForReturn(retMonth);
                iSetMain.ReportName = "SubformForN27";

                DataTable dtSubformG1 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                DataView view = new DataView(dtSubformG1);
                DataTable distinctValues = view.ToTable(true, "Sales_Product_Name", "BOMName", "Sales_HS_Code", "Sales_Unit_Name", "Sales_Quantity");

                var Sales_Product_Name = distinctValues.Rows[0]["Sales_Product_Name"].ToString()
                    + " (" + distinctValues.Rows[0]["Sales_HS_Code"].ToString() + ") : "
                    + distinctValues.Rows[0]["Sales_Quantity"].ToString() + " "
                    + distinctValues.Rows[0]["Sales_Unit_Name"].ToString() + " ";

                string tblSubFormN27 = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
                <div class='uk-width-medium-1-1'>
                <table id='tablePart3'>
                <tr>
                    <td colspan='9' height='50' style='text-align:left;background-color:#FAD7A0;'>
                    <b> রেয়াত সমন্বয় : " + Sales_Product_Name + "";

                tblSubFormN27 += @"</b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> SL </th>
                    <th style='text-align:center'> Raw Material Name </th>
                    <th style='text-align:center'> UOM </th>
                    <th style='text-align:center'> Raw Material Required Qnty / Unit </th>
                    <th style='text-align:center'> Raw Material Unit Price </th>
                    <th style='text-align:center'> Raw Material Purchase Amount </th>
                    <th style='text-align:center'> Raw Material VAT Amount / Unit </th>
                    <th style='text-align:center'> Raw Material Total Consumption Qnty </th>
                    <th style='text-align:center'> Raw Material Total VAT Amount </th>
                </tr>";
                //VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
                //iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
                //iSetMain.EndDate = getEndDateForReturn(retMonth);
                //iSetMain.NoteNo = note;
                iSetMain.ReportName = "SubformForN27";
                DataTable dtSubformG = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                if (dtSubformG.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubformG.Rows)
                    {
                        tblSubFormN27 = tblSubFormN27 +
                            "<tr>" +
                            "<td>" + rowCountG + "</td>" +
                            "<td>" + dr["Raw_Product_Name"].ToString() + "</td>" +
                            "<td>" + dr["Raw_Unit_Name"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Total_Qnty"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Purchase_Unit_Price"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Purchase_Total_Amount"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_CVAT"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Total_Consumption_Qnty"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Total_Calculated_VAT_Amount"].ToString() + "</td>" +
                            "</tr>";
                        rowCountG += 1;
                        var TCVAT = Convert.ToDouble(dr["Total_Calculated_VAT_Amount"].ToString()).ToString("0.00");
                        DetN27_Total_Amnt += Convert.ToDouble(TCVAT);
                    }
                }

                tblSubFormN27 = tblSubFormN27 + @"<tr>
                    <th style='text-align:right' colspan='8'> মোট </th>
                    <th style='text-align:right'> " + DetN27_Total_Amnt.ToString("0.00") + @" </th>
                </tr></table></div></div>";

                return Json(tblSubFormN27);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }

        }

        public JsonResult GetBreakdownofNote_32ByMonth(string note, string retMonth)
        {
            try
            {
                int rowCountG = 1;
                double DetN27_Total_Amnt = 0.0000;

                VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
                iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
                iSetMain.EndDate = getEndDateForReturn(retMonth);
                iSetMain.ReportName = "SubformForN32";

                DataTable dtSubformG1 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                DataView view = new DataView(dtSubformG1);
                DataTable distinctValues = view.ToTable(true, "Sales_Product_Name", "BOMName", "Sales_HS_Code", "Sales_Unit_Name", "Sales_Quantity");
                var Sales_Product_Name = distinctValues.Rows[0]["Sales_Product_Name"].ToString()
                    + " (" + distinctValues.Rows[0]["Sales_HS_Code"].ToString() + ") : "
                    + distinctValues.Rows[0]["Sales_Quantity"].ToString() + " "
                    + distinctValues.Rows[0]["Sales_Unit_Name"].ToString() + " ";

                string tblSubFormN27 = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
                <div class='uk-width-medium-1-1'>
                <table id='tablePart3'>
                <tr>
                    <td colspan='9' height='50' style='text-align:left;background-color:#FAD7A0;'>
                    <b> রেয়াত সমন্বয় : " + Sales_Product_Name + "";

                tblSubFormN27 += @"</b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> SL </th>
                    <th style='text-align:center'> Raw Material Name </th>
                    <th style='text-align:center'> UOM </th>
                    <th style='text-align:center'> Raw Material Required Qnty / Unit </th>
                    <th style='text-align:center'> Raw Material Unit Price </th>
                    <th style='text-align:center'> Raw Material Purchase Amount </th>
                    <th style='text-align:center'> Raw Material VAT Amount / Unit </th>
                    <th style='text-align:center'> Raw Material Total Consumption Qnty </th>
                    <th style='text-align:center'> Raw Material Total VAT Amount </th>
                </tr>";

                //VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
                //iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
                //iSetMain.EndDate = getEndDateForReturn(retMonth);
                //iSetMain.NoteNo = note;
                iSetMain.ReportName = "SubformForN32";
                DataTable dtSubformG = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                if (dtSubformG.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubformG.Rows)
                    {
                        tblSubFormN27 = tblSubFormN27 +
                            "<tr>" +
                            "<td>" + rowCountG + "</td>" +
                            "<td>" + dr["Raw_Product_Name"].ToString() + "</td>" +
                            "<td>" + dr["Raw_Unit_Name"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Total_Qnty"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Purchase_Unit_Price"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Purchase_Total_Amount"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_CVAT"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Total_Consumption_Qnty"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Total_Calculated_VAT_Amount"].ToString() + "</td>" +
                            "</tr>";
                        rowCountG += 1;
                        //var TCVAT = Convert.ToDouble(dr["Total_Calculated_VAT_Amount"].ToString()).ToString("0.00");
                        //DetN27_Total_Amnt += Convert.ToDouble(TCVAT));

                        var TCVAT = Convert.ToDouble(dr["Total_Calculated_VAT_Amount"].ToString()).ToString("0.00");
                        DetN27_Total_Amnt += Convert.ToDouble(TCVAT);
                    }
                }

                tblSubFormN27 = tblSubFormN27 + @"<tr>
                    <th style='text-align:right' colspan='8'> মোট </th>
                    <th style='text-align:right'> " + DetN27_Total_Amnt.ToString("0.0000") + @" </th>
                </tr></table></div></div>";

                //tblSubFormN27 = tblSubFormN27 + @"<tr>
                //    <th style='text-align:right' colspan='5'> মোট </th>
                //    <th style='text-align:right'> " + DetN27_Total_Amnt.ToString("0.00") + @" </th>
                //</tr></table></div></div>";

                return Json(tblSubFormN27);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }

        }
        public JsonResult GetBreakdownofNote_40ByMonth(string note, string retMonth)
        {
            try
            {
                int rowCountG = 1;
                double DetN40_Total_Amnt = 0.0000;

                VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
                iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
                iSetMain.EndDate = getEndDateForReturn(retMonth);
                iSetMain.ReportName = "SubformForN40";

                DataTable dtSubformG1 = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                DataView view = new DataView(dtSubformG1);
                DataTable distinctValues = view.ToTable(true, "Sales_Product_Name", "BOMName", "Sales_HS_Code", "Sales_Unit_Name", "Sales_Quantity");
                var Sales_Product_Name = distinctValues.Rows[0]["Sales_Product_Name"].ToString()
                    + " (" + distinctValues.Rows[0]["Sales_HS_Code"].ToString() + ") : "
                    + distinctValues.Rows[0]["Sales_Quantity"].ToString() + " "
                    + distinctValues.Rows[0]["Sales_Unit_Name"].ToString() + " ";

                string tblSubFormN27 = @"<div class='uk-grid' data-uk-grid-margin style='width: 100%; margin: 0 auto; margin-top:20px;'>
                <div class='uk-width-medium-1-1'>
                <table id='tablePart3'>
                <tr>
                    <td colspan='9' height='50' style='text-align:left;background-color:#FAD7A0;'>
                    <b> রেয়াত সমন্বয় : " + Sales_Product_Name + "";

                tblSubFormN27 += @"</b></td>
                </tr>
                <tr>
                    <th style='text-align:center'> SL </th>
                    <th style='text-align:center'> Raw Material Name </th>
                    <th style='text-align:center'> UOM </th>
                    <th style='text-align:center'> Raw Material Required Qnty / Unit </th>
                    <th style='text-align:center'> Raw Material Unit Price </th>
                    <th style='text-align:center'> Raw Material Purchase Amount </th>
                    <th style='text-align:center'> Raw Material SD Amount / Unit </th>
                    <th style='text-align:center'> Raw Material Total Consumption Qnty </th>
                    <th style='text-align:center'> Raw Material Total SD Amount </th>
                </tr>";

                //VatReturnsubmissionEntity iSetMain = new VatReturnsubmissionEntity();
                //iSetMain.StartDate = "01/" + retMonth.Substring(3, 7);
                //iSetMain.EndDate = getEndDateForReturn(retMonth);
                //iSetMain.NoteNo = note;
                iSetMain.ReportName = "SubformForN40";
                DataTable dtSubformG = (DataTable)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetAllVatReturnsubmissionRecord, iSetMain);
                if (dtSubformG.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtSubformG.Rows)
                    {
                        tblSubFormN27 = tblSubFormN27 +
                            "<tr>" +
                            "<td>" + rowCountG + "</td>" +
                            "<td>" + dr["Raw_Product_Name"].ToString() + "</td>" +
                            "<td>" + dr["Raw_Unit_Name"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Total_Qnty"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Purchase_Unit_Price"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Purchase_Total_Amount"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_CSD"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Raw_Total_Consumption_Qnty"].ToString() + "</td>" +
                            "<td style='text-align:right'>" + dr["Total_Calculated_SD_Amount"].ToString() + "</td>" +
                            "</tr>";
                        rowCountG += 1;
                        var TCSA = Convert.ToDouble(dr["Total_Calculated_SD_Amount"].ToString()).ToString("0.0000");
                        DetN40_Total_Amnt += Convert.ToDouble(TCSA);
                    }
                }

                tblSubFormN27 = tblSubFormN27 + @"<tr>
                    <th style='text-align:right' colspan='8'> মোট </th>
                    <th style='text-align:right'> " + DetN40_Total_Amnt.ToString("0.0000") + @" </th>
                </tr></table></div></div>";

                //tblSubFormN27 = tblSubFormN27 + @"<tr>
                //    <th style='text-align:right' colspan='5'> মোট </th>
                //    <th style='text-align:right'> " + DetN27_Total_Amnt.ToString("0.00") + @" </th>
                //</tr></table></div></div>";

                return Json(tblSubFormN27);
            }
            catch (Exception ex)
            {
                return Json(ex.Message.ToString());
            }

        }
        #endregion

        #region Mushak 6.2 : Sales Register
        public ActionResult SalesRegister()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }
            M_GetModuleWiseTabList(Module.Mushak, "Reports", "SalesRegister");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.2 : Sales Register";
            Session["PageHeader"] = "Mushak 6.2 : Sales Register";
            ViewData["IsReturn"] = GetIsActiveList_();
            SfInvoicemasterEntity iSet = new SfInvoicemasterEntity
            {
                StartDate = DateTime.Now.ToString("01/MM/yyyy"),
                EndDate = DateTime.Now.ToString("dd/MM/yyyy")
            };
            //ViewData["CustomerList"] = objOp.GetCustomerlist();
            //ViewData["ItemsList"] = objInv.GetItemslist();
            ViewData["ProductLists"] = objInv.GetItemslist("2");
            return View(iSet);
        }

        //GetSaleRegisterDataList --ReportName = "Sale"
        public JsonResult GetSaleRegisterDataList(string StartDate = "", string EndDate = "", string ProductId = "")
        {
            InvStockmasterEntity objGet = new InvStockmasterEntity();
            objGet.ReceivedateSearch = StartDate;
            objGet.EndDate = EndDate;
            objGet.Productid = ProductId;
            objGet.ReportName = "Sale";
            DataTable dt = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, objGet);

            string TableData = "";
            int iCount = 1;

            foreach (DataRow dr in dt.Rows)
            {

                TableData = TableData + "<tr>"

                      //+ "<td><i onclick=\"GoToReportView('" + dr["Id"] + "');\" class='md-24 material-icons md-color-green-500' title='View Report'>&#XE85D;</i></td>"
                      + "<td>" + iCount + "</td>"
                      + "<td>" + dr["InvoiceNo"] + "</td>"
                      + "<td>" + dr["InvoiceDate"] + "</td>"
                      + "<td>" + dr["CustomerName"] + "</td>"
                      + "<td>" + GetProductHsCodeById(dr["ProductId"].ToString()) + "</td>"
                      + "<td>" + dr["Quantity"] + "</td>"
                      + "<td>" + dr["UnitPrice"] + "</td>"
                      + "<td>" + dr["TotalPrice"] + "</td>"
                      + "</tr>";

                iCount = iCount + 1;
            }

            string tHead = "";

            tHead = "<tr>" +
                "   <th>SL</th>" +
                    "<th>Invoice No</th>" +
                    "<th>Invoice Date</th" +
                    "><th>Customer Name</th>" +
                    "<th>Product Name</th>" +
                    "<th>Sales Quantity</th>" +
                    "<th>Sales Unit Price</th>" +
                    "<th>Sales Total Price</th>" +
                    "</tr>";


            TableData =
                "<div class='rk_dtButton2'></div>" +
                "<table id='rk_dtInfo2' class='uk-table uk-table-hover uk-table-condensed' cellspacing='0' width='100%'>" +
                "<thead class='md-bg-blue-grey-100'>" + tHead + "</thead>" +
                "<tfoot style='display:none;'>" + tHead + "</tfoot>" +
                "<tbody>" + TableData + "</tbody>" +
                "</table>";

            return Json(TableData, JsonRequestBehavior.AllowGet);

        }

        public ActionResult RptSalesRegister_6_2(string StartDate = "", string EndDate = "", string ProductId = "")
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "../Home");
            }

            M_GetModuleWiseTabList(Module.Mushak, "Reports", "SalesRegister");
            ViewBag.PageModule = "Mushak"; ViewBag.PageModuleName = "Mushak"; ViewBag.PageHeader = "Mushak 6.2 : Sales Register";
            Session["PageHeader"] = "Mushak 6.2 : Sales Register";
            string TableData = "";

            TableData += @"<form id='InputForm' action='' style='margin: 0 auto;'>
                <div class='uk-grid' data-uk-grid-margin style='width: 90%; margin: 0 auto;'>
                <div class='uk-width-medium-1-2' style='width: 100%; margin: 0 auto; text-align: center;'>
                <h6>গণপ্রজাতন্ত্রী বাংলাদেশ সরকার</h6>
                <h6>জাতীয় রাজস্ব বোর্ড</h6>
                <h6>
                    <b>Pakiza Technovation Limited, House # 52/A, Road # 09-A, Dhanmondi, Dhaka-1205, Bangladesh, 00086861616-0306</b>
                    <span style='border:1px solid;padding:5px;float:right;'><sup>১</sup><b>[ মূসক-৬.২ </b></span>
                </h6>
                <h6><b> বিক্রয় হিসাব পুস্তক </b></h6>
                <h6>(পণ্য বা সেবা প্রক্রিয়াকরণে সম্পৃক্ত এমন নিবন্ধিত বা তালিকাভুক্ত ব্যক্তির জন্য প্রযোজ্য)</h6>
                <h6>[ বিধি ৪০ এর উপ-বিধি (১) এর দফা (খ) ও বিধি ৪১ এর দফা (ক) দ্রষ্টব্য ]</h6>
                </div>
                </div>


                 <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:30px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>    
                <p style='font-size:14px;font-weight:bold;'>" + GetProductHsCodeById(ProductId) + @"</p>
                </div>
                </div>


                <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:10px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                <table id='tableMain'>
                <tr>
                    <td colspan='21'>পণ্য/সেবার উপকরণ ক্রয় </td>
                </tr>
                <tr>
                    <td rowspan='2'> ক্রমিক সংখ্যা </td>
                    <td rowspan='2'> তারিখ </td>
                    <td colspan='2'> উৎপাদিত পণ্য/সেবার প্রারম্ভিক জের </td>
                    <td colspan='2'> উৎপাদন </td>
                    <td colspan='2'> মোট উৎপাদিত পণ্য/সেবা </td>
                    <td colspan='3'> ক্রেতা/সরবরাহগ্রহীতা </td>
                    <td colspan='2'> চালানপত্রের বিবরণ </td>
                    <td colspan='5'> বিক্রিত/সরবরাহকৃত পণ্যের বিবরণ </td>
                    <td colspan='2'> পণ্যের প্রান্তিক জের </td>
                    <td rowspan='2'> মন্তব্য </td>
                </tr>
                <tr>
                    <td> পরিমাণ (একক) </td>
                    <td> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                    <td> পরিমাণ (একক) </td>
                    <td> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                    <td> পরিমাণ (একক) </td>
                    <td> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                    <td> নাম </td>
                    <td> ঠিকানা </td>
                    <td> নিবন্ধন/তালিকাভুক্তি/জাতীয় পরিচয়পত্র নং </td>
                    <td> নম্বর </td>
                    <td> তারিখ </td>
                    <td> বিবরণ </td>
                    <td> পরিমাণ </td>
                    <td> করযোগ্য মূল্য </td>
                    <td> সম্পূরক শুল্ক (যদি থাকে) </td>
                    <td> মূসক </td>
                    <td> পরিমাণ (একক) </td>
                    <td> মূল্য (সকল প্রকার কর ব্যতীত) </td>
                </tr>
                <tr>
                    <td>(১)</td>
                    <td>(২)</td>
                    <td>(৩)</td>
                    <td>(৪)</td>
                    <td>(৫)</td>
                    <td>(৬)</td>
                    <td>(৭)=৩+৫</td>
                    <td>(৮)=৪+৬</td>
                    <td>(৯)</td>
                    <td>(১০)</td>
                    <td>(১১)</td>
                    <td>(১২)</td>
                    <td>(১৩)</td>
                    <td>(১৪)</td>
                    <td>(১৫)</td>
                    <td>(১৬)</td>
                    <td>(১৭)</td>
                    <td>(১৮)</td>
                    <td>(১৯)=(৭ - ১৫)</td>
                    <td>(২০)=(৮ - ১৬)</td>
                    <td>(২১)</td>

                </tr>";

            //<tr><td colspan='21' style='font-size:14px;font-weight:bold;text-align:left;'>" + GetProductHsCodeById(ProductId) + "</td></tr>";
            double dlCurrentProdQty = 0.00;
            double dlCurrentProdAmnt = 0.00;

            //double dlTotalProdQty = 0.00;
            //double dlTotalProdAmnt = 0.00;

            double dlSalesQty = 0.00;
            double dlSalesAmnt = 0.00;
            double dlSalesSdAmnt = 0.00;
            double dlSalesVatAmnt = 0.00;

            if (!string.IsNullOrEmpty(StartDate) && !string.IsNullOrEmpty(EndDate) && !string.IsNullOrEmpty(ProductId))
            {
                int iCount = 0;
                string dateStringStrt = StartDate;
                string dateStringEnd = EndDate;
                string format = "dd/MM/yyyy";
                string chlBOENo = "";
                string chlBOEDate = "";
                string sdAmntCurrent = "0.00";

                string opening_production_stock_qnty = "0.00";
                string opening_production_stock_amnt = "0.00";
                string current_production_qnty = "0.00";
                string current_production_amnt = "0.00";

                string current_sales_qnty = "0.00";
                string current_sales_amnt = "0.00";
                string current_sales_SD_amnt = "0.00";
                string current_sales_VAT_amnt = "0.00";
                string current_sales_Invoice_No = "";
                string current_sales_Invoice_Date = "";
                string current_stock_qnty = "0.00";
                string current_stock_amnt = "0.00";

                string opening_production_qnty = "0.00";
                string opening_production_amnt = "0.00";
                string opening_sales_qnty = "0.00";
                string opening_sales_amnt = "0.00";

                double sdAmnt = 0.0;
                double MushakAmnt = 0.00;
                double prodQty = 0.0;
                double closingQty = 0.0;
                double closingAmnt = 0.0;
                double total_current_production_qnty = 0.0;
                double total_current_production_amnt = 0.0;
                double total_current_production_stock_qnty = 0.0;
                double total_current_production_stock_amnt = 0.0;

                DateTime fromDate = DateTime.ParseExact(dateStringStrt, format, CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(dateStringEnd, format, CultureInfo.InvariantCulture);

                InvProductEntity iPrd = (InvProductEntity)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetSingleInvProductRecordById, ProductId);
                string Unit = iPrd.UnitName;

                InvStockmasterEntity iDet = new InvStockmasterEntity
                {
                    ReceivedateSearch = fromDate.AddDays(-1).ToString("dd/MM/yyyy"),
                    EndDate = fromDate.AddDays(-1).ToString("dd/MM/yyyy"),
                    //ReceivedateSearch = fromDate.ToString("dd/MM/yyyy"),
                    //EndDate = fromDate.ToString("dd/MM/yyyy"),
                    Productid = ProductId,
                    ReportName = "CurrentProductionStock"
                };

                DataTable dtOpeningProductionInfo = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iDet);

                if (dtOpeningProductionInfo.Rows.Count > 0)
                {
                    opening_production_stock_qnty = dtOpeningProductionInfo.Rows[0]["Current_Production_Stock_Quantity"].ToString();
                    opening_production_stock_amnt = dtOpeningProductionInfo.Rows[0]["Current_Production_Stock_Total_Price"].ToString();

                    opening_production_qnty = opening_production_stock_qnty;
                    opening_production_amnt = opening_production_stock_amnt;
                }
                else
                {
                    opening_production_stock_qnty = "0.00";
                    opening_production_stock_amnt = "0.00";

                    current_production_qnty = "0.00";
                    current_production_amnt = "0.00";

                    current_sales_qnty = "0.00";
                    current_sales_amnt = "0.00";

                    opening_production_qnty = opening_production_stock_qnty;
                    opening_production_amnt = opening_production_stock_amnt;
                }

                total_current_production_qnty = (Convert.ToDouble(opening_production_stock_qnty) + Convert.ToDouble(current_production_qnty));
                total_current_production_amnt = (Convert.ToDouble(opening_production_stock_amnt) + Convert.ToDouble(current_production_amnt));

                total_current_production_stock_qnty = (Convert.ToDouble(opening_production_stock_qnty) + Convert.ToDouble(current_production_qnty)) - Convert.ToDouble(current_sales_qnty);
                total_current_production_stock_amnt = (Convert.ToDouble(opening_production_stock_amnt) + Convert.ToDouble(current_production_amnt)) - Convert.ToDouble(current_sales_amnt);



                while (fromDate <= toDate)
                {
                    //iCount += 1;
                    /*-----------------------------------Production Data(In House)-----------------------------------------*/

                    InvProductionmasterEntity iProduction = new InvProductionmasterEntity
                    {
                        StartDate = fromDate.ToString("dd/MM/yyyy"),
                        EndDate = fromDate.ToString("dd/MM/yyyy"),
                        ProductId = ProductId,
                        ReportName = "Current_Finished_Production"
                    };

                    DataTable dtProductionInfo = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvProductionmasterRecord, iProduction);
                    if (dtProductionInfo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtProductionInfo.Rows)
                        {
                            iCount += 1;

                            opening_production_qnty = total_current_production_stock_qnty.ToString();
                            opening_production_amnt = total_current_production_stock_amnt.ToString();

                            chlBOENo = "";
                            chlBOEDate = "";

                            current_production_qnty = "0.00";
                            current_production_amnt = "0.00";
                            current_sales_qnty = "0.00";
                            current_sales_amnt = "0.00";
                            current_sales_SD_amnt = "0.00";
                            current_sales_VAT_amnt = "0.00";

                            //current_production_qnty = dr["Quantity"].ToString();
                            //current_production_amnt = (Convert.ToDouble(dr["TradePrice"]) * Convert.ToDouble(dr["Quantity"])).ToString();

                            current_production_qnty = dr["Finished_Production_Quantity"].ToString();
                            current_production_amnt = Convert.ToDouble(dr["Finished_Production_Total_Price"]).ToString();

                            total_current_production_qnty = Convert.ToDouble(opening_production_qnty) + Convert.ToDouble(current_production_qnty);
                            total_current_production_amnt = Convert.ToDouble(opening_production_amnt) + Convert.ToDouble(current_production_amnt);

                            total_current_production_stock_qnty = total_current_production_qnty;
                            total_current_production_stock_amnt = total_current_production_amnt;

                            //closingQty = total_current_production_qnty - prodQty;
                            //closingAmnt = total_current_production_amnt - prodAmnt;
                            // <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>

                            TableData += @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>

                            <td>" + Convert.ToDouble(opening_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(opening_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(total_current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(total_current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>
                            <td>" + "" + @"</td>

                            <td>" + GetProductNameById(ProductId) + @"</td>
                            <td>" + Convert.ToDouble(current_sales_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_amnt).ToString("0.00") + @"</td>
                            <td>" + Convert.ToDouble(current_sales_SD_amnt).ToString("0.00") + @"</td>
                            <td>" + Convert.ToDouble(current_sales_VAT_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(total_current_production_stock_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(total_current_production_stock_amnt).ToString("0.00") + @"</td>
                            <td> Production </td>

                        </tr>";

                            dlCurrentProdQty += Convert.ToDouble(current_production_qnty);
                            dlCurrentProdAmnt += Convert.ToDouble(current_production_amnt);
                            //dlTotalProdQty += Convert.ToDouble(total_current_production_qnty);
                            //dlTotalProdAmnt += Convert.ToDouble(total_current_production_amnt);
                            dlSalesQty += Convert.ToDouble(current_sales_qnty);
                            dlSalesAmnt += Convert.ToDouble(current_sales_amnt);
                            dlSalesSdAmnt += Convert.ToDouble(current_sales_SD_amnt);
                            dlSalesVatAmnt += Convert.ToDouble(current_sales_VAT_amnt);

                        }
                    }


                    /*-----------------------------------Sales Info-----------------------------------------*/

                    InvStockmasterEntity iBuying = new InvStockmasterEntity
                    {
                        ReceivedateSearch = fromDate.ToString("dd/MM/yyyy"),
                        EndDate = fromDate.ToString("dd/MM/yyyy"),
                        Productid = ProductId,
                        ReportName = "Sale"
                    };

                    DataTable dtSalesInfo = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, iBuying);

                    if (dtSalesInfo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtSalesInfo.Rows)
                        {
                            iCount += 1;

                            opening_production_qnty = total_current_production_stock_qnty.ToString();
                            opening_production_amnt = total_current_production_stock_amnt.ToString();

                            total_current_production_qnty = total_current_production_stock_qnty;
                            total_current_production_amnt = total_current_production_stock_amnt;

                            current_production_qnty = "0.00";
                            current_production_amnt = "0.00";

                            current_sales_qnty = dr["Quantity"].ToString();
                            current_sales_amnt = (Convert.ToDouble(dr["TotalPrice"])).ToString();
                            current_sales_SD_amnt = dr["SD"].ToString();
                            current_sales_VAT_amnt = dr["VatAmnt"].ToString();

                            current_sales_Invoice_No = dr["InvoiceNo"].ToString();
                            current_sales_Invoice_Date = dr["InvoiceDate"].ToString();

                            total_current_production_stock_qnty = total_current_production_stock_qnty - Convert.ToDouble(current_sales_qnty);
                            total_current_production_stock_amnt = total_current_production_stock_amnt - Convert.ToDouble(current_sales_amnt);

                            //total_current_production_qnty = total_current_production_stock_qnty;
                            //total_current_production_amnt = total_current_production_stock_amnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>

                            <td>" + Convert.ToDouble(opening_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(opening_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(total_current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(total_current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + dr["CustomerName"] + @"</td>
                            <td>" + dr["Customer_Address"] + @"</td>
                            <td>" + dr["TIN"] + @"</td>

                            <td>" + current_sales_Invoice_No.ToString() + @"</td>
                            <td>" + current_sales_Invoice_Date.ToString() + @"</td>

                            <td>" + GetProductNameById(dr["ProductId"].ToString()) + @"</td>
                            <td>" + Convert.ToDouble(current_sales_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_amnt).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_SD_amnt).ToString("0.00") + @"</td>
                            <td>" + Convert.ToDouble(current_sales_VAT_amnt).ToString("0.00") + @"</td>

                            <td>" + total_current_production_stock_qnty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + total_current_production_stock_amnt.ToString("0.00") + @"</td>
                            <td>" + dr["SaleType"].ToString() + @"</td>

                        </tr>";

                            //iCount += 1;

                            dlCurrentProdQty += Convert.ToDouble(current_production_qnty);
                            dlCurrentProdAmnt += Convert.ToDouble(current_production_amnt);
                            //dlTotalProdQty += Convert.ToDouble(total_current_production_qnty);
                            //dlTotalProdAmnt += Convert.ToDouble(total_current_production_amnt);
                            dlSalesQty += Convert.ToDouble(current_sales_qnty);
                            dlSalesAmnt += Convert.ToDouble(current_sales_amnt);
                            dlSalesSdAmnt += Convert.ToDouble(current_sales_SD_amnt);
                            dlSalesVatAmnt += Convert.ToDouble(current_sales_VAT_amnt);
                        }
                    }

                    /*-----------------------------------Credit Note-----------------------------------------*/

                    InvStockmasterEntity crNote = new InvStockmasterEntity
                    {
                        ReceivedateSearch = fromDate.ToString("dd/MM/yyyy"),
                        EndDate = fromDate.ToString("dd/MM/yyyy"),
                        Productid = ProductId,
                        ReportName = "Credit_Note_Sales_Register"
                    };
                    DataTable dtCrNoteInfo = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvStockmasterRecord, crNote);

                    string dlYear = "", dbNoteNo = "";
                    if (dtCrNoteInfo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtCrNoteInfo.Rows)
                        {
                            iCount += 1;

                            opening_production_qnty = total_current_production_stock_qnty.ToString();
                            opening_production_amnt = total_current_production_stock_amnt.ToString();

                            total_current_production_qnty = total_current_production_stock_qnty;
                            total_current_production_amnt = total_current_production_stock_amnt;

                            current_production_qnty = dr["Qty"].ToString();//"0.00";
                            current_production_amnt = (Convert.ToDouble(dr["TotalPrice"]) - Convert.ToDouble(dr["SD"])).ToString("0.00");

                            current_sales_qnty = "0.00";// dr["Qty"].ToString();
                            current_sales_amnt = "0.00";// dr["TotalPrice"].ToString();
                            current_sales_SD_amnt = dr["SD"].ToString();
                            current_sales_VAT_amnt = dr["VatAmnt"].ToString();

                            dlYear = dr["EntryDate"].ToString().Substring(8, 2);
                            dbNoteNo = dlYear + "-CN-" + Convert.ToDouble(dr["CreditNoteNo"]).ToString("000000");

                            current_sales_Invoice_No = dbNoteNo;
                            current_sales_Invoice_Date = dr["EntryDate"].ToString();

                            total_current_production_qnty = Convert.ToDouble(opening_production_qnty) + Convert.ToDouble(current_production_qnty);
                            total_current_production_amnt = Convert.ToDouble(opening_production_amnt) + Convert.ToDouble(current_production_amnt);

                            total_current_production_stock_qnty = total_current_production_qnty;
                            total_current_production_stock_amnt = total_current_production_amnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>

                            <td>" + Convert.ToDouble(opening_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(opening_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(total_current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(total_current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + dr["CustomerName"] + @"</td>
                            <td>" + dr["Address"] + @"</td>
                            <td>" + dr["NIDNum"] + @"</td>

                            <td>" + current_sales_Invoice_No.ToString() + @"</td>
                            <td>" + current_sales_Invoice_Date.ToString() + @"</td>

                            <td>" + GetProductNameById(dr["ItemId"].ToString()) + @"</td>
                            <td>" + Convert.ToDouble(current_sales_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_amnt).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_SD_amnt).ToString("0.00") + @"</td>
                            <td>" + Convert.ToDouble(current_sales_VAT_amnt).ToString("0.00") + @"</td>

                            <td>" + total_current_production_stock_qnty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + total_current_production_stock_amnt.ToString("0.00") + @"</td>
                            <td> Credit Note : " + dr["Reason"] + @" </td>

                        </tr>";

                            //iCount += 1;
                            dlCurrentProdQty += Convert.ToDouble(current_production_qnty);
                            dlCurrentProdAmnt += Convert.ToDouble(current_production_amnt);
                            //dlTotalProdQty += Convert.ToDouble(total_current_production_qnty);
                            //dlTotalProdAmnt += Convert.ToDouble(total_current_production_amnt);
                            dlSalesQty += Convert.ToDouble(current_sales_qnty);
                            dlSalesAmnt += Convert.ToDouble(current_sales_amnt);
                            dlSalesSdAmnt += Convert.ToDouble(current_sales_SD_amnt);
                            dlSalesVatAmnt += Convert.ToDouble(current_sales_VAT_amnt);
                        }
                    }

                    /*-----------------------------------Goods Rcv From Contract Manufacture-----------------------------------------*/

                    InvSubcontractrcvMasterEntity objGoodsRcv = new InvSubcontractrcvMasterEntity
                    {
                        Rcvdate = fromDate.ToString("dd/MM/yyyy"),
                        EndDate = fromDate.ToString("dd/MM/yyyy"),
                        Rcvitemid = ProductId,
                        ReportName = "RcvGoodsForRegister"
                    };
                    DataTable dtGoodsRcvInfo = (DataTable)ServerManager.GetTaskManager.Execute(Module.Inventory, ERPTask.AG_GetAllInvSubcontractrcvMasterRecord, objGoodsRcv);


                    if (dtGoodsRcvInfo.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtGoodsRcvInfo.Rows)
                        {
                            iCount += 1;

                            opening_production_qnty = total_current_production_stock_qnty.ToString();
                            opening_production_amnt = total_current_production_stock_amnt.ToString();

                            total_current_production_qnty = total_current_production_stock_qnty;
                            total_current_production_amnt = total_current_production_stock_amnt;

                            current_production_qnty = dr["Rcv_Qty"].ToString();
                            current_production_amnt = (Convert.ToDouble(dr["Rcv_Total_Price"])).ToString();

                            current_sales_qnty = "0.00";
                            current_sales_amnt = "0.00";
                            current_sales_SD_amnt = "0.00";// dr["SD"].ToString();
                            current_sales_VAT_amnt = "0.00";//dr["VatAmnt"].ToString();

                            current_sales_Invoice_No = dr["RcvChallanNo"].ToString();
                            current_sales_Invoice_Date = dr["RcvDate"].ToString();

                            total_current_production_qnty = Convert.ToDouble(opening_production_qnty) + Convert.ToDouble(current_production_qnty);
                            total_current_production_amnt = Convert.ToDouble(opening_production_amnt) + Convert.ToDouble(current_production_amnt);

                            total_current_production_stock_qnty = total_current_production_qnty - Convert.ToDouble(current_sales_qnty);
                            total_current_production_stock_amnt = total_current_production_amnt - Convert.ToDouble(current_sales_amnt);

                            //total_current_production_qnty = total_current_production_stock_qnty;
                            //total_current_production_amnt = total_current_production_stock_amnt;

                            TableData = TableData + @"<tr>
                            <td>" + iCount + @"</td>
                            <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>

                            <td>" + Convert.ToDouble(opening_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(opening_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + Convert.ToDouble(total_current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(total_current_production_amnt).ToString("0.00") + @"</td>

                            <td>" + dr["SupplierName"] + @"</td>
                            <td>" + dr["RcvAddress"] + @"</td>
                            <td>" + dr["NID"] + @"</td>

                            <td>" + current_sales_Invoice_No.ToString() + @"</td>
                            <td>" + current_sales_Invoice_Date.ToString() + @"</td>

                            <td>" + GetProductNameById(dr["RcvItemId"].ToString()) + @"</td>
                            <td>" + Convert.ToDouble(current_sales_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_amnt).ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + Convert.ToDouble(current_sales_SD_amnt).ToString("0.00") + @"</td>
                            <td>" + Convert.ToDouble(current_sales_VAT_amnt).ToString("0.00") + @"</td>

                            <td>" + total_current_production_stock_qnty.ToString("0.00") + " (" + Unit + ")" + @"</td>
                            <td>" + total_current_production_stock_amnt.ToString("0.00") + @"</td>
                            <td> Goods Received From Contract Manufacturer </td>

                        </tr>";

                            //iCount += 1;
                            dlCurrentProdQty += Convert.ToDouble(current_production_qnty);
                            dlCurrentProdAmnt += Convert.ToDouble(current_production_amnt);
                            //dlTotalProdQty += Convert.ToDouble(total_current_production_qnty);
                            //dlTotalProdAmnt += Convert.ToDouble(total_current_production_amnt);
                            dlSalesQty += Convert.ToDouble(current_sales_qnty);
                            dlSalesAmnt += Convert.ToDouble(current_sales_amnt);
                            dlSalesSdAmnt += Convert.ToDouble(current_sales_SD_amnt);
                            dlSalesVatAmnt += Convert.ToDouble(current_sales_VAT_amnt);
                        }
                    }


                    if (dtSalesInfo.Rows.Count <= 0 && dtProductionInfo.Rows.Count <= 0 && dtGoodsRcvInfo.Rows.Count <= 0 && dtCrNoteInfo.Rows.Count <= 0)
                    {
                        iCount += 1;
                        opening_production_qnty = total_current_production_stock_qnty.ToString();
                        opening_production_amnt = total_current_production_stock_amnt.ToString();

                        current_production_qnty = "0.00";
                        current_production_amnt = "0.00";
                        current_sales_qnty = "0.00";
                        current_sales_amnt = "0.00";
                        current_sales_SD_amnt = "0.00";
                        current_sales_VAT_amnt = "0.00";

                        //current_production_qnty = current_production_qnty;
                        //current_production_amnt = current_production_amnt;

                        total_current_production_qnty = Convert.ToDouble(opening_production_qnty) + Convert.ToDouble(current_production_qnty);
                        total_current_production_amnt = Convert.ToDouble(opening_production_amnt) + Convert.ToDouble(current_production_amnt);

                        total_current_production_stock_qnty = total_current_production_qnty;
                        total_current_production_stock_amnt = total_current_production_amnt;

                        //closingQty = total_current_production_qnty - prodQty;
                        //closingAmnt = total_current_production_amnt - prodAmnt;
                        // <td>" + totCalQty.ToString("0.00") + " (" + Unit + ")" + @"</td>

                        TableData += @"<tr>
                                <td>" + iCount + @"</td>
                                <td>" + fromDate.ToString("dd/MM/yyyy") + @"</td>

                                <td>" + Convert.ToDouble(opening_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + Convert.ToDouble(opening_production_amnt).ToString("0.00") + @"</td>

                                <td>" + Convert.ToDouble(current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + Convert.ToDouble(current_production_amnt).ToString("0.00") + @"</td>

                                <td>" + Convert.ToDouble(total_current_production_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + Convert.ToDouble(total_current_production_amnt).ToString("0.00") + @"</td>

                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>

                                <td>" + "" + @"</td>
                                <td>" + "" + @"</td>

                                <td>" + GetProductNameById(ProductId) + @"</td>
                                <td>" + Convert.ToDouble(current_sales_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + Convert.ToDouble(current_sales_amnt).ToString("0.00") + @"</td>
                                <td>" + Convert.ToDouble(current_sales_SD_amnt).ToString("0.00") + @"</td>
                                <td>" + Convert.ToDouble(current_sales_VAT_amnt).ToString("0.00") + @"</td>

                                <td>" + Convert.ToDouble(total_current_production_stock_qnty).ToString("0.00") + " (" + Unit + ")" + @"</td>
                                <td>" + Convert.ToDouble(total_current_production_stock_amnt).ToString("0.00") + @"</td>
                                <td>  </td>

                            </tr>";

                        dlCurrentProdQty += Convert.ToDouble(current_production_qnty);
                        dlCurrentProdAmnt += Convert.ToDouble(current_production_amnt);
                        dlSalesQty += Convert.ToDouble(current_sales_qnty);
                        dlSalesAmnt += Convert.ToDouble(current_sales_amnt);
                        dlSalesSdAmnt += Convert.ToDouble(current_sales_SD_amnt);
                        dlSalesVatAmnt += Convert.ToDouble(current_sales_VAT_amnt);
                    }

                    fromDate = fromDate.AddDays(1);
                }
            }


            TableData = TableData + "<tr><td colspan='4' style='text-align:right;'>মোট</td>" +
                "<td>" + dlCurrentProdQty.ToString("0.00") + "</td>" +
                "<td>" + dlCurrentProdAmnt.ToString("0.00") + "</td>" +
                "<td></td>" +
                "<td></td>" +
                "<td></td><td></td><td></td><td></td><td></td><td></td>" +
                "<td>" + dlSalesQty.ToString("0.00") + "</td>" +
                "<td>" + dlSalesAmnt.ToString("0.00") + "</td>" +
                "<td>" + dlSalesSdAmnt.ToString("0.00") + "</td>" +
                "<td>" + dlSalesVatAmnt.ToString("0.00") + "</td>" +
                "<td colspan='3'></td></tr>";

            TableData = TableData + @"</table>
            </div>
            </div>
            <div class='uk-grid' data-uk-grid-margin style='width:100%; margin: 0 auto; margin-top:50px;'>
                <div class='uk-width-medium-1-1' style='width: 100%;'>
                    <p> বিশেষ দ্রষ্টব্য : </p>
                    <p> ১) যেইক্ষেত্রে অনিবন্ধিত ব্যক্তির নিকট পণ্য বিক্রয় করা হইবে সেইক্ষেত্রে উক্ত ব্যক্তির পূর্ণাঙ্গ নাম, ঠিকানা ও জাতীয় পরিচয়পত্র নম্বর যথাযথভাবে সংশ্লিষ্ট কলামে [(৯), (১০) ও (১১)] আবশ্যিকভাবে উল্লেখ করিতে হইবে। </p>
                </div>
            </div>
            <div class='footerLine'>
                <div class='uk-width-1-3'><hr style='border: 1px solid black;'></div>
                <table style='width: 100%' id='totalField'>
                    <tr>
                        <td>
                            <sup>১ </sup><b>এসআরও নং- ২২৬-আইন/২০১৯/৬২-মূসক, তারিখঃ ৩০ জুন, ২০১৯ দ্বারা প্রতিস্থাপিত । </b>
                        </td>
                        <td>
                            Page 1 of 1
                        </td>
                        <td>
                            Print Date:" + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("h:mm:ss tt") + @"
                        </td>
                    </tr>
                </table>
            </div>
            </form>";


            ViewBag.FullData = TableData;
            return View();

        }
        #endregion

        #region Misc. Functions
        private string GetCommaFormat(double data)
        {
            return string.Format("{0:n}", data);
        }

        private double CalculateTotalPVatIncluded(double pUPrice, double pQty, string vatCatId)
        {
            VatVatcategoryEntity iVatRef = (VatVatcategoryEntity)ServerManager.GetTaskManager.Execute(Module.Admin, ERPTask.AG_GetSingleVatVatcategoryRecordById, vatCatId);

            double Vat = Convert.ToDouble(string.IsNullOrEmpty(iVatRef.Vatper) ? "0" : iVatRef.Vatper);
            double UnitP = Convert.ToDouble(pUPrice);
            double PQty = Convert.ToDouble(pQty);

            return Convert.ToDouble((UnitP + (UnitP * (Vat / 100))) * PQty);
        }

        private double CalculateMushakAmount(double Vatper, double UPrice)
        {
            return (UPrice * (Vatper / 100));
        }
        private double CalculateUnitPWVat(double Vatper, double UPrice)
        {
            return UPrice + (UPrice * (Vatper / 100));
        }

        private string getEndDateForReturn(string GivenDate)
        {
            string month = GivenDate.Substring(3, 2), fetchDate = "", year = GivenDate.Substring(6, 4);

            if (month == "01" || month == "03" || month == "05" || month == "07" || month == "08" || month == "10" || month == "12")
            {
                fetchDate = "31";
            }
            else if (month == "2")
            {
                fetchDate = "28";
            }
            else
            {
                fetchDate = "30";
            }
            return fetchDate + "/" + month + "/" + year;
        }
        #endregion
    }
}