using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerShare.Models;

namespace PowerShare.Controllers
{
    public class AccountController : BaseController
    {
        #region constructor
        public AccountController()
        {
            
        }
        #endregion

        #region Login
        public ActionResult Login(string returnUrl)
        {
            var s = TempData["UserAddSuccess"];
            var e = TempData["UserAddError"];


            if (s != null)
                ViewData["UserAddSuccess"] = s;
            else if (e != null)
                ViewData["UserAddError"] = e;

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(String userName, String passWord)
        {
            User loggedIn = DAL.GetUser(userName, passWord);
            if (loggedIn != null)
            {
                CurrentUser = loggedIn; //Sets the session for user from base controller
                HttpContext.Session.SetString("UserName", loggedIn.FirstName);
                HttpContext.Session.SetInt32("UserID", loggedIn.ID); //Sets userid in the session
                HttpContext.Session.SetString("UserRole", (loggedIn.Role.IsAdmin == true) ? "True" : "False");
                if (loggedIn.Role.IsAdmin)
                {
                    return RedirectToAction("Index", "Admin"); //Redirects to the admin dashboard
                }
                return RedirectToAction("Dashboard");
            }
            ViewBag.Error = "Invalid Username and/or Password";
            ViewBag.User = userName;
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Dashboard()
        {
            User LoggedIn = CurrentUser;
            List<object> obj = new List<object>();
            if (LoggedIn != null)
            {
                obj.Add(LoggedIn);
                return View(obj);
            }
            else
            {
                TempData["Error"] = "You Dont Have Enough Previlage to view User";
                return RedirectToAction("index", "Home");
            }
        }
        public IActionResult Logout()
        {
            //await _signManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
        #endregion

        #region Registration

        // GET: /Account/AddUser
        [AllowAnonymous]
        public ActionResult AddUser(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult AddUser(User NewUser)
        {
            int check = DAL.CheckUserExists(NewUser.UserName);
            if (check > 0)
            {
                ViewBag.Error = " Username not Unique! Please enter a new username.";
                return View();
            }
            else
            {
                try
                {
                    int UserAdd = DAL.AddUser(NewUser);
                    if (UserAdd < 1)
                    {
                        TempData["UserAddError"] = "Sorry, unexpected Database Error. Please try again later.";
                    }
                    else
                    {
                        TempData["UserAddSuccess"] = "User added successfully";
                    }
                }
                catch
                {
                    TempData["UserAddError"] = "Sorry, unexpected Database Error. Please try again later.";
                }
            }
            return RedirectToAction("index", "Home");
        }
        #endregion
        #region Password Reset
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(int? id, [Bind("FirstName,LastName,UserName,Password,ID")] User user)
        {
            if (user.ID == id)
            {
                User u = DAL.UserGetByID(id);
                u.FirstName = user.FirstName;
                u.LastName = u.LastName;
                u.Password = user.Password;
                int i = DAL.UpdateUserPassword(u);
                if (i > 0)
                {
                    TempData["Message"] = "User Info Succesfully Modified";
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Input ID from system and Form doesnot match!";
                return NotFound();
            }
        }
        public ActionResult ResetPasswordEmail()
        {
            return View();
        }

        [AllowAnonymous]
        #endregion

        #region Edit Account
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            int? uid = HttpContext.Session.GetInt32("UserID");
            if (uid != null)
            {
                id = uid;
            }
            if (id == null)
            {
                return NotFound();
            }
            var user = DAL.UserGetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("FirstName,LastName,UserName,ID")] User user)
        {

            if (id != user.ID)
            {
                return NotFound();
            }
            int? uid = HttpContext.Session.GetInt32("UserID");
            if (id == null && uid != null)
            {
                id = uid;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (id == uid)
                    {
                        int a = DAL.UpdateUser(user);
                        if (a > 0)
                        {
                            HttpContext.Session.SetString("username", user.EmailAddress);
                            TempData["Message"] = "User Succesfully Updated!!";
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Trick!!";
                    }
                    return RedirectToAction("Dashboard", "Account");
                }
                catch (Exception ex)
                {

                }
            }
            return RedirectToAction("Dashboard", "Account");
        }
        #endregion

        #region Profile
        public ActionResult Profile()
        {
            int? uid = HttpContext.Session.GetInt32("UserID");
            int id = 0;
            if (uid != null)
            {

                User U = DAL.UserGetByID(uid);
                return View(U);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }

        }
        #endregion
    }
}