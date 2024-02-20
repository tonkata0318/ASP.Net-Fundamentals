using ForumApp2024.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp2024.Infrastructure.Data
{
    public class ForumDBContext: DbContext
    {
        public ForumDBContext(DbContextOptions<ForumDBContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
