using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PowerShare.Models;

namespace PowerShare.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index()
        {
            List<Device> devices = null;
            DAL.GetAllDeviceByUserID();
            return View();
        }

    }
}