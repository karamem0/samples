using AutoMapper;
using AutoMapper.QueryableExtensions;
using SampleApplication.Models.DomainModels;
using SampleApplication.Models.EntityModels;
using SampleApplication.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.Services
{

    public interface IExpenseService
    {

        Task<IEnumerable<EmployeeSelectDomainModel>> GetEmployeesAsync();

        Task<IEnumerable<PeriodSelectDomainModel>> GetPeriodsAsync();

        Task<IEnumerable<ExpenseSelectDomainModel>> GetExpensesAsync(Guid employeeId, Guid periodId);

        Task<ExpenseSelectDomainModel> GetExpenseAsync(Guid id);

        Task<bool> CreateExpenseAsync(ExpenseCreateDomainModel entity);

        Task<bool> UpdateExpenseAsync(ExpenseUpdateDomainModel entity);

        Task<bool> DeleteExpenseAsync(ExpenseDeleteDomainModel entity);

    }

    public class ExpenseService : IExpenseService
    {

        private readonly SampleDbContext dbContext;

        public ExpenseService(SampleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeSelectDomainModel>> GetEmployeesAsync()
        {
            return await this.dbContext.Employees
                .Where(entity => entity.BeginDate <= DateTime.Today)
                .Where(entity => entity.EndDate >= DateTime.Today)
                .OrderBy(entity => entity.Department.Name)
                .ThenBy(entity => entity.JobTitle.Rank)
                .ProjectTo<EmployeeSelectDomainModel>()
                .ToAsyncEnumerable()
                .ToList();
        }

        public async Task<IEnumerable<PeriodSelectDomainModel>> GetPeriodsAsync()
        {
            return await this.dbContext.Periods
                .OrderBy(entity => entity.Period)
                .ProjectTo<PeriodSelectDomainModel>()
                .ToAsyncEnumerable()
                .ToList();
        }

        public async Task<IEnumerable<ExpenseSelectDomainModel>> GetExpensesAsync(Guid employeeId, Guid periodId)
        {
            return await this.dbContext.Expenses
                .Where(entity => entity.EmployeeId == employeeId)
                .Where(entity => entity.PeriodId == periodId)
                .ProjectTo<ExpenseSelectDomainModel>()
                .ToAsyncEnumerable()
                .ToList();
        }

        public async Task<ExpenseSelectDomainModel> GetExpenseAsync(Guid id)
        {
            return await this.dbContext.Expenses
                .Where(entity => entity.Id == id)
                .ProjectTo<ExpenseSelectDomainModel>()
                .ToAsyncEnumerable()
                .SingleOrDefault();
        }

        public async Task<bool> CreateExpenseAsync(ExpenseCreateDomainModel domain)
        {
            var entity = Mapper.Map<ExpenseEntityModel>(domain);
            var period = await this.dbContext.Periods.FindAsync(domain.PeriodId);
            if (period.BeginDate > entity.Date || period.EndDate < entity.Date)
            {
                throw new ArgumentException($"The value '{domain.Date.ToString("MM-dd-yyyy")}' is not matches for Period.", nameof(domain.Date));
            }
            this.dbContext.Expenses.Add(entity);
            return Convert.ToBoolean(await this.dbContext.SaveChangesAsync());
        }

        public async Task<bool> UpdateExpenseAsync(ExpenseUpdateDomainModel domain)
        {
            var entity = await this.dbContext.Expenses.FindAsync(domain.Id);
            if (entity != null)
            {
                Mapper.Map(domain, entity);
                var period = await this.dbContext.Periods.FindAsync(entity.PeriodId);
                if (period.BeginDate > entity.Date || period.EndDate < entity.Date)
                {
                    throw new ArgumentException($"The value '{domain.Date.ToString("MM-dd-yyyy")}' is not matches for Period.", nameof(domain.Date));
                }
                this.dbContext.Update(entity);
                return Convert.ToBoolean(await this.dbContext.SaveChangesAsync());
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteExpenseAsync(ExpenseDeleteDomainModel domain)
        {
            var entity = await this.dbContext.Expenses.FindAsync(domain.Id);
            if (entity != null)
            {
                Mapper.Map(domain, entity);
                this.dbContext.Remove(entity);
                return Convert.ToBoolean(await this.dbContext.SaveChangesAsync());
            }
            else
            {
                return false;
            }
        }

    }

}
