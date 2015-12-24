using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Domain.Concrete
{
  public class EFDbContext : DbContext
  {
    public DbSet<Task> Tasks { get; set; }
  }
}
