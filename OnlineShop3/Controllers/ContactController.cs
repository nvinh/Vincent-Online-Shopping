using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop3.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactDao().GetContact();
            return View(model);
        }

        [HttpPost]
        public JsonResult Send(string name, string phone, string address, string email, string content)
        {
            var feedback = new Feedback();
            feedback.Name = name;
            feedback.Email = email;
            feedback.CreatedDate = DateTime.Now;
            feedback.Phone = phone;
            feedback.Content = content;
            feedback.Address = address;

            var id= new ContactDao().InsertFeedback(feedback);
            if (id>0)
            {
                return Json(new
                {
                    status = true
                });
                // send en e-mail to admin
                // ....
            }
            else
            {
                return Json(new
                {
                    status = false
                });
            }
        }
    }
}