//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Beef.Data.EntityFrameworkCore;

namespace Karamem0.SampleApplication.Business.Data
{
    /// <summary>
    /// Represents the <b>Karamem0.SampleApplication</b> database using Entity Framework.
    /// </summary>
    public class SampleApplicationEfDb : EfDbBase<SampleApplicationEfDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleApplicationEfDb"/> class.
        /// </summary>
        /// <param name="dbContext">The entity framework database context.</param>
        public SampleApplicationEfDb(SampleApplicationEfDbContext dbContext) : base(dbContext) { }
    }
}
