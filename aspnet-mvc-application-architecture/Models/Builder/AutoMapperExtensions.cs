using AutoMapper;
using SampleApplication.Models.DomainModels;
using SampleApplication.Models.EntityModels;
using SampleApplication.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.Builder
{

    public static class AutoMapperExtensions
    {

        public static IApplicationBuilder UseAutoMapper(this IApplicationBuilder app)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeEntityModel, EmployeeSelectDomainModel>();
                config.CreateMap<PeriodEntityModel, PeriodSelectDomainModel>();
                config.CreateMap<ExpenseEntityModel, ExpenseSelectDomainModel>()
                    .ForMember(d => d.EmployeeName, o => o.MapFrom(s => s.Employee.Name))
                    .ForMember(d => d.JobTitleName, o => o.MapFrom(s => s.Employee.JobTitle.Name))
                    .ForMember(d => d.PeriodDate, o => o.MapFrom(s => s.Period.Period));
                config.CreateMap<ExpenseCreateDomainModel, ExpenseEntityModel>();
                config.CreateMap<ExpenseUpdateDomainModel, ExpenseEntityModel>();
                config.CreateMap<ExpenseDeleteDomainModel, ExpenseEntityModel>();
                config.CreateMap<EmployeeSelectDomainModel, SelectListItem>()
                    .ForMember(d => d.Value, o => o.MapFrom(s => s.Id.ToString()))
                    .ForMember(d => d.Text, o => o.MapFrom(s => s.Name));
                config.CreateMap<PeriodSelectDomainModel, SelectListItem>()
                    .ForMember(d => d.Value, o => o.MapFrom(s => s.Id.ToString()))
                    .ForMember(d => d.Text, o => o.MapFrom(s => s.Period.ToString("MM-dd-yyyy")));
                config.CreateMap<ExpenseSelectDomainModel, ExpenseIndexItemViewModel>();
                config.CreateMap<ExpenseSelectDomainModel, ExpenseCreateItemViewModel>();
                config.CreateMap<ExpenseSelectDomainModel, ExpenseUpdateItemViewModel>();
                config.CreateMap<ExpenseSelectDomainModel, ExpenseDeleteItemViewModel>();
                config.CreateMap<ExpenseCreateItemViewModel, ExpenseCreateDomainModel>();
                config.CreateMap<ExpenseUpdateItemViewModel, ExpenseUpdateDomainModel>();
                config.CreateMap<ExpenseDeleteItemViewModel, ExpenseDeleteDomainModel>();
            });
            return app;
        }

    }

}
