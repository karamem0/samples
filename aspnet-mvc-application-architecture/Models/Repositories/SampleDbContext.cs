//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.EntityFrameworkCore;
using SampleApplication.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models.Repositories
{

    public class SampleDbContext : DbContext
    {

        public SampleDbContext(DbContextOptions<SampleDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<DepartmentEntityModel> Departments { get; set; }

        public virtual DbSet<EmployeeEntityModel> Employees { get; set; }

        public virtual DbSet<ExpenseEntityModel> Expenses { get; set; }

        public virtual DbSet<JobTitleEntityModel> JobTitles { get; set; }

        public virtual DbSet<PeriodEntityModel> Periods { get; set; }

    }

}
