using Ajax_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Ajax_ASP.Controllers
{
    public class HomeController : Controller
    {
        List<EmployeeModel> list = new List<EmployeeModel>()
        {
            new EmployeeModel()
            {
                 ID = 1,
                Name = "Duc",
                Salary = 10,
                Status = true
            },
             new EmployeeModel()
             {
                 ID = 2,
                Name = "Nam",
                Salary = 100,
                Status = true
             },
             new EmployeeModel()
             {
                 ID = 3,
                Name = "Tien",
                Salary = 1000,
                Status = true
             }
        };


        public ActionResult Index()
        {
            return View();
        }

       
        [HttpGet]
        public JsonResult LoadData()
        {
            return Json(new
            {
                data = list,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(string model)
        {
            JavaScriptSerializer seria = new JavaScriptSerializer();
            EmployeeModel mo = seria.Deserialize<EmployeeModel>(model);

            var entity = list.Single(x => x.ID == mo.ID);
            entity.Salary = mo.Salary;
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}