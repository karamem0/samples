using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.ViewModels
{

    public class ExpenseCreateViewModel
    {

        public ExpenseCreateViewModel()
        {
        }

        public IReadOnlyList<SelectListItem> Employees { get; set; }

        public IReadOnlyList<SelectListItem> Periods { get; set; }

        public ExpenseCreateItemViewModel Item { get; set; }

    }

}
