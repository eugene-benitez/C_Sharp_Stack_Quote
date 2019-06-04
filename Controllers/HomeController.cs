using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Quote.Models;

namespace Quote.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            DateTime CurrentTime = DateTime.Now;
            ViewBag.Now = CurrentTime.ToString("MMMM dd, yyyy, hh:mm tt");
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(Qt NewQuote)
        {
            string query = $"INSERT INTO Quotes (Name, Text, Created_at) VALUES ('{NewQuote.Name}', '{NewQuote.Text}', '{NewQuote.Created_At}')";
            DbConnector.Execute(query);

            return RedirectToAction("Index");
        }

        [HttpGet("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM Quotes");
            // To provide this data, we could use ViewBag or a View Model.  ViewBag shown here:
            ViewBag.Users = AllQuotes;
            return View();
        }




















        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
