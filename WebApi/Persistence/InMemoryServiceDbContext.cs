using Microsoft.EntityFrameworkCore;

namespace WebApi.Persistence;

public class InMemoryServiceDbContext : ServiceDbContext
{
    public InMemoryServiceDbContext()
        : base(new DbContextOptionsBuilder<ServiceDbContext>()
            .UseInMemoryDatabase("InMemoryServiceDb")
            .Options)
    {
    }
}