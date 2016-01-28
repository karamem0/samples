using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.DomainModels
{

    public class PeriodSelectDomainModel
    {

        public PeriodSelectDomainModel()
        {
        }

        public Guid Id { get; set; }

        public DateTime Period { get; set; }

    }

}
