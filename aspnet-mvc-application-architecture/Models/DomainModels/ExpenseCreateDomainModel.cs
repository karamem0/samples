using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.DomainModels
{

    public class ExpenseCreateDomainModel
    {

        public ExpenseCreateDomainModel()
        {
        }

        public Guid EmployeeId { get; set; }

        public Guid PeriodId { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

    }

}
