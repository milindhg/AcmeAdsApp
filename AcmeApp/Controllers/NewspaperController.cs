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
            var query = from news in context.NewsPapers
                        select news;
            var newspapers = query.ToList();
            foreach (var newsData in newspapers)
            {
                newsList.Add(new NewspaperModel()
                {
                    Id=newsData.PaperId,
                    Name=newsData.Name,
                    AddDate=newsData.AddDate
                });
            }
            return View(newsList);
        }

        //
        // GET: /Newspaper/Details/5

        public ActionResult Details(int id)
        {
            return View();
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
                NewsPaper newspaper = new NewsPaper()
                {
                    PaperId = model.Id,
                    Name = model.Name,
                    AddDate = model.AddDate
                };
                context.NewsPapers.InsertOnSubmit(newspaper);
                context.SubmitChanges();

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
            return View();
        }

        //
        // POST: /Newspaper/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
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
