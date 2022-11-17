//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SampleApplication.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models.Repositories
{

    public static class SeededExtensions
    {

        public static IApplicationBuilder UseSeeded(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<SampleDbContext>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                dbContext.JobTitles.AddRange(
                    new[]
                    {
                        new JobTitleEntityModel()
                        {
                            Name = "President",
                            Rank = 1,
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new JobTitleEntityModel()
                        {
                            Name = "Director",
                            Rank = 5,
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new JobTitleEntityModel()
                        {
                            Name = "General Manager",
                            Rank = 6,
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new JobTitleEntityModel()
                        {
                            Name = "Manager",
                            Rank = 7,
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new JobTitleEntityModel()
                        {
                            Name = "Leader",
                            Rank = 8,
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new JobTitleEntityModel()
                        {
                            Name = "Staff",
                            Rank = 9,
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                    }
                );
                dbContext.SaveChanges();
                dbContext.Departments.AddRange(
                    new[]
                    {
                        new DepartmentEntityModel()
                        {
                            Name = "Executive",
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new DepartmentEntityModel()
                        {
                            Name = "Sales",
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new DepartmentEntityModel()
                        {
                            Name = "General Affairs",
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new DepartmentEntityModel()
                        {
                            Name = "Human Resource",
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new DepartmentEntityModel()
                        {
                            Name = "Finance",
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                    }
                );
                dbContext.SaveChanges();
                dbContext.Employees.AddRange(
                    new[]
                    {
                        new EmployeeEntityModel()
                        {
                            Name = "Shu Watanabe",
                            JobTitle = dbContext.JobTitles.Single(e => e.Name == "President"),
                            Department = dbContext.Departments.Single(e => e.Name == "Executive"),
                            BeginDate = new DateTime(2000, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new EmployeeEntityModel()
                        {
                            Name = "Ryosuke Miura",
                            JobTitle = dbContext.JobTitles.Single(e => e.Name == "Manager"),
                            Department = dbContext.Departments.Single(e => e.Name == "Sales"),
                            BeginDate = new DateTime(2005, 7, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new EmployeeEntityModel()
                        {
                            Name = "Riho Takada",
                            JobTitle = dbContext.JobTitles.Single(e => e.Name == "Manager"),
                            Department = dbContext.Departments.Single(e => e.Name == "General Affairs"),
                            BeginDate = new DateTime(2004, 9, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new EmployeeEntityModel()
                        {
                            Name = "Asaya Kimijima",
                            JobTitle = dbContext.JobTitles.Single(e => e.Name == "Staff"),
                            Department = dbContext.Departments.Single(e => e.Name == "General Affairs"),
                            BeginDate = new DateTime(2017, 1, 1),
                            EndDate = new DateTime(2099, 12, 31),
                        },
                        new EmployeeEntityModel()
                        {
                            Name = "Hiroaki Iwanaga",
                            JobTitle = dbContext.JobTitles.Single(e => e.Name == "Staff"),
                            Department = dbContext.Departments.Single(e => e.Name == "General Affairs"),
                            BeginDate = new DateTime(2016, 5, 1),
                            EndDate = new DateTime(2017, 12, 31),
                        },
                        new EmployeeEntityModel()
                        {
                            Name = "Takashi Ukaji",
                            JobTitle = dbContext.JobTitles.Single(e => e.Name == "Staff"),
                            Department = dbContext.Departments.Single(e => e.Name == "Finance"),
                            BeginDate = new DateTime(2008, 10, 1),
                            EndDate = new DateTime(2010, 3, 31),
                        },
                    }
                );
                dbContext.SaveChanges();
                dbContext.Periods.AddRange(
                    new[]
                    {
                        new PeriodEntityModel()
                        {
                            Period = new DateTime(2018, 1, 1),
                            BeginDate = new DateTime(2018, 1, 1),
                            EndDate = new DateTime(2018, 1, 31),
                        },
                        new PeriodEntityModel()
                        {
                            Period = new DateTime(2018, 2, 1),
                            BeginDate = new DateTime(2018, 2, 1),
                            EndDate = new DateTime(2018, 2, 28),
                        },
                        new PeriodEntityModel()
                        {
                            Period = new DateTime(2018, 3, 1),
                            BeginDate = new DateTime(2018, 3, 1),
                            EndDate = new DateTime(2018, 3, 31),
                        },
                        new PeriodEntityModel()
                        {
                            Period = new DateTime(2018, 4, 1),
                            BeginDate = new DateTime(2018, 4, 1),
                            EndDate = new DateTime(2018, 4, 30),
                        },
                    }
                );
                dbContext.SaveChanges();
                dbContext.Expenses.AddRange(
                    new[]
                    {
                        new ExpenseEntityModel()
                        {
                            Employee = dbContext.Employees.Single(e => e.Name == "Shu Watanabe"),
                            Period = dbContext.Periods.Single(e => e.Period == new DateTime(2018, 1, 1)),
                            Name = "Transport (Taxi)",
                            Date =  new DateTime(2018, 1, 15),
                            Amount = 10000M,
                        },
                        new ExpenseEntityModel()
                        {
                            Employee = dbContext.Employees.Single(e => e.Name == "Shu Watanabe"),
                            Period = dbContext.Periods.Single(e => e.Period == new DateTime(2018, 1, 1)),
                            Name = "Entertainment",
                            Date =  new DateTime(2018, 1, 25),
                            Amount = 65000M,
                        },
                        new ExpenseEntityModel()
                        {
                            Employee = dbContext.Employees.Single(e => e.Name == "Shu Watanabe"),
                            Period = dbContext.Periods.Single(e => e.Period == new DateTime(2018, 2, 1)),
                            Name = "Transport (Taxi)",
                            Date =  new DateTime(2018, 2, 20),
                            Amount = 3250M,
                        },
                        new ExpenseEntityModel()
                        {
                            Employee = dbContext.Employees.Single(e => e.Name == "Shu Watanabe"),
                            Period = dbContext.Periods.Single(e => e.Period == new DateTime(2018, 3, 1)),
                            Name = "Hotel",
                            Date =  new DateTime(2018, 3, 5),
                            Amount = 15000M,
                        }
                    }
                );
                dbContext.SaveChanges();
            }
            return app;
        }

    }

}
