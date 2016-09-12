using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop3.Controllers
{
    public class NewsContentController : Controller
    {
        // GET: NewsContent
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var model = new NewsContentDao().ListAllPaging(page, pageSize);
            long totalRecord = 0;
            ViewBag.totalRecord = totalRecord;
            ViewBag.pageIndex = page;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        public ActionResult NewsDetail(long id)
        {
            var model = new NewsContentDao().GetByID(id);
            ViewBag.Tags = new NewsContentDao().ListTag(id);
            return View(model);
        }

        public ActionResult Tag(string tagId, int page = 1, int pageSize = 10)
        {
            var model = new NewsContentDao().ListAllByTag(tagId,page, pageSize);
            long totalRecord = 0;
            ViewBag.totalRecord = totalRecord;
            ViewBag.pageIndex = page;
            ViewBag.Tag = new NewsContentDao().GetTag(tagId);
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.totalPage = totalPage;
            ViewBag.maxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}