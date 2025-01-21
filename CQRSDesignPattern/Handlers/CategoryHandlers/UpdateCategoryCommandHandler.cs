using CQRSNight.Context;
using CQRSNight.CQRSDesignPattern.Commands.CategoryCommands;

namespace CQRSNight.CQRSDesignPattern.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly CQRSContext _context;

    public UpdateCategoryCommandHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand command)
    {
        var values = await _context.Categories.FindAsync(command.CategoryId);
        values.CategoryName = command.CategoryName;
        await _context.SaveChangesAsync();
    }
}
