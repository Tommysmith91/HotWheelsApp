using HotWheelsApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotWheelsDbContext
{
    public class HotWheelsCollectionDbContext : DbContext
    {
        private object options;

        public DbSet<HotWheel> HotWheel { get; set; }
        public HotWheelsCollectionDbContext(DbContextOptions<HotWheelsCollectionDbContext> options) : base(options)
        {
        }       
           
    }
}
