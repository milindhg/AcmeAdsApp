using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeApp.Models;

namespace AcmeApp.Controllers
{
    public class NewspaperController : Controller
    {
        private AcmeDBDataContext context;

        public NewspaperController()
        {
            context = new AcmeDBDataContext();
        }
        //
        // GET: /Newspaper/

        public ActionResult Index()
        {
            IList<NewspaperModel> newsList = new List<NewspaperModel>();
            NewspaperModel newspaper;
            var result = context.NewsPaperSelectAll();
            foreach (var item in result)
            {
                newspaper = new NewspaperModel();
                newspaper.Id = item.PaperId;
                newspaper.Name = item.Name;
                newspaper.AddDate = item.AddDate;
                newsList.Add(newspaper);
            }            
            return View(newsList);
        }

        //
        // GET: /Newspaper/Details/5

        public ActionResult Details(int id)
        {
            var result = context.NewsPaperSelectRow(id).SingleOrDefault();
            NewspaperModel model = new NewspaperModel();
            model.Id = result.PaperId;
            model.Name = result.Name;
            model.AddDate = result.AddDate;
            return View(model);
        }

        //
        // GET: /Newspaper/Create

        public ActionResult Create()
        {
            NewspaperModel model = new NewspaperModel();
            return View(model);
        }

        //
        // POST: /Newspaper/Create

        [HttpPost]
        public ActionResult Create(NewspaperModel model)
        {
            try
            {
                context.NewsPaperInsertRow(model.Name,model.AddDate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Newspaper/Edit/5

        public ActionResult Edit(int id)
        {
            NewspaperModel model = new NewspaperModel();
            var result = context.NewsPaperSelectRow(id).SingleOrDefault();
            model.Id = result.PaperId;
            model.Name = result.Name;
            model.AddDate = result.AddDate;
            return View(model);
        }

        //
        // POST: /Newspaper/Edit/5

        [HttpPost]
        public ActionResult Edit(NewspaperModel model)
        {
            try
            {
                context.NewsPaperUpdateRow(model.Id, model.Name, model.AddDate);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Newspaper/Delete/5

        public ActionResult Delete(int id)
        {
            context.NewsPaperDeleteRow(id);
            return RedirectToAction("Index");
        }

        //
        // POST: /Newspaper/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
