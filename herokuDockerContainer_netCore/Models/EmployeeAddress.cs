using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace herokuDockerContainer_netCore.Models
{
    public class EmployeeAddress
    {
        public int EmployeeID { get; set; }
        public string Address { get; set; }

        //
        //Navigation property Returns the Employee object
        public virtual Employee Employee { get; set; }
    }
}
