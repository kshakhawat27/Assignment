using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using SalesForce.Domain.Admin;
using SalesForce.List;

namespace SalesForce.Controllers
{
    public class NewUserController : Controller
    {
        // GET: NewUser
        public ActionResult Index()
        {
            return View();
        }
        UserInfoList objList;
        [HttpPost]
        public JsonResult UserInfo()
        {
            int _result = 0;
            objList = new UserInfoList();
            AdmUserEntity _dbModel = new AdmUserEntity();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var fileName = Path.GetFileName(file.FileName);
                var extension = fileName.Split('.').Last();
                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));

                var ImagePath = ("/UploadedImage/" + file.FileName + DateTime.Now.ToString("hh:mm:ss"));

                byte[] BrandImage = new byte[Request.Files[i].ContentLength];
                Request.Files[i].InputStream.Read(BrandImage, 0, Request.Files[i].ContentLength);


                _dbModel.UserName = Request["UserName"].ToString();
                _dbModel.UserId = Request["UserId"].ToString();
                _dbModel.RollId = Request["RollId"].ToString();
                _dbModel.UserPassword= Request["UserPassword"].ToString();
                _dbModel.ImagePath = ImagePath;


                _result = objList.SaveUserInfo(_dbModel);
            }
            if (_result > 0)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }
    }
}