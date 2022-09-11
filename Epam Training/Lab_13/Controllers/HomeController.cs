using Lab_13.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab_13.Controllers
{
    public class HomeController : Controller
    {
        MonitorContext DB { get; set; }
        public HomeController(MonitorContext context)
        {
            DB = context;
        }

        [HttpGet]
        public IActionResult Add() // <input type="hidden" value="@ViewBag.PhoneId" name="PhoneId" />
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Models.Monitor monitor)
        {
            if (string.IsNullOrWhiteSpace(monitor.Manufacturer)) monitor.Manufacturer = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Model)) monitor.Model = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Code)) monitor.Code = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Price.ToString())) monitor.Price = 0.0;
            if (string.IsNullOrWhiteSpace(monitor.AspectRatio)) monitor.AspectRatio = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Resolution)) monitor.Resolution = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Diagonal.ToString())) monitor.Diagonal = 0.0;
            if (string.IsNullOrWhiteSpace(monitor.FrameRate.ToString())) monitor.FrameRate = 0;
            if (string.IsNullOrWhiteSpace(monitor.Matrix)) monitor.Matrix = "N/A";

            DB.Monitors.Add(monitor);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Modify(int id)
        {
            var monitor = DB.Monitors.Find(id);
            ViewBag.monitor = monitor;
            return View();
        }
        [HttpPost]
        public IActionResult Modify(Models.Monitor monitor)
        {
            if (string.IsNullOrWhiteSpace(monitor.Manufacturer)) monitor.Manufacturer = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Model)) monitor.Model = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Code)) monitor.Code = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Price.ToString())) monitor.Price = 0.0;
            if (string.IsNullOrWhiteSpace(monitor.AspectRatio)) monitor.AspectRatio = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Resolution)) monitor.Resolution = "N/A";
            if (string.IsNullOrWhiteSpace(monitor.Diagonal.ToString())) monitor.Diagonal = 0.0;
            if (string.IsNullOrWhiteSpace(monitor.FrameRate.ToString())) monitor.FrameRate = 0;
            if (string.IsNullOrWhiteSpace(monitor.Matrix)) monitor.Matrix = "N/A";

            DB.Monitors.Update(monitor);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            DB.Monitors.Remove(new Models.Monitor { ID = id });
            DB.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            return View(DB.Monitors.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}