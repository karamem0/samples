//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models.DomainModels
{

    public class ExpenseSelectDomainModel
    {

        public ExpenseSelectDomainModel()
        {
        }

        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string JobTitleName { get; set; }

        public Guid PeriodId { get; set; }

        public DateTime PeriodDate { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public byte[] RowVersion { get; set; }

    }

}
