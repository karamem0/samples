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

    public class PeriodSelectDomainModel
    {

        public PeriodSelectDomainModel()
        {
        }

        public Guid Id { get; set; }

        public DateTime Period { get; set; }

    }

}
