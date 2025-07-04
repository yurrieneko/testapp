using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using testAPI.Model;

namespace testAPI
{
    public class IssueDbContext : DbContext
    {

        public IssueDbContext(DbContextOptions<IssueDbContext> options) : base(options)
        {
        }
        public DbSet<Issue> Issues { get; set; }
    }
}
