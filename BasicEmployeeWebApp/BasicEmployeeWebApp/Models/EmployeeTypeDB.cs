using System.Collections.Generic;

namespace BasicEmployeeWebApp.Models
{
    public class EmployeeTypeDB
    {
        private static EmployeeTypeDB instance;
        private static int ID = 1;
        private List<EmployeeType> employeeTypes;
        private EmployeeTypeDB()
        {
            employeeTypes = new List<EmployeeType>();
            employeeTypes.Add(new EmployeeType()
            {
                Id = ID++,
                Name = "FullTime"
            });
            employeeTypes.Add(new EmployeeType()
            {
                Id = ID++,
                Name = "Consultant"
            });
        }

        internal void UpdateEmployeeType(EmployeeType employeeType)
        {
            var dbEmployeeType = FindEmployeeType(employeeType.Id);
            dbEmployeeType.Name = employeeType.Name;
        }

        internal EmployeeType FindEmployeeType(int employeeTypeId)
        {
            foreach (var item in GetEmployeeTypes())
            {
                if (item.Id == employeeTypeId)
                {
                    return item;
                }

            }
            return null;
        }

        internal void DeleteEmployeeType(int employeeTypeId)
        {
            EmployeeType emplT = null;
            foreach (var item in GetEmployeeTypes())
            {
                if (employeeTypeId == item.Id)
                {
                    emplT = item;
                }

            }
            GetEmployeeTypes().Remove(emplT);
        }

        internal void AddEmployeeType(EmployeeType employeeType)
        {
            employeeType.Id = ID++;
            GetEmployeeTypes().Add(employeeType);
        }

        public static EmployeeTypeDB GetInstance()
        {
            if (instance == null)
            {
                instance = new EmployeeTypeDB();
            }
            return instance;
        }

        public List<EmployeeType> GetEmployeeTypes()
        {
            return employeeTypes;
        }

    }
}