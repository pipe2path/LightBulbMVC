using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightBulbMVC.Models;

namespace LightBulbMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// process result
        /// </summary>
        /// <param name="people"></param>
        /// <param name="bulbs"></param>
        /// <returns></returns>
        public ActionResult Process(int people, int bulbs)
        {
            Dictionary<int, bool> result = new Dictionary<int, bool>();

            // fill collection with sequential numbers based on input
            IEnumerable<int> peopleColl = Enumerable.Range(0, people);
            IEnumerable<int> bulbColl = Enumerable.Range(0, bulbs);

            // process result from model
            LightBulbModel lightBulbModel = new LightBulbModel();
            LightBulbViewModel lightbulbVM = lightBulbModel.ProcessResult(peopleColl, bulbColl);
            
            // return input parameters and view model to view            
            ViewBag.NumOfPeople = peopleColl.Count();
            ViewBag.NumOfBulbs = bulbColl.Count();

            return PartialView("Results", lightbulbVM);
        }
    }
}