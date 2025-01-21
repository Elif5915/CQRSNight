using CQRSNight.Context;
using CQRSNight.CQRSDesignPattern.Queries.CategoryQueries;
using CQRSNight.CQRSDesignPattern.Results.CategoryResults;

namespace CQRSNight.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{

    private readonly CQRSContext _context;

    public GetCategoryByIdQueryHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var values = await _context.Categories.FindAsync(query.CategoryId);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = values.CategoryId,
            CategoryName = values.CategoryName
        };
    }
}
