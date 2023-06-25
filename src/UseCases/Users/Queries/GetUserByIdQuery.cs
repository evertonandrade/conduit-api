using Conduit.Api.Database;

namespace Conduit.Api.UseCases.Users.Queries;

public class GetUserByIdQuery
{
    private readonly ApplicationDbContext _dbContext;

    public GetUserByIdQuery(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}