using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
    }
}
