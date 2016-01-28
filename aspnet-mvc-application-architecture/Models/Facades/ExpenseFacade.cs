using AutoMapper;
using SampleApplication.Models.DomainModels;
using SampleApplication.Models.Services;
using SampleApplication.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.Facades
{

    public interface IEmployeeFacade
    {

        Task<ExpenseIndexViewModel> GetExpenseIndexViewModelAsync();

        Task<ExpenseIndexViewModel> GetExpenseIndexViewModelAsync(ExpenseIndexConditionViewModel model);

        Task<ExpenseCreateViewModel> GetExpenseCreateViewModelAsync();

        Task<ExpenseCreateViewModel> GetExpenseCreateViewModelAsync(Guid id);

        Task<ExpenseCreateViewModel> GetExpenseCreateViewModelAsync(ExpenseCreateItemViewModel model);

        Task<ExpenseUpdateItemViewModel> GetExpenseUpdateItemViewModelAsync(Guid id);

        Task<ExpenseDeleteItemViewModel> GetExpenseDeleteItemViewModelAsync(Guid id);

        Task<bool> CreateExpenseAsync(ExpenseCreateItemViewModel model);

        Task<bool> UpdateExpenseAsync(ExpenseUpdateItemViewModel model);

        Task<bool> DeleteExpenseAsync(ExpenseDeleteItemViewModel model);

    }

    public class ExpenseFacade : IEmployeeFacade
    {

        private readonly IExpenseService expenseService;

        public ExpenseFacade(IExpenseService expenseService)
        {
            this.expenseService = expenseService;
        }

        public async Task<ExpenseIndexViewModel> GetExpenseIndexViewModelAsync()
        {
            return await this.GetExpenseIndexViewModelAsync(null);
        }

        public async Task<ExpenseIndexViewModel> GetExpenseIndexViewModelAsync(ExpenseIndexConditionViewModel model)
        {
            return new ExpenseIndexViewModel()
            {
                Employees = Mapper.Map<IReadOnlyList<SelectListItem>>(await this.expenseService.GetEmployeesAsync()),
                Periods = Mapper.Map<IReadOnlyList<SelectListItem>>(await this.expenseService.GetPeriodsAsync()),
                Condition = model,
                Items = (model == null)
                    ? new List<ExpenseIndexItemViewModel>()
                    : Mapper.Map<IReadOnlyList<ExpenseIndexItemViewModel>>(
                        await this.expenseService.GetExpensesAsync(model.EmployeeId.Value, model.PeriodId.Value))
            };
        }

        public async Task<ExpenseCreateViewModel> GetExpenseCreateViewModelAsync()
        {
            return await this.GetExpenseCreateViewModelAsync(null);
        }

        public async Task<ExpenseCreateViewModel> GetExpenseCreateViewModelAsync(Guid id)
        {
            return await this.GetExpenseCreateViewModelAsync(Mapper.Map<ExpenseCreateItemViewModel>(await this.expenseService.GetExpenseAsync(id)));
        }

        public async Task<ExpenseCreateViewModel> GetExpenseCreateViewModelAsync(ExpenseCreateItemViewModel model)
        {
            return new ExpenseCreateViewModel()
            {
                Employees = Mapper.Map<IReadOnlyList<SelectListItem>>(await this.expenseService.GetEmployeesAsync()),
                Periods = Mapper.Map<IReadOnlyList<SelectListItem>>(await this.expenseService.GetPeriodsAsync()),
                Item = model,
            };
        }

        public async Task<ExpenseUpdateItemViewModel> GetExpenseUpdateItemViewModelAsync(Guid id)
        {
            return Mapper.Map<ExpenseUpdateItemViewModel>(await this.expenseService.GetExpenseAsync(id));
        }

        public async Task<ExpenseDeleteItemViewModel> GetExpenseDeleteItemViewModelAsync(Guid id)
        {
            return Mapper.Map<ExpenseDeleteItemViewModel>(await this.expenseService.GetExpenseAsync(id));
        }

        public async Task<bool> CreateExpenseAsync(ExpenseCreateItemViewModel model)
        {
            return await this.expenseService.CreateExpenseAsync(Mapper.Map<ExpenseCreateDomainModel>(model));
        }

        public async Task<bool> UpdateExpenseAsync(ExpenseUpdateItemViewModel model)
        {
            return await this.expenseService.UpdateExpenseAsync(Mapper.Map<ExpenseUpdateDomainModel>(model));
        }

        public async Task<bool> DeleteExpenseAsync(ExpenseDeleteItemViewModel model)
        {
            return await this.expenseService.DeleteExpenseAsync(Mapper.Map<ExpenseDeleteDomainModel>(model));
        }

    }

}
