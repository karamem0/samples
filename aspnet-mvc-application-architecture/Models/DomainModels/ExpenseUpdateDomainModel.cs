using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.DomainModels
{

    public class ExpenseUpdateDomainModel
    {

        public ExpenseUpdateDomainModel()
        {
        }

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public byte[] RowVersion { get; set; }

    }

}
