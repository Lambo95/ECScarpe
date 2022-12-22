using ECScarpe.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECScarpe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Scarpe.GetAllScarpe());
        }

        public ActionResult Details(int id)
        {
            return View(Scarpe.GetScarpa(id));
        }

        public ActionResult ModificaProdotto(int id)
        {
            return View(Scarpe.GetScarpa(id));
        }


        [HttpPost]
        public ActionResult ModificaProdotto(Scarpe scarpa)
        {
            Scarpe.AggiornaScarpa(scarpa);
            return RedirectToAction("Index");
        }

        public ActionResult AggiungiScarpa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AggiungiScarpa(Scarpe scarpa, HttpPostedFileBase fileUpload, HttpPostedFileBase fileUpload2, HttpPostedFileBase fileUpload3)
        {
            string filenameDb = "";
            if (fileUpload != null)
            {
                if (fileUpload.ContentLength > 0)
                {
                    filenameDb = fileUpload.FileName;
                    string Path = Server.MapPath("~/Content/Media/" + filenameDb);
                    fileUpload.SaveAs(Path);
                    scarpa.ImgPrinc = filenameDb;
                }
            }

            if (fileUpload2 != null)
            {
                if (fileUpload2.ContentLength > 0)
                {
                    filenameDb = fileUpload2.FileName;
                    string Path = Server.MapPath("~/Content/Media/" + filenameDb);
                    fileUpload2.SaveAs(Path);
                    scarpa.ImgDet1 = filenameDb;
                }
            }

            if (fileUpload3 != null)
            {
                if (fileUpload.ContentLength > 0)
                {
                    filenameDb = fileUpload3.FileName;
                    string Path = Server.MapPath("~/Content/Media/" + filenameDb);
                    fileUpload3.SaveAs(Path);
                    scarpa.ImgDet2 = filenameDb;
                }
            }
            Scarpe.AggiungiScarpa(scarpa);
            return RedirectToAction("Index");
        }
    }
}