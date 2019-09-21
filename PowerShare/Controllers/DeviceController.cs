using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerShare.Models;

namespace PowerShare.Controllers
{
    public class DeviceController : BaseController
    {
        public IActionResult Index(int? uid)
        {
            User LoggedIn = CurrentUser;
            if (CurrentUser != null)
            {
                uid = LoggedIn.UserID;
            }
            List<Device> devices = null;
            if (uid != null)
            {
            devices = DAL.GetAllDeviceByUserID((int)uid)!=null? DAL.GetAllDeviceByUserID((int)uid):null;
            }
            return View(devices);
        }
        public ActionResult AddDevice(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult AddDevice(Device device)
        {
            try
            {
                User LoggedInUser = CurrentUser;
                device.UserID = CurrentUser.UserID;
                int UserAdd = DAL.AddDevice(device);
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
            return RedirectToAction("index", "Home");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var device = DAL.DeviceGetByID(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("FirstName,LastName,UserName,PhoneNumber,ID")] Device device)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int a = DAL.UpdateDevice(device);
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
            return View(device);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var device = DAL.GetDevice((int)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Year/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = DAL.RemoveDevice(id);
            return RedirectToAction(nameof(Index));
        }


    }
}