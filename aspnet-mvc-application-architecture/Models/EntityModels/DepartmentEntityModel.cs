//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models.EntityModels
{

    [Table("department")]
    public class DepartmentEntityModel
    {

        public DepartmentEntityModel()
        {
        }

        [Column("id")]
        [Key()]
        public virtual Guid Id { get; set; }

        [Column("name")]
        [Required()]
        [StringLength(255)]
        public virtual string Name { get; set; }

        [Column("begin_date", TypeName = "date")]
        public virtual DateTime BeginDate { get; set; }

        [Column("end_date", TypeName = "date")]
        public virtual DateTime EndDate { get; set; }

        [Column("rowversion")]
        [Timestamp()]
        public virtual byte[] RowVersion { get; set; }

        public virtual ICollection<EmployeeEntityModel> Employees { get; set; }

    }

}
