using Microsoft.EntityFrameworkCore;
using Postex.Product.Infrastructure.Data;

namespace Postex.Product.UnitTest.Fixtures
{
    public class ContextFixture
    {
        public readonly ApplicationDBContext Context;
        public ContextFixture()
        {
            DbContextOptions<ApplicationDBContext> options;
            var builder = new DbContextOptionsBuilder<ApplicationDBContext>();
            builder.UseInMemoryDatabase("Data Source=.;Initial Catalog=TestDb;Integrated Security=true");
            options = builder.Options;
            Context = new ApplicationDBContext(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();
        }
    }
}
