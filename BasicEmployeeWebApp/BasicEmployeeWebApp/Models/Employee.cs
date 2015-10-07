using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasicEmployeeWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeType Type { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}