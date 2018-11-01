using Microsoft.EntityFrameworkCore;

namespace HomeAPI.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options)
        {
        }

        public DbSet<HomeItem> Homes { get; set; }
        public DbSet<DeviceItem> Devices { get; set; }
        public DbSet<DeviceTypeItem> DevicesTypes { get; set; }
    }
}