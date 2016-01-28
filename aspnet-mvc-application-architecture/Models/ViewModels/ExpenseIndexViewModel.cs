using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.ViewModels
{

    public class ExpenseIndexViewModel
    {

        public ExpenseIndexViewModel()
        {
        }

        public IReadOnlyList<SelectListItem> Employees { get; set; }

        public IReadOnlyList<SelectListItem> Periods { get; set; }

        public ExpenseIndexConditionViewModel Condition { get; set; }

        public IReadOnlyList<ExpenseIndexItemViewModel> Items { get; set; }

    }

}
