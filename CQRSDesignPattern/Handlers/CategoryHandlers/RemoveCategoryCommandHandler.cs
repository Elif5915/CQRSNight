using CQRSNight.Context;
using CQRSNight.CQRSDesignPattern.Commands.CategoryCommands;

namespace CQRSNight.CQRSDesignPattern.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly CQRSContext _context;

    public RemoveCategoryCommandHandler(CQRSContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCategoryCommand command)
    {
        var values = await _context.Categories.FindAsync(command.CategoryId);
        _context.Categories.Remove(values);
        await _context.SaveChangesAsync();
    }
}
