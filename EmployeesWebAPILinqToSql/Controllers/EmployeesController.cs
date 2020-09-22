using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;
using EmployeesWebAPILinqToSql.Models;

namespace EmployeesWebAPILinqToSql.Controllers
{
    /// <summary>
    /// Employee's controller 
    /// </summary>
    public class EmployeesController : ApiController
    {
        EmployeesDataClassesDataContext db = new EmployeesDataClassesDataContext();
        // GET: api/Employees
        /// <summary>
        /// Gets top 20 employees
        /// </summary>
        /// <returns>list of employees</returns>
        public IEnumerable<Employee> Get()
        {
            try
            {
                return db.Employees.Take(20).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// Gets one employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Employees/5
        public Employee Get(int id)
        {
            try
            {
                return db.Employees.Where(p => p.ID == id).First();
            }
            catch (Exception e)
            {
                throw e;
            }
}

        /// <summary>
        /// Inserts one employee
        /// </summary>
        /// <param name="employee"></param>
        // POST: api/Employees 
        public void Post(Employee employee)
        {
            try
            {
                db.Employees.InsertOnSubmit(employee);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// update one employee with same id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEmployee"></param>
        // PUT: api/Employees/5
        public void Put(int id, Employee newEmployee)
        {
            try
            {
                Employee employee = db.Employees.Where(p => p.ID == id).First();
                employee.Name = newEmployee.Name;
                employee.departmentID = newEmployee.departmentID;
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// deletes employee by id
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Employees/5
        public void Delete(int id)
        {
            try
            {
                Employee employee = db.Employees.Where(p => p.ID == id).First();
                db.Employees.DeleteOnSubmit(employee);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
