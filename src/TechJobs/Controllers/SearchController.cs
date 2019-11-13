using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {

        //List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        [HttpPost]
        [Route ("/Search")]

    public IActionResult Results( string column, string searchTerm) // check names 
        {
            ViewBag.title = "Search by Term ";
            ViewBag.columns = ListController.columnChoices;
            searchTerm = searchTerm.ToLower();
            List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(column, searchTerm);

            ViewBag.jobs = jobs;
            return View("Index");

                            }




        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
