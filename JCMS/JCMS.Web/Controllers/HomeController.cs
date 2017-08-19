using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using JCMS.EntityFramework;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Abp.Web.Security.AntiForgery;
using Abp.Web.Models;

namespace JCMS.Web.Controllers
{
    public class HomeController : JCMSControllerBase
    {
        private JCMSDbContext db = ContextFactory.GetCurrentContext();

        [DisableAbpAntiForgeryTokenValidation]
        [HttpGet]
        [DontWrapResult]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            // return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
            //  return View("~/Areas/Common/Views/Layout/_Layout.cshtml");//C:\Users\jiangcy\Desktop\JCMS\JCMS.Web\Areas\Admin\Views\UserInfo\Index.cshtml
            return RedirectToAction("../Admin/UserInfo/Index");
        }

        public ActionResult InitDataBase()
        {
            return View();
        }

        //初始化
        public JsonResult CheckDatabase()
        {
            // db.Users

            var success = true;

            List<FileInfo> list = new List<FileInfo>();
            foreach (var item in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "Data"))
            {
                list.Add(new FileInfo(item));
            }
            var item0 = (from e in list where e.Name != "procedure.sql" select new { e.FullName, e.Name }).FirstOrDefault();
            try
            {

                var items = from e in list where e.Name != "procedure.sql" && e.Name != "nv_folder.sql" && e.Name != "index.sql" && e.Extension == ".sql" select new { e.FullName, e.Name };
                foreach (var item in items)
                {
                    try
                    {
                        ContextFactory.GetCurrentContextSetDatabaseExecuteSqlCommand(item.FullName);
                    }
                    catch (Exception ex)
                    {
                        success = false;
                        Logger.Error("脚本" + item.Name + "：" + ex);
                    }
                }

            }
            catch (Exception ex)
            {
                success = false;
                Logger.Error("脚本" + item0.Name + "：" + ex);
            }



            return Json(new { success = success }, JsonRequestBehavior.AllowGet);
        }

      
    }
}