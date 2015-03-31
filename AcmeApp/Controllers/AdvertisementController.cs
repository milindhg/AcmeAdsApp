﻿using System;
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

        //
        // GET: /Advertisement/

        public ActionResult Index()
        {
            IList<AdvertisementModel> adList = new List<AdvertisementModel>();
            var query = from ad in context.Advertisements
                        select ad;
            var ads = query.ToList();
            foreach (var adData in ads)
            {
                adList.Add(new AdvertisementModel() 
                {
                    AdId = adData.ID,
                    AdName = adData.AdName,
                    AddDate = adData.AddDate,
                    PublishDate = adData.PublishDate,
                    Text = adData.Text
                });

            }
            return View(adList);
        }

        //
        // GET: /Advertisement/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Advertisement/Create

        public ActionResult Create()
        {
            AdvertisementModel model = new AdvertisementModel();

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
                    Text = model.Text
                };

                context.Advertisements.InsertOnSubmit(ad);
                context.SubmitChanges();
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
            return View();
        }

        //
        // POST: /Advertisement/Edit/5

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
        // GET: /Advertisement/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
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
