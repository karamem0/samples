using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.DomainModels
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
