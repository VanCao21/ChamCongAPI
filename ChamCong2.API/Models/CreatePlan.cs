using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong2.API.Models
{
    public class CreatePlan
    {
        public int id { get; set; }
        public List<TaskCheckin> PlanList { get; set; }
    }
    public class TaskCheckin
    {
        public string titile { get; set; }
    }
    public class PlanCheckout
    {
        public int id { get; set; }
        public List<TaskCheckout> PlanListCheckout { get; set; }
    }
    public class TaskCheckout
    {
        public string titile { get; set; }
        public string? note { get; set; }

        public bool completionschedule { get; set; }
    }
    public class TimeSheetViewModel
    {
        public Guid Id { get; set; }
        public float CompletionPercentage { get; set; }
        public int TotalTaskPlannedCount { get; set; }
        public int TotalTaskComplete { get; set; }
        public int TotalTaskOutStandingCount { get; set; }
        public int TotalTimeWorkCount { get; set; }
        public DateTime TimeCheckIn { get; set; }
        public DateTime TimeCheckOut { get; set; }
    }
}
