using Models.Dao;
using OnlineShop3.Areas.Admin.Models;
using OnlineShop3.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop3.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
                if (result==1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.UserGroupID = user.UserGroupID;
                    var listCredentials = dao.GetListCredential(model.UserName);
                    Session.Add(CommonConstants.Session_Credentials, listCredentials);
                    Session.Add(CommonConstants.User_Session, userSession);
                    return RedirectToAction("Index", "Home");
                } else if (result==0)
                {
                    ModelState.AddModelError("", "Username isn't existed on the system.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "This account is being blocked.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "The password is invalid.");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "This account doesn't have admin permission.");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and/or password.");
                }
            } else
            {
                
            }
            return View("Index");
        }
    }
}