using SampleApplication.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.Repositories
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
