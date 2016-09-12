using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OnlineShop3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }

        public ActionResult ProCategory(long proCateid, int pageIndex = 1, int pageSize = 1)
        {
            var proCate = new ProductCategoryDao().ViewDetail(proCateid);
            ViewBag.ProCategory = proCate;
            long totalRecord = 0;
            var model = new ProductDao().ListByProCategoryId(proCateid, ref totalRecord, pageIndex, pageSize);
            ViewBag.totalRecord = totalRecord;
            ViewBag.pageIndex = pageIndex;
            int maxPage = 5;
            int totalPage = 0;
            totalPage= (int)Math.Ceiling((double)(totalRecord/pageSize));
            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            return View(model);
        }

        // directly define
        //[OutputCache(Location = OutputCacheLocation.Server, Duration = int.MaxValue, VaryByParam = "id")] // Duration unit: seconds
        // define through WebConfig
        [OutputCache(CacheProfile ="Cache1DayForProduct")]
        public ActionResult ProDetail(long proId)
        {
            var prodetail = new ProductDao().ViewDetail(proId);
            ViewBag.ProCategory = new ProductCategoryDao().ViewDetail(prodetail.ProductCategoryID.Value);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProduct(proId);
            return View(prodetail);
        }


        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword, int pageIndex = 1, int pageSize = 1)
        {
            long totalRecord = 0;
            var model = new ProductDao().Search(keyword, ref totalRecord, pageIndex, pageSize);
            ViewBag.totalRecord = totalRecord;
            ViewBag.pageIndex = pageIndex;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            return View(model);
        }
    }
}