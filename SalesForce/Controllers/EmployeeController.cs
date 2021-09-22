using System.Collections.Generic;
using SalesForce.Models;
using System.Web.Mvc;
using CG01Lib;
using System;
using System.Data;
using SalesForce.Domain.Admin;
using SalesForce.Structure;



using Microsoft.Reporting.WebForms;


namespace SalesForce.Areas.Admin.Controllers
{
    public class EmployeeController : AdmBaseController
    {
        // GET: Report
        public ActionResult AllEmployeeDetails()
        {
            M_GetModuleWiseTabList(Module.Admin, "Settings", "CompanyCategory");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Company Category";
            Session["PageHeader"] = "Company Category";
            ViewData["IsActiveList"] = GetIsActiveList();
            return View();
        }
        CG01List objList;
        [HttpGet]
        public JsonResult LoadAllCG01()
        {
            objList = new CG01List();
            List<EmployeeModel2> _dbModelList = new List<EmployeeModel2>();
            _dbModelList = objList.LoadAllCG01();
            return this.Json(_dbModelList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Info(string reportTypes)
        {
            try
            {


                //string reportTypes = "EXCELOPENXML";
                CG01List _objList = new CG01List();
                DataSet ds = new DataSet();
                LocalReport localReport = new LocalReport();

                ds = _objList.LoadAllCG01Report();
                localReport.ReportPath = Server.MapPath("~/Reports/EmployeeDetails.rdlc");


                ReportDataSource reportDataSource1 = new ReportDataSource();

                reportDataSource1.Name = "EmployeeDetails";
                reportDataSource1.Value = ds.Tables[0];

                localReport.Refresh();
                localReport.DataSources.Add(reportDataSource1);
                //localReport.DataSources.Add(reportDataSource2);
                string reportType = reportTypes;
                string mimeType;
                string encoding;
                string fileNameExtension = "";
                //The DeviceInfo settings should be changed based on the reportType            
                //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
                string deviceInfo = "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                        "  <PageWidth>8.50in</PageWidth>" +
                        "  <PageHeight>11.69in</PageHeight>" +
                        "  <MarginTop>.2in</MarginTop>" +
                        "  <MarginLeft>.5in</MarginLeft>" +
                        "  <MarginRight>.5in</MarginRight>" +
                        "  <MarginBottom>.2in</MarginBottom>" +
                    "</DeviceInfo>";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                if (reportType == "EXCELOPENXML")
                {
                    return File(renderedBytes, mimeType, "Info.xlsx");
                }
                else
                {
                    return File(renderedBytes, mimeType, "Info.pdf");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult AttendanceDetails()
        {
            M_GetModuleWiseTabList(Module.Admin, "Settings", "CompanyCategory");
            ViewBag.PageModule = "Admin"; ViewBag.PageModuleName = "Admin"; ViewBag.PageHeader = "Company Category";
            Session["PageHeader"] = "Company Category";
            ViewData["IsActiveList"] = GetIsActiveList();
            return View();
        }

        [HttpGet]
        public JsonResult LoadAllAttendance()
        {
            objList = new CG01List();
            List<AttendanceModel> _dbModelList = new List<AttendanceModel>();
            _dbModelList = objList.LoadAllAttendance();
            return this.Json(_dbModelList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AttendanceInfo(string reportTypes)
        {
            try
            {


                //string reportTypes = "EXCELOPENXML";
                CG01List _objList = new CG01List();
                DataSet ds = new DataSet();
                LocalReport localReport = new LocalReport();

                ds = _objList.LoadAllAttendanceReport();
                localReport.ReportPath = Server.MapPath("~/Reports/AttendanceDetails.rdlc");


                ReportDataSource reportDataSource1 = new ReportDataSource();

                reportDataSource1.Name = "AttendanceDetails";
                reportDataSource1.Value = ds.Tables[0];

                localReport.Refresh();
                localReport.DataSources.Add(reportDataSource1);
                //localReport.DataSources.Add(reportDataSource2);
                string reportType = reportTypes;
                string mimeType;
                string encoding;
                string fileNameExtension = "";
                //The DeviceInfo settings should be changed based on the reportType            
                //http://msdn2.microsoft.com/en-us/library/ms155397.aspx            
                string deviceInfo = "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                        "  <PageWidth>8.50in</PageWidth>" +
                        "  <PageHeight>11.69in</PageHeight>" +
                        "  <MarginTop>.2in</MarginTop>" +
                        "  <MarginLeft>.5in</MarginLeft>" +
                        "  <MarginRight>.5in</MarginRight>" +
                        "  <MarginBottom>.2in</MarginBottom>" +
                    "</DeviceInfo>";
                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
                if (reportType == "EXCELOPENXML")
                {
                    return File(renderedBytes, mimeType, "Info.xlsx");
                }
                else
                {
                    return File(renderedBytes, mimeType, "Info.pdf");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}