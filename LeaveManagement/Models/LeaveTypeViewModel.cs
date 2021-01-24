using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class DetailsLeaveTypeViewModel
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DataCreated { get; set; }
    }

    public class CreateLeaveType
    {
        [Required]
        public string Name { get; set; }

    }
}


