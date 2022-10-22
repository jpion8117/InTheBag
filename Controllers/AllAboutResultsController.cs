using System;
using Microsoft.AspNetCore.Mvc;

namespace InTheBag.Controllers
{
    public class AllAboutResultsController : Controller
    {
        private static int fakeDayOffset = 0;
        public IActionResult Index()
        {
            DayOfWeek weekday = DateTime.Now.AddDays(fakeDayOffset).DayOfWeek;
            string day = weekday.ToString();
            int time = DateTime.Now.Hour;

            ++fakeDayOffset; //changes day by one with each refresh

            //modified times slightly, it was making me sad that I now wake up at 5am to get to work by 6:30...
            if(time < 5)
                ViewBag.Greeting = "It's too early to be up!";
            else if (time < 12)
                ViewBag.Greeting = "Morning, good or bad have yet to be established...";
            else if (time <= 17)
                ViewBag.Greeting = "Good Afternoon!";
            else if (time < 19)
                ViewBag.Greeting = "Good Evening!";
            else
                ViewBag.Greeting = "Good God it's time for bed!";

            int route = 0;

            switch (day.ToLower())
            {
                case "monday":
                case "tuesday":
                    ViewData["dayMessage"] = "Something is definatly broken today...";
                    route = 1;
                    break;
                case "wednesday":
                    ViewData["dayMessage"] = "Thank Jesus it's almost over";
                    route = 2;
                    break;
                case "thursday":
                    ViewData["dayMessage"] = "One more day of work...";
                    route = 3;
                    break;
                case "friday":
                    ViewData["dayMessage"] = "Just a few more hours!";
                    route = 4;
                    break;
                default:
                    ViewData["dayMessage"] = "Oh wait, I'm also a student... I don't get weekends. lolz";
                    route = 5;
                    break;
            }

            if (route == 1)
                return RedirectToAction("Weekday", "AllAboutResults");
            else if (route == 2 || route == 3)
                return Redirect("https://lisabalbach.com/CIT218/Chapter8/HappyWednesday.html");
            else
                return View();
        }

        public IActionResult Weekday()
        {
            ViewBag.Greeting = "Alternative path discovered...";
            return View();
        }
    }
}
