using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveAllocationViewModel
    {
       
        public int Id { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        public DateTime Date { get; set; }

        public EmployeeViewModel Employee { get; set; }

        //based on EmployeeId we can store the employee data in Employee Objects created in the above line
        public string EmployeeId { get; set; }
       
        public DetailsLeaveTypeViewModel LeaveType { get; set; }

        public int LeaveTypeId { get; set; }


        public IEnumerable<SelectListItem> Employees { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }


    }
}
