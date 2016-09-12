﻿using Models.Dao;
using OnlineShop3.Common;
using OnlineShop3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShop3.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var productDao= new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);     //get Top 4 products
            ViewBag.FeatureProducts = productDao.ListFeatureProduct(4);
            ViewBag.Title = ConfigurationManager.AppSettings["HomeTitle"];
            ViewBag.Keywords = ConfigurationManager.AppSettings["HomeKeywords"];
            ViewBag.Descriptions = ConfigurationManager.AppSettings["HomeDescriptions"];
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration =60*60*24)] // 60*60= 3600 seconds
        //[OutputCache(CacheProfile = "Cache1Hour")] - CacheProfile doesn't support for ChildActionOnly
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupID(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60 * 24)] // Duration unit: seconds
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupID(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60 * 60 * 24)] // Duration unit: seconds
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}