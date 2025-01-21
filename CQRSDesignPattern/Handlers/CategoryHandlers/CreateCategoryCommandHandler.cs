using CQRSNight.Context;
using CQRSNight.CQRSDesignPattern.Commands.CategoryCommands;
using CQRSNight.Entities;

namespace CQRSNight.CQRSDesignPattern.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler
{
    private readonly CQRSContext _context;

    public CreateCategoryCommandHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCategoryCommand command)
    {
        _context.Categories.Add(new Category
        {
            CategoryName = command.CategoryName
        });

        await _context.SaveChangesAsync();
    }
}
