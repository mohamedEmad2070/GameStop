
using GameStop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.Controllers;
public class GamesController : Controller
{
    private readonly ApplicationDbContext _Context;
    private readonly ICategoriesServices _CategoriesServices;
    private readonly IDevicesService _DevicesService;
    private readonly IGamesService _GamesService;
    public GamesController(ApplicationDbContext context, ICategoriesServices categoriesServices, IDevicesService devicesService, IGamesService gamesService)
    {
        _Context = context;
        _CategoriesServices = categoriesServices;
        _DevicesService = devicesService;
        _GamesService = gamesService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        CreateGameFormViewModel viewModel = new()
        {
            Categories = _CategoriesServices.GetSelectListItems(),

            Devices = _DevicesService.GetSelectListItems()

        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateGameFormViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = _CategoriesServices.GetSelectListItems();

            viewModel.Devices = _DevicesService.GetSelectListItems();
            return View(viewModel);
        }

        await _GamesService.Create(viewModel);

        return RedirectToAction(nameof(Index));
    }
}