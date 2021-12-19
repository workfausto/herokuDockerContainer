using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herokuDockerContainer_netCore.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }

        //
        //Navigation property Returns the Employee Address
        public virtual EmployeeAddress EmployeeAddress { get; set; }

        //Navigational Property to Department
        public Department Department { get; set; }
    }
}
