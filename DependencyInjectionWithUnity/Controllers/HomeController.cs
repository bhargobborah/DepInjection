using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DependencyInjectionWithUnity.Models;
using DependencyInjectionWithUnity.Repository;

namespace DependencyInjectionWithUnity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee employee;

        // Using dependency injection
        public HomeController(IEmployee _employee)
        {
            employee = _employee;
        }


        public ActionResult Index()
        {
            var empList = employee.GetEmployees();

            List<EmployeeModel> emp = new List<EmployeeModel>();

            foreach (var item in empList)
            {
                EmployeeModel empNew = new EmployeeModel
                {
                    EmployeeId = item.EmployeeId,
                    EmpCode = item.EmpCode,
                    FullName = item.FullName,
                    OfficeLocation = item.OfficeLocation,
                    Position = item.Position
                };

                emp.Add(empNew);
            };


            return View(emp);
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var emp = employee.GetEmployeeById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(EmployeeModel newEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee
                {
                    EmployeeId = newEmployee.EmployeeId,
                    EmpCode = newEmployee.EmpCode,
                    FullName = newEmployee.FullName,
                    OfficeLocation = newEmployee.OfficeLocation,
                    Position = newEmployee.Position
                };

                employee.InsertEmployee(emp);

                return RedirectToAction("Index");
            }

            return View(newEmployee);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = employee.GetEmployeeById(id);

            if (emp == null)
            {
                return HttpNotFound();
            }

            var teamDto = new EmployeeModel()
            {
                EmployeeId = emp.EmployeeId,
                EmpCode = emp.EmpCode,
                FullName = emp.FullName,
                OfficeLocation = emp.OfficeLocation,
                Position = emp.Position
            };

            return View(teamDto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel newEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee
                {
                    EmployeeId = newEmployee.EmployeeId,
                    EmpCode = newEmployee.EmpCode,
                    FullName = newEmployee.FullName,
                    OfficeLocation = newEmployee.OfficeLocation,
                    Position = newEmployee.Position
                };

                employee.UpdateEmployee(emp);

                return RedirectToAction("Index");
            }
            return View(newEmployee);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee emp = employee.GetEmployeeById(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            employee.DeleteEmployee(emp);
            return RedirectToAction("Index");
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Employee emp)
        //{

        //    employee.DeleteEmployee(emp);

        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
