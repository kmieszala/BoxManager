using BoxManager.Model.DbSets;
using Microsoft.EntityFrameworkCore;

namespace BoxManager.Model;

public class BoxManagerContext : DbContext
{
    public BoxManagerContext(DbContextOptions<BoxManagerContext> options)
        : base(options)
    {
    }

    public BoxManagerContext(int userId, DbContextOptions<BoxManagerContext> options)
        : base(options)
    {
        UserId = userId;
    }

    public int UserId { get; set; } = 0;

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<UserRoles> UserRoles { get; set; }
}