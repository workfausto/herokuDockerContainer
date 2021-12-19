using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herokuDockerContainer_netCore.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        //Navigational Property Returns List of Employees
        public ICollection<Employee> Employees { get; set; }
    }
}
