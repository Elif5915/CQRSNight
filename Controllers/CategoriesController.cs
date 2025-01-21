using CQRSNight.CQRSDesignPattern.Commands.CategoryCommands;
using CQRSNight.CQRSDesignPattern.Handlers.CategoryHandlers;
using CQRSNight.CQRSDesignPattern.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSNight.Controllers;
public class CategoriesController : Controller
{

    private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
    private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
    private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
    private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
    private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

    public CategoriesController(CreateCategoryCommandHandler categoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
    {
        _createCategoryCommandHandler = categoryCommandHandler;
        _updateCategoryCommandHandler = updateCategoryCommandHandler;
        _removeCategoryCommandHandler = removeCategoryCommandHandler;
        _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        _getCategoryQueryHandler = getCategoryQueryHandler;
    }

    public async Task<IActionResult> CategoryList()
    {
        var values = await _getCategoryQueryHandler.Handle();
        return View(values);
    }

    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _createCategoryCommandHandler.Handle(command);
        return RedirectToAction("CategoryList");
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
        return View(values);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
    {
        await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
        return RedirectToAction("CategoryList");
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
        return RedirectToAction("CategoryList");
    }
}
