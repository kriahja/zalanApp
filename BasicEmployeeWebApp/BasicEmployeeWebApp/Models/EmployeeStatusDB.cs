using System.Collections.Generic;

namespace BasicEmployeeWebApp.Models
{
    public class EmployeeStatusDB
    {
        private static EmployeeStatusDB instance;
        private static int ID = 1;
        private List<EmployeeStatus> employeeStatuses;
        private EmployeeStatusDB()
        {
            employeeStatuses = new List<EmployeeStatus>();
            employeeStatuses.Add(new EmployeeStatus()
            {
                Id = ID++,
                Name = "In Jail"
            });
            employeeStatuses.Add(new EmployeeStatus()
            {
                Id = ID++,
                Name = "Ready for Work"
            });
        }
        

        internal EmployeeStatus FindEmployeeStatus(int employeeStatusId)
        {
            foreach (var item in GetEmployeeStatuses())
            {
                if (item.Id == employeeStatusId)
                {
                    return item;
                }

            }
            return null;
        }
        internal void AddEmployeeStatus(EmployeeStatus employeeStatus)
        {
            employeeStatus.Id = ID++;
            GetEmployeeStatuses().Add(employeeStatus);
        }

        public static EmployeeStatusDB GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeStatusDB();
            }
            return instance;
        }

        public List<EmployeeStatus> GetEmployeeStatuses()
        {
            return employeeStatuses;
        }

    }
}