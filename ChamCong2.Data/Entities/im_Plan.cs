using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamCong2.Data.Entities
{
    [Table("im_Plan")]
    public class im_Plan
    {
        [Key]
        public int PlanId { get; set; }
        [StringLength(50)]
        [Required]
        public bool IsLate { get; set; }
        [StringLength(50)]
        [Required]
        public float CompletionPercentage { get; set; }
        [StringLength(50)]
        [Required]
        public int TotalTaskPlannedCount { get; set; }
        [StringLength(50)]
        [Required]
        public int TotalTaskComplete { get; set; }
        [StringLength(50)]
        [Required]
        public int TotalTaskOutStandingCount { get; set; }
        [StringLength(50)]
        [Required]
        public int TotalTimeWorkCount { get; set; }
        [StringLength(50)]
        [Required]
        public DateTime TimeCheckIn { get; set; }
        [StringLength(50)]
        [Required]
        public DateTime TimeCheckOut { get; set; }
        public List<im_Task> TaskListCode { get; set; }
        [StringLength(50)]
        [Required]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public im_User user { get; set; }

    }
}
