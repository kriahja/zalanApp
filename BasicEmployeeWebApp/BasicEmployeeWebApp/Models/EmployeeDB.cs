using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEmployeeWebApp.Models
{
    public class EmployeeDB
    {
        private static EmployeeDB instance;
        private static int ID = 1;
        private List<Employee> employees;
       
        private EmployeeDB() {
            employees = new List<Employee>();
            employees.Add(new Employee() {
                Id = ID++,
                Name = "Ole Olsen",
                Birthdate = DateTime.Now.AddYears(-35),
                Salary = 35000d,
                HireDate = DateTime.Now.AddYears(-2).AddMonths(-4).AddDays(-20),
                Type = EmployeeTypeDB.GetInstance().FindEmployeeType(1),
                Status = EmployeeStatusDB.GetInstance().FindEmployeeStatus(2)
            });
            employees.Add(new Employee()
            {
                Id = ID++,
                Name = "Peter Povlsen",
                Birthdate = DateTime.Now.AddYears(-28),
                Salary = 45000d,
                HireDate = DateTime.Now.AddYears(-4).AddMonths(-7),
                Type = EmployeeTypeDB.GetInstance().FindEmployeeType(2),
                Status = EmployeeStatusDB.GetInstance().FindEmployeeStatus(1),
            });
        }

        internal void UpdateEmployee(Employee employee)
        {
            var dbEmployee = FindEmployee(employee.Id);
            dbEmployee.Birthdate = employee.Birthdate;
            dbEmployee.HireDate = employee.HireDate;
            dbEmployee.Name = employee.Name;
            dbEmployee.Salary = employee.Salary;
            dbEmployee.Type = employee.Type;
        }

        internal Employee FindEmployee(int employeeId)
        {

            /*foreach (var item in employees)
            {
                if (item.Id == employeeId) {
                    return item;
                }
            }
            return null;
            */
            return employees.FirstOrDefault(item => item.Id == employeeId);
        }

        internal void DeleteEmployee(int employeeId)
        {
            Employee empl = null;
            foreach (var item in GetEmployees())
            {
                if (employeeId == item.Id) {
                    empl = item;
                }

            }
            GetEmployees().Remove(empl);
        }
        
        internal void AddEmployee(Employee employee)
        {
            employee.Id = ID++;
            employees.Add(employee);
        }

        public static EmployeeDB GetInstance() {
            if (instance == null) {
                instance = new EmployeeDB();
            }
            return instance;
        }
        
        public List<Employee> GetEmployees(bool asc = true)
        {
            if (asc) {
                return employees.OrderBy(e => e.Name).ToList();
            }
            return employees.OrderByDescending(e => e.Name).ToList();
        }
    }
}