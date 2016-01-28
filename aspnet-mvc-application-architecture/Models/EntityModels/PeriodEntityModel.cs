using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.EntityModels
{

    [Table("period")]
    public class PeriodEntityModel
    {

        public PeriodEntityModel()
        {
        }

        [Column("id")]
        [Key()]
        public virtual Guid Id { get; set; }

        [Column("period")]
        public virtual DateTime Period { get; set; }

        [Column("begin_date", TypeName = "date")]
        public virtual DateTime BeginDate { get; set; }

        [Column("end_date", TypeName = "date")]
        public virtual DateTime EndDate { get; set; }

        [Column("rowversion")]
        [Timestamp()]
        public virtual byte[] RowVersion { get; set; }

        public virtual ICollection<ExpenseEntityModel> Expenses { get; set; }

    }

}
