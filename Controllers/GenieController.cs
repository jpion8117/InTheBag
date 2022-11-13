using Microsoft.AspNetCore.Mvc;
using System;

namespace InTheBag.Controllers
{
    public class GenieController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }

        //    [HttpPost]
        //     public IActionResult Create(string GenieName, int Age, int WishesGranted)
        //     {
        //         if (WishesGranted > 5000 || Age > 1000)
        //             return View("ExperiencedGenie");
        //         else
        //             return View("Novice");
        //     }
        [HttpPost]
        public IActionResult Create(string GenieName)
        {
            int Age = Int32.Parse(Request.Form["WishesGranted"]);
            int WishesGranted = Int32.Parse(Request.Form["Age"]);

            if (WishesGranted > 5000 || Age > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
        public IActionResult Create2()
        {
            var name = RouteData.Values["GenieName"];
            var age = Int32.Parse((string)RouteData.Values["Age"]);
            var wishesGranted = Int32.Parse((string)RouteData.Values["WishesGranted"]);

            if (wishesGranted > 5000 || age > 1000)
                return View("ExperiencedGenie");
            else
                return View("Novice");
        }
        public IActionResult Perks()
        {
            ViewBag.Posted = false;
            return View();
        }
        [HttpPost]
        public IActionResult Perks(string[] perk)
        {
            ViewBag.Posted = true;
            ViewBag.Perks = Request.Form["perk"];
            ViewBag.Perk = perk;
            return View();
        }
    }
}
