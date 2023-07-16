using Microsoft.EntityFrameworkCore;
using TruckBlazorWebAssembly.Shared;

namespace TruckBlazorWebAssembly.Server.Model
{
    public class TruckContext : DbContext
    {
        
        public TruckContext(DbContextOptions<TruckContext> options) : base(options)
        {
        }

        public virtual DbSet<Truck>? Trucks { get; set; } =null;


    }
}
