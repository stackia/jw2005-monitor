using System.Data.Entity;
using JW2005.Models;

namespace JW2005.DAL
{
    public class Jw2005Context : DbContext
    {
        public DbSet<Server> Servers { get; set; }
    }
}