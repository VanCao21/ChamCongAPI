using ChamCong1.API.Dtos;
using ChamCong2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong2.API.Models
{
    public interface IInterfaceRepository
    {
        Task<IEnumerable<im_User>> GetUsers();
        Task<im_User> GetUser(int UserID);
        Task<im_User> CheckIn(CreatePlan createPlan);
        Task<im_User> CheckOut(int id, PlanCheckout checkout);
        Task<PagedList<TimeSheetViewModel>> GetAllPaging(int id, int size, int page);
        

    }
}
