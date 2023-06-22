using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Db.DbOperations;
using MyApp.Model;

namespace MVCAppWithDB.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepository repository = null;
        public HomeController() 
        {
            repository= new EmployeeRepository();   
        }

        // GET: Home
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.AddEmployee(model);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Data Added";
                }
            }
            return View();
        }

        public ActionResult GetAllRecords()
        {
            var result = repository.GetAllEmployees();
            return View(result);
        }
    }
}