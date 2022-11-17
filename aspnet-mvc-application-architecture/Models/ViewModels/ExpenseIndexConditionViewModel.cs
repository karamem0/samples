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
