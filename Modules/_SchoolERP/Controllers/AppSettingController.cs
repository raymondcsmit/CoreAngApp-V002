using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Controllers
{
    public class AppSettingController : BaseController
    {
        // GET: /AppSetting/
        public ActionResult Index()
        {
            return View();
        }

        // GET AppSetting/GetGrid
        public ActionResult GetGrid()
        {
            var tak = db.AppSettings.ToArray();

            var result = from c in tak
                         select new string[] { c.Id.ToString(), Convert.ToString(c.Id),
            Convert.ToString(c.SchoolName),
            Convert.ToString(c.Address),
            Convert.ToString(c.Phone),
            Convert.ToString(c.Fax),
            Convert.ToString(c.Email),
            Convert.ToString(c.Currency),
            Convert.ToString(c.CurrencySymbol),
            Convert.ToString(c.Language_LanguageId.Name),
            Convert.ToString(c.Logo),
            Convert.ToString(c.SessionYear_RunningYearId.Name),
            Convert.ToString(c.Location),
            Convert.ToString(c.Facebook),
            Convert.ToString(c.Twitter),
            Convert.ToString(c.Linkedin),
            Convert.ToString(c.GooglePlus),
            Convert.ToString(c.Youtube),
            Convert.ToString(c.Instagram),
            Convert.ToString(c.Pinterest),
            Convert.ToString(c.Footer),
             };
            return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
        }
        // GET: /AppSetting/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppSetting ObjAppSetting = db.AppSettings.Find(id);
            if (ObjAppSetting == null)
            {
                return HttpNotFound();
            }
            return View(ObjAppSetting);
        }
        // GET: /AppSetting/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            ViewBag.RunningYearId = new SelectList(db.SessionYears, "Id", "Name");

            return View();
        }

        // POST: /AppSetting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(AppSetting ObjAppSetting, HttpPostedFileBase Logo, string HideImage1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    if (Logo != null)
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Logo, Server.MapPath("~/Uploads"));
                        ModelState.Clear();
                        ObjAppSetting.Logo = fileName;
                    }
                    else
                    {
                        ObjAppSetting.Logo = HideImage1;
                    }


                    db.AppSettings.Add(ObjAppSetting);
                    db.SaveChanges();


                    //add in chche
                    var cacheItemKey = "GetAppSetting";
                    HttpRuntime.Cache.Insert(cacheItemKey, ObjAppSetting, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration);


                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }
        // GET: /AppSetting/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppSetting ObjAppSetting = db.AppSettings.Find(id);
            if (ObjAppSetting == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", ObjAppSetting.LanguageId);
            ViewBag.RunningYearId = new SelectList(db.SessionYears, "Id", "Name", ObjAppSetting.RunningYearId);


            return View(ObjAppSetting);
        }

        // POST: /AppSetting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(AppSetting ObjAppSetting, HttpPostedFileBase Logo, string HideImage1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    if (Logo != null)
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Logo, Server.MapPath("~/Uploads"));
                        ModelState.Clear();
                        ObjAppSetting.Logo = fileName;
                    }
                    else
                    {
                        ObjAppSetting.Logo = HideImage1;
                    }


                    db.Entry(ObjAppSetting).State = EntityState.Modified;
                    db.SaveChanges();

                    //add in chche
                    var cacheItemKey = "GetAppSetting";
                    HttpRuntime.Cache.Insert(cacheItemKey, ObjAppSetting, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration);

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }


            return Content(sb.ToString());

        }
        // GET: /AppSetting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppSetting ObjAppSetting = db.AppSettings.Find(id);
            if (ObjAppSetting == null)
            {
                return HttpNotFound();
            }
            return View(ObjAppSetting);
        }

        // POST: /AppSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {

                AppSetting ObjAppSetting = db.AppSettings.Find(id);
                db.AppSettings.Remove(ObjAppSetting);
                db.SaveChanges();

                sb.Append("Sumitted");
                return Content(sb.ToString());

            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }
        // GET: /AppSetting/MultiViewIndex/5
        public ActionResult MultiViewIndex(int? id)
        {
            AppSetting ObjAppSetting = db.AppSettings.Find(id);
            ViewBag.IsWorking = 0;
            if (id > 0)
            {
                ViewBag.IsWorking = id;
                ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", ObjAppSetting.LanguageId);
                ViewBag.RunningYearId = new SelectList(db.SessionYears, "Id", "Name", ObjAppSetting.RunningYearId);

            }

            return View(ObjAppSetting);
        }

        // POST: /AppSetting/MultiViewIndex/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult MultiViewIndex(AppSetting ObjAppSetting, HttpPostedFileBase Logo, string HideImage1)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try
            {
                if (ModelState.IsValid)
                {
                    if (Logo != null)
                    {
                        var fileName = MicrosoftHelper.MSHelper.StarkFileUploaderCSharp(Logo, Server.MapPath("~/Uploads"));
                        ModelState.Clear();
                        ObjAppSetting.Logo = fileName;
                    }
                    else
                    {
                        ObjAppSetting.Logo = HideImage1;
                    }


                    db.Entry(ObjAppSetting).State = EntityState.Modified;
                    db.SaveChanges();

                    //add in chche
                    var cacheItemKey = "GetAppSetting";
                    HttpRuntime.Cache.Insert(cacheItemKey, ObjAppSetting, null, DateTime.Now.AddDays(30), System.Web.Caching.Cache.NoSlidingExpiration);

                    sb.Append("Sumitted");
                    return Content(sb.ToString());
                }
                else
                {
                    foreach (var key in this.ViewData.ModelState.Keys)
                    {
                        foreach (var err in this.ViewData.ModelState[key].Errors)
                        {
                            sb.Append(err.ErrorMessage + "<br/>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sb.Append("Error :" + ex.Message);
            }

            return Content(sb.ToString());

        }

        //private SIContext db = new SIContext();


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}
