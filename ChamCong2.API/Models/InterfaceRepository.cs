using ChamCong1.API.Dtos;
using ChamCong2.Data.Entities;
using ChamCong2.Data.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong2.API.Models
{
    public class InterfaceRepository : IInterfaceRepository
    {
        private readonly ChamCongDbContext chamCongDbContext;

        public InterfaceRepository(ChamCongDbContext chamCongDbContext)
        {
            this.chamCongDbContext = chamCongDbContext;
        }
        public async Task<im_User> CheckIn(CreatePlan createPlan)
        {
            var user = chamCongDbContext.im_Users.SingleOrDefault(p => p.UserID == createPlan.id);
            if (user != null)
            {
                var plan = new im_Plan()
                {
                    UserId = new int(),
                    TimeCheckIn = DateTime.Now,
                  
                };
                if (DateTime.Now.Hour >= 9)
                {
                    plan.IsLate = true;
                }
                else
                {
                    plan.IsLate = false;
                }
                plan.TaskListCode = new List<im_Task>();
                foreach (var item in createPlan.PlanList)
                {
                    var task1 = new im_Task()
                    {
                        TaskId = new int(),
                        Title = item.titile,
                        Note = "",
                        TypeTask = StatusTask.none,
                        IsComplete = false
                    };
                    plan.TaskListCode.Add(task1);
                }
                chamCongDbContext.im_Plans.Add(plan);
                await chamCongDbContext.SaveChangesAsync();
                return null;
            }
            else
            {
                Log.Error("lỗi");
                return null;
            }
        }

        public async Task<im_User> CheckOut(int id, PlanCheckout checkout)
        {
            var user = await chamCongDbContext.im_Users.SingleOrDefaultAsync(p => p.UserID == id);
            if (user == null)
            {
                Log.Error("không có người dùng này");
                return null;
            }
            //kiểm tra xem đã check in chưa
            var plancheckout = await chamCongDbContext.im_Plans.Where(p => p.UserId == id && p.TimeCheckIn.Date == DateTime.Now.Date).FirstOrDefaultAsync();
            if (plancheckout == null)
            {
                Log.Error($"{id} chưa checkin");
                return null;
            }
            var time = DateTime.Now;
            if (time.Subtract(plancheckout.TimeCheckIn).Hours < 8)
            {
                Log.Error("Bạn chưa làm đủ thời gian yêu cầu");
                return null;
            }
            plancheckout.TimeCheckOut = DateTime.Now;
            foreach (var item in checkout.PlanListCheckout)
            {
                var taskcheckout = chamCongDbContext.im_Tasks.Where(p => p.Title.ToLower().Trim() == item.titile.ToLower().Trim()).FirstOrDefault();
                if (taskcheckout == null)
                {
                    var tasknew = new im_Task()
                    {
                        TaskId = new int(),
                        Title = item.titile,
                        Note = item.note,
                        TypeTask = StatusTask.none,
                        IsComplete = item.completionschedule,
                        PlanId = plancheckout.PlanId
                    };
                    if (item.completionschedule == true)
                    {
                        tasknew.Note = "";
                    }
                    else
                    {
                        tasknew.Note = item.note;
                    }
                    await chamCongDbContext.im_Tasks.AddAsync(tasknew);
                }
                else
                {
                    taskcheckout.IsComplete = item.completionschedule;
                    if (taskcheckout.IsComplete)
                    {
                        taskcheckout.Note = "";
                    }
                    else
                    {
                        taskcheckout.Note = item.note;
                    }
                }
            }
            await chamCongDbContext.SaveChangesAsync();
            plancheckout.TotalTimeWorkCount = time.Subtract(plancheckout.TimeCheckIn).Hours;
            plancheckout.TotalTaskPlannedCount = chamCongDbContext.im_Tasks.Where(p => p.TypeTask == StatusTask.Planned && p.PlanId == plancheckout.PlanId).Count();
            plancheckout.TotalTaskOutStandingCount = chamCongDbContext.im_Tasks.Where(p => p.TypeTask == StatusTask.Outstanding && p.PlanId == plancheckout.PlanId).Count();
            plancheckout.TotalTaskComplete = chamCongDbContext.im_Tasks.Where(p => p.IsComplete == true && p.PlanId == plancheckout.PlanId).Count();
            await chamCongDbContext.SaveChangesAsync();
            return null;
        }

        public async Task<PagedList<TimeSheetViewModel>> GetAllPaging(int id, int size, int page)
        {
            var checkiduser = await chamCongDbContext.im_Users.SingleOrDefaultAsync(p => p.UserID == id);
            if(checkiduser !=null)
            {
                var listplan =  chamCongDbContext.im_Plans.Where(p => p.UserId == id);
                return PagedList<TimeSheetViewModel>.ToPagedList((IQueryable<TimeSheetViewModel>)listplan, page, size);
            }
            else
            {
                Log.Error($"No user with id ={id}");
                return null;
            }
        }
        public async Task<im_User> GetUser(int UserID)
        {
            return await chamCongDbContext.im_Users
               .FirstOrDefaultAsync(e => e.UserID == UserID);
        }

        public async Task<IEnumerable<im_User>> GetUsers()
        {
            return await chamCongDbContext.im_Users.ToListAsync();
        }
    }
}
