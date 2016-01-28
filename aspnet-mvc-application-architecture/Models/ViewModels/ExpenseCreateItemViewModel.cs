using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.ViewModels
{

    public class ExpenseCreateItemViewModel
    {

        public ExpenseCreateItemViewModel()
        {
        }

        [Display(Name = "Employee")]
        [Required()]
        public Guid? EmployeeId { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitleName { get; set; }

        [Display(Name = "Period")]
        [Required()]
        public Guid? PeriodId { get; set; }

        [Required()]
        public DateTime? Date { get; set; }

        [MaxLength(255)]
        [Required()]
        public string Name { get; set; }

        [Required()]
        public decimal? Amount { get; set; }

    }

}
