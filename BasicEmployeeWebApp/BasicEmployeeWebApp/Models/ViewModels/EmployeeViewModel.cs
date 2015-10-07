using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicEmployeeWebApp.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel() {
            EmployeeTypes = new List<EmployeeType>();
            EmployeeStatuses = new List<EmployeeStatus>();
        }
        public Employee Employee { get; set; }
        public List<EmployeeType> EmployeeTypes { get; set; }
        public List<EmployeeStatus> EmployeeStatuses { get; set; }

    }
}