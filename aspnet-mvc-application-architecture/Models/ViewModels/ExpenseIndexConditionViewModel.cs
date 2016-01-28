using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.ViewModels
{

    public class ExpenseIndexConditionViewModel
    {

        public ExpenseIndexConditionViewModel()
        {
        }

        [Display(Name = "Employee")]
        [Required()]
        public Guid? EmployeeId { get; set; }

        [Display(Name = "Period")]
        [Required()]
        public Guid? PeriodId { get; set; }

    }

}
