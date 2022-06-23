using lolAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace lolAPI.Data;

public class lolAPIdb : DbContext
{
    public lolAPIdb(DbContextOptions<lolAPIdb> options) : base(options)
        {
            
        }

    public DbSet<Request> Request { get; set; } = null!;
}