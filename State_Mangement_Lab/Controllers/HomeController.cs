using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using State_Mangement_Lab.Models;

namespace State_Mangement_Lab.Controllers
{
    public class HomeController : Controller
    {
        List<User> usersList = new List<User>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View();
        }

        public ActionResult RegisterNewUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (Session["userList"] is null)
                {
                    usersList.Add(newUser);
                    Session["userList"] = usersList;
                }
                else
                {
                    usersList = (List<User>)(Session["userList"]);
                    usersList.Add(newUser);
                    Session["userList"] = usersList;
                }
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Registration. Try again.";
                return RedirectToAction("RegistrationPage");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginUser(string userName, string password)
        {
            if (Session["userList"] != null)
            {
                usersList = (List<User>)(Session["userList"]);
                foreach (User user in usersList)
                {
                    if (user.UserName == userName)
                    {
                        if (user.Password != password)
                        {
                            ViewBag.ErrorMessage = "Invalid Password";
                            return View("Login");
                        }
                        else
                        {
                            //create User session here
                            Session["CurrentUser"] = user;
                            return RedirectToAction("UserDetails");
                        }
                    }
                }
                ViewBag.ErrorMessage = "Invalid User Name and Password";
                return View("Login");
            }

            ViewBag.ErrorMessage = "Please register before you log in.";
            return View("Login");

        }

        public ActionResult UserDetails()
        {
            if (Session["CurrentUser"] is null)
            {
                ViewBag.ErrorMessage = "Please log in.";
                return View("Login");
            }
            else
            {
                ViewBag.CurrentUser = Session["CurrentUser"];
                return View();
            }
        }

        public ActionResult Logout()
        {
            if (Session["CurrentUser"] is null)
            {
                ViewBag.ErrorMessage = "You need to log in to log out!";
                return View("Login");
            }
            else
            {
                User currentUser = (User)(Session["CurrentUser"]);
                Session.Remove("CurrentUser");
                ViewBag.UserName = currentUser.UserName;
                return View();
            }
        }


        /* HttpSessionState.Session["UserName"] = "John"; //stores session data

        string str = HttpSessionState.Session["UserName"].ToString();

        // Retrieves session data

        HttpSessionState.Remove("Key to remove");

        //Removes an object from the session state*/


    }
}