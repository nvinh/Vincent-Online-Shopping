using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Dao;
using Models.EF;
using OnlineShop3.Common;

namespace OnlineShop3.Areas.Admin.Controllers
{
    public class NewsContentController : BaseController
    {
        // GET: Admin/NewsContent
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NewsContentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new NewsContentDao();
            var content = dao.GetByID(id);
            SetViewBag(content.NewsCategoryID);
            return View(content);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NewsContent model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsContentDao();
                bool result = dao.Update(model);
                if (result)
                {
                    SetAlert("The news has been successfully updated.", "success");
                    return RedirectToAction("Edit", "NewsContent");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to update this news."); // ??? success or un-success???
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsContent model)
        {
            if (ModelState.IsValid)
            {
                var session = (UserLogin)Session[CommonConstants.User_Session];
                model.CreatedBy = session.UserName;
                var culture = Session[CommonConstants.CurrentCulture];
                model.LanguageID = culture.ToString();
                new NewsContentDao().Create(model);
                return RedirectToAction("Index");
            }
            SetViewBag();
            return View();
        }

        public void SetViewBag(long? selectedID=null)
        {
            var dao = new NewsCategoryDao();
            ViewBag.NewsCategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}