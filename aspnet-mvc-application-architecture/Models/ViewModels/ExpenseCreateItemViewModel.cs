//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models.ViewModels
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
