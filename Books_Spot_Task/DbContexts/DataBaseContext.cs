using Books_Spot_Task.Entities;
using Books_Spot_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_Spot_Task.DbContexts
{
    public class DataBaseContext: DbContext
    {
        public DbSet<BookEntity> Books { get; set; } = null!;
        public DbSet<BookingEntity> Bookings { get; set; } = null!;
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<GenreEntity> Genres { get; set; } = null!;

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

    }
}
