//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models.ViewModels
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
