using Microsoft.EntityFrameworkCore;
using StudentsApp.Domain.Models;
using System.Collections.Generic;

namespace StudentsApp.Infrastructure.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
