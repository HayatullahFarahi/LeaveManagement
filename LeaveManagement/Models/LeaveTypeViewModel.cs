using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class LeaveTypeViewModel
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range ( 1 , 25, ErrorMessage = "Please enter A valid number between 1 and 25" ) ]
        [Display(Name = "Default Number of Days")]
        public int DefaultDays { get; set; }


        [Display(Name="Date Created")]
        public DateTime? DateCreated { get; set; }
    }


}


