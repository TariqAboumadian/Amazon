using Amazon.Domain;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Context
{
    public class AmazonContext:DbContext
    {
        public AmazonContext(DbContextOptions<AmazonContext> options) : base(options) { }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}
