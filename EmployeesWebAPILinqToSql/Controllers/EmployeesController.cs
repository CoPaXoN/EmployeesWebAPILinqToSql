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
        EmployeesDataClassesDataContext employeesDB = new EmployeesDataClassesDataContext();
        // GET: api/Employees
        /// <summary>
        /// Gets top 20 employees
        /// </summary>
        /// <returns>list of employees</returns>
        public IEnumerable<Employee> Get()
        {
            List<Employee> employees = employeesDB.Employees.Take(20).ToList();
            return employees;
        }
        /// <summary>
        /// Gets one employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Employees/5
        public Employee Get(int id)
        {
            return employeesDB.Employees.Where(p => p.ID == id).First();
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
                employeesDB.Employees.InsertOnSubmit(employee);
                employeesDB.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                Employee employee = employeesDB.Employees.Where(p => p.ID == id).First();
                employee.Name = newEmployee.Name;
                employee.departmentID = newEmployee.departmentID;
                employeesDB.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
                Employee employee = employeesDB.Employees.Where(p => p.ID == id).First();
                employeesDB.Employees.DeleteOnSubmit(employee);
                employeesDB.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
