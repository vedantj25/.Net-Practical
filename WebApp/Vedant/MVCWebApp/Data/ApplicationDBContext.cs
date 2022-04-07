using MVCWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MVCWebApp.Data
{
 public class ApplicationDBContext : DbContext
 {

  public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
  {

  }

  public DbSet<Student> Student { get; set; }

  public DbSet<Subject> Subject { get; set; }

  public DbSet<Teacher> Teacher { get; set; }
 }
}