using ChamCong2.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamCong2.Data.Entities
{
    [Table("im_Task")]
    public class im_Task
    {
        [Key]
        public int TaskId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [MaxLength(50)]
        public string? Note { get; set; }
        [StringLength(50)]
        [Required]
        public StatusTask TypeTask { get; set; }
        [StringLength(50)]
        [Required]
        public bool IsComplete { get; set; }
        [StringLength(50)]
        [Required]
        public int? PlanId { get; set; }
        [ForeignKey("PlanId")]
        public im_Plan Plan { get; set; }
    }
}
