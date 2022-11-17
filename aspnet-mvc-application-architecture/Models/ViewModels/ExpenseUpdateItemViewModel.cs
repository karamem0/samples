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

    public class ExpenseUpdateItemViewModel
    {

        public ExpenseUpdateItemViewModel()
        {
        }

        public Guid Id { get; set; }

        [Display(Name = "Employee")]
        public string EmployeeName { get; set; }

        [Display(Name = "Job Title")]
        public string JobTitleName { get; set; }

        [Display(Name = "Period")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime PeriodDate { get; set; }

        [Required()]
        public DateTime? Date { get; set; }

        [MaxLength(255)]
        [Required()]
        public string Name { get; set; }

        [Required()]
        public decimal? Amount { get; set; }

        public byte[] RowVersion { get; set; }

    }

}
