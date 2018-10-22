using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class FeedPostsDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public FeedPostsDbContext(DbContextOptions<FeedPostsDbContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(post => post.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
