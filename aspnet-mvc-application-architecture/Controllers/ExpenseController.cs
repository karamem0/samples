using SampleApplication.Models.Facades;
using SampleApplication.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Controllers
{

    public class ExpenseController : Controller
    {

        private IEmployeeFacade employeeFacade;

        public ExpenseController(IEmployeeFacade employeeFacade)
        {
            this.employeeFacade = employeeFacade;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return this.View(await this.employeeFacade.GetExpenseIndexViewModelAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            var model = new ExpenseIndexConditionViewModel();
            if (await this.TryUpdateModelAsync(model, "Condition"))
            {
                return this.View(await this.employeeFacade.GetExpenseIndexViewModelAsync(model));
            }
            else
            {
                return this.View(await this.employeeFacade.GetExpenseIndexViewModelAsync());
            }
        }

        [HttpGet()]
        public async Task<IActionResult> Create()
        {
            return this.View(await this.employeeFacade.GetExpenseCreateViewModelAsync());
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
            var model = new ExpenseCreateItemViewModel();
            if (await this.TryUpdateModelAsync(model, "Item"))
            {
                try
                {
                    if (await this.employeeFacade.CreateExpenseAsync(model))
                    {
                        return this.RedirectToAction(nameof(this.Index));
                    }
                    else
                    {
                        return this.Forbid();
                    }
                }
                catch (ArgumentException ex)
                {
                    this.ModelState.AddModelError(ex.ParamName, ex.Message);
                }
            }
            return this.View(await this.employeeFacade.GetExpenseCreateViewModelAsync(model));
        }

        [HttpGet()]
        public async Task<IActionResult> Update(Guid id)
        {
            var model = await this.employeeFacade.GetExpenseUpdateItemViewModelAsync(id);
            if (model != null)
            {
                return this.View(model);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(IFormCollection collection)
        {
            var model = new ExpenseUpdateItemViewModel();
            if (await this.TryUpdateModelAsync(model))
            {
                try
                {
                    if (await this.employeeFacade.UpdateExpenseAsync(model))
                    {
                        return this.RedirectToAction(nameof(this.Index));
                    }
                    else
                    {
                        return this.NotFound();
                    }
                }
                catch (ArgumentException ex)
                {
                    this.ModelState.AddModelError(ex.ParamName, ex.Message);
                }
            }
            return this.View(model);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = await this.employeeFacade.GetExpenseDeleteItemViewModelAsync(id);
            if (model != null)
            {
                return this.View(model);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Delete(IFormCollection collection)
        {
            var model = new ExpenseDeleteItemViewModel();
            if (await this.TryUpdateModelAsync(model))
            {
                if (await this.employeeFacade.DeleteExpenseAsync(model))
                {
                    return this.RedirectToAction(nameof(this.Index));
                }
                else
                {
                    return this.NotFound();
                }
            }
            else
            {
                return this.Forbid();
            }
        }

    }

}
