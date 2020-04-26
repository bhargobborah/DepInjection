using DependencyInjectionWithUnity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjectionWithUnity.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDBEntities context;

        public EmployeeRepository(EmployeeDBEntities _context)
        {
            context = _context;
        }

        public void DeleteEmployee(Employee emp)
        {
            context.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public Employee GetEmployeeById(int? empId)
        {
            return context.Employees.Find(empId);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }

        public void InsertEmployee(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee emp)
        {
            context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}