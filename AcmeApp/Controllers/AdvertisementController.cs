using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcmeApp.Models;

namespace AcmeApp.Controllers
{
    public class AdvertisementController : Controller
    {
        private AcmeDBDataContext context;

        public AdvertisementController()
        {
            context = new AcmeDBDataContext();
        }


        private void PrepareNewspaper(AdvertisementModel model)
        {
            model.Newspapers = context.NewsPapers.AsQueryable<NewsPaper>().Select(x =>
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.PaperId.ToString()
                });
        }

        //
        // GET: /Advertisement/

        public ActionResult Index()
        {
            IList<AdvertisementModel> adList = new List<AdvertisementModel>();
            //var query = from ad in context.Advertisements
            //            join newspaper in context.NewsPapers
            //            on ad.NewsPaperId equals newspaper.PaperId
            //            select new AdvertisementModel
            //            {
            //                AdName=ad.AdName,
            //                AdId=ad.ID,
            //                AddDate=ad.AddDate,
            //                PublishDate=ad.PublishDate,
            //                Text=ad.Text,
            //                NewsPaperId=ad.NewsPaperId,
            //                PaperName=newspaper.Name,
                            
            //            };
            adList = getAdvertisements();
            return View(adList);
        }


        public List<AdvertisementModel> getAdvertisements()
        {
            IList<AdvertisementModel> adList = new List<AdvertisementModel>();
            AdvertisementModel ad;
            var result = context.AdvertisementSelectAll();
            foreach (var item in result)
            {
                ad = new AdvertisementModel();
                ad.AdName = item.AdName;
                ad.AdId = item.ID;
                ad.AddDate = item.AddDate;
                ad.PublishDate = item.PublishDate;
                ad.Text = item.Text;
                ad.NewsPaperId = item.NewsPaperId;
                ad.PaperName = item.Name;
                adList.Add(ad);
            }
            return adList.ToList();
        }


        //
        // GET: /Advertisement/Details/5

        public ActionResult Details(int id)
        {
            AdvertisementModel model = new AdvertisementModel();
            var result = context.AdvertisementSelectRow(id).SingleOrDefault();
            model.AdId = result.ID;
            model.AdName = result.AdName;
            model.AddDate = result.AddDate;
            model.PublishDate = result.PublishDate;
            model.Text = result.Text;
            model.NewsPaperId = result.NewsPaperId;
            model.PaperName = result.Name;
            return View(model);
        }

        //
        // GET: /Advertisement/Create

        public ActionResult Create()
        {
            AdvertisementModel model = new AdvertisementModel();
            PrepareNewspaper(model);
            return View(model);
        }

        //
        // POST: /Advertisement/Create

        [HttpPost]
        public ActionResult Create(AdvertisementModel model)
        {
            try
            {
                Advertisement ad = new Advertisement()
                {
                    ID = model.AdId,
                    AdName = model.AdName,
                    AddDate = model.AddDate,
                    PublishDate = model.PublishDate,
                    Text = model.Text,
                    NewsPaperId = model.NewsPaperId
                };

                //context.Advertisements.InsertOnSubmit(ad);
                context.AdvertisementInsertRow(model.AdName, model.Text, model.PublishDate, model.AddDate, model.NewsPaperId);
                //context.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Advertisement/Edit/5

        public ActionResult Edit(int id)
        {
            AdvertisementModel model = new AdvertisementModel();
            var result = context.AdvertisementSelectRow(id).SingleOrDefault();
            model.AdId = result.ID;
            model.AdName = result.AdName;
            model.Text = result.Text;
            model.AddDate = result.AddDate;
            model.PublishDate = result.PublishDate;
            model.NewsPaperId = result.NewsPaperId;
            model.PaperName = result.Name;
            PrepareNewspaper(model);
            return View(model);
        }

        //
        // POST: /Advertisement/Edit/5

        [HttpPost]
        public ActionResult Edit(AdvertisementModel model)
        {
            try
            {
                Advertisement ad = new Advertisement()
                {
                    ID = model.AdId,
                    AdName = model.AdName,
                    AddDate = model.AddDate,
                    PublishDate = model.PublishDate,
                    Text = model.Text,
                    NewsPaperId = model.NewsPaperId
                };

                context.AdvertisementUpdateRow(model.AdId,model.AdName, model.Text, model.PublishDate, model.AddDate, model.NewsPaperId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Advertisement/Delete/5

        public ActionResult Delete(int id)
        {
            context.AdvertisementDeleteRow(id);
            return RedirectToAction("Index");
            //return View();
        }

        //
        // POST: /Advertisement/Delete/5

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
