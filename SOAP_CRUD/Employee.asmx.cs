using SOAP_CRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAP_CRUD
{
    /// <summary>
    /// Summary description for Employee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Employee : System.Web.Services.WebService
    {
        EmployeesEntities db = new EmployeesEntities();

        [WebMethod]
        public Model.Employee GetEmployeeDetails(int id)
        {


            Model.Employee emp = new Model.Employee();
            emp = db.Employees.Where(x => x.Id ==
            id).FirstOrDefault(); return emp;
        }
        [WebMethod]
        public List<Model.Employee> GetEmployeeList()
        {
            List<Model.Employee> emp = new List<Model.Employee>(); emp = db.Employees.ToList(); return emp;
        }
        [WebMethod]
        public string AddEmployee(string name, int age, string address, int salary)
        {
            Model.Employee employee = new Model.Employee
            {
                Name = name,
                Age = age,
                Salary = salary,
                Address = address
            }; try
            {
                db.Employees.Add(employee); db.SaveChanges(); return "Employee Added Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [WebMethod]
        public string UpdateEmployee(int id, string name, int age, string address, int salary)
        {
            Model.Employee employee = new Model.Employee { Id = id, Name = name, Age = age, Salary = salary, Address = address }; try
            {
                Model.Employee emp = new Model.Employee(); emp = db.Employees.Where(x => x.Id == employee.Id).FirstOrDefault(); emp.Name = employee.Name; emp.Age = employee.Age; emp.Address = employee.Address; emp.Salary = employee.Salary; db.SaveChanges(); return "Employee Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [WebMethod]
        public string DeleteEmployee(int id)
        {
            try
            {
                Model.Employee emp = new Model.Employee(); emp = db.Employees.Where(x => x.Id == id).FirstOrDefault(); db.Employees.Remove(emp); db.SaveChanges(); return "Employee Deleted Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
