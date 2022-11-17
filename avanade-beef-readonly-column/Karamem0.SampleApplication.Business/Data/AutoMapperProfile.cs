//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Reflection;
using AutoMapper;
using Karamem0.SampleApplication.Business.Entities;

namespace Toyota.SouiKufuApp.Business.Data
{
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Gets the <i>Beef</i> <see cref="AutoMapperProfile"/> <see cref="System.Reflection.Assembly"/>.
        /// </summary>
        public static Assembly Assembly => typeof(AutoMapperProfile).Assembly;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<ProductPrice, Product>();
        }
    }
}
