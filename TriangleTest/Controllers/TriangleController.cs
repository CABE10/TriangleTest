using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriangleTest.Models;
using TriangleTest.Services;

namespace TriangleTest.Controllers
{
    public class TriangleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetTriangle([FromBody]Newtonsoft.Json.Linq.JObject data)
        {
            try
            {
                if (data != null)
                {
                    char row = data.First.ToObject<char>();
                    sbyte column = data.Last.ToObject<sbyte>();
                    Triangle triangle = TriangleService.GetTriangle(row, column);
                    return Json(triangle);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpPost]
        public JsonResult GetRowAndColumn([FromBody]Triangle data)
        {
            if (data != null)
            {
                string result = TriangleService.GetRowAndColumn(data);
                return Json(result);
            }
            else
            {
                return Json("Error.");
            }
        }
    }
}