using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Models.EntityModels
{

    [Table("expense")]
    public class ExpenseEntityModel
    {

        public ExpenseEntityModel()
        {
        }

        [Column("id")]
        [Key()]
        public virtual Guid Id { get; set; }

        [Column("employee_id")]
        [ForeignKey("Employee")]
        public virtual Guid EmployeeId { get; set; }

        [Column("period_id")]
        [ForeignKey("Period")]
        public virtual Guid PeriodId { get; set; }

        [Column("date")]
        public virtual DateTime Date { get; set; }

        [Column("name")]
        [Required()]
        [StringLength(255)]
        public virtual string Name { get; set; }

        [Column("amount")]
        public virtual decimal Amount { get; set; }

        [Column("rowversion")]
        [Timestamp()]
        public virtual byte[] RowVersion { get; set; }

        public virtual PeriodEntityModel Period { get; set; }

        public virtual EmployeeEntityModel Employee { get; set; }

    }

}
