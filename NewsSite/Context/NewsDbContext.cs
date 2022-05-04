using Microsoft.EntityFrameworkCore;
using NewsSite.Models.Categories;
using NewsSite.Models.Newsss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Context
{
    public class NewsDbContext:DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
    }
}
