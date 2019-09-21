using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PowerShare.Models;

namespace PowerShare.Controllers
{
    public class UsersController : BaseController
    {
        public async Task<IActionResult> Index()
        {
                int? uid = 1;// HttpContext.Session.GetInt32("UserID");
                User User = null;
                if (uid != null)
                {
                    User U = DAL.UserGetByID(uid);
                    if (U == null)
                    {
                        return NotFound();
                    }
                    User = U;
                }
                return View(User);
        }
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
                int? uid = HttpContext.Session.GetInt32("UserID");
                if (id == null && uid != null)
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

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("FirstName,LastName,UserName,PhoneNumber,ID")] User user)
        {   
                int? uid = HttpContext.Session.GetInt32("UserID");
                if (id == null && uid != null)
                {
                    id = uid;
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        int a = DAL.UpdateUser(user);
                        if (a > 0)
                        {
                            ViewBag.Message = "User Succesfully Updated!!";
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
        }
    }
}