using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PowerShare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace PowerShare.Controllers
{
    public class BaseController : Controller
    {
       public BaseController()
        {

        }
        public string Get(string key)
        {
            string sObject = HttpContext.Session.GetString(key);
            return sObject;
        }
        public T Get<T>(string key)
        {
            //_context = context;
            if (HttpContext.Session.Keys.Contains(key))
            {
                string sObject = HttpContext.Session.GetString(key);
                return JsonConvert.DeserializeObject<T>(sObject);
            }
            else
            {
                return default(T);
            }
        }
        public void Set(string key, object obj)
        {
            String jsonString = JsonConvert.SerializeObject(obj);
            HttpContext.Session.SetString(key, jsonString);
        }
    }
}