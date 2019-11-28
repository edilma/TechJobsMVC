using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {

        
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

    
        
        public IActionResult Results( string searchType, string searchTerm) 
        {
            ViewBag.title = "Search by Term ";
            ViewBag.columns = ListController.columnChoices;
            if (searchTerm == null)
                {
                //show all results
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.jobs = jobs;
                 }
            else
            {
                searchTerm = searchTerm.ToLower();
                if (searchType == "all")
                {
                    List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                    ViewBag.jobs = jobs;
                }
                else
                {

                    List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                    ViewBag.jobs = jobs;

                }
            }

            
            
            return View("Index");

                            }




        

    }
}
