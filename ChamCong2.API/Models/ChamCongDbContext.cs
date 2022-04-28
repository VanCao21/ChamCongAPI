using ChamCong2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong2.API.Models
{
    public class ChamCongDbContext : DbContext
    {
        public ChamCongDbContext(DbContextOptions<ChamCongDbContext> options)
           : base(options)
        {

        }
        public DbSet<im_Task> im_Tasks { get; set; }
        public DbSet<im_Plan> im_Plans { get; set; }
        public DbSet<im_User> im_Users { get; set; }

    }
}
