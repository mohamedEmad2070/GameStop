using GameStop.Models;
using GameStop.Settings;
using GameStop.ViewModels;
using System.Threading.Tasks;

namespace GameStop.Services;

public class GamesService : IGamesService
{
    private readonly ApplicationDbContext _Context;
    private readonly IWebHostEnvironment _Environment;
    private readonly string _imagesPath;
    public GamesService(ApplicationDbContext context, IWebHostEnvironment environment)
    {
        _Context = context;
        _Environment = environment;
        _imagesPath = $"{_Environment.WebRootPath}{FileSettings.ImagesPath}";
    }
    public async Task Create(CreateGameFormViewModel model)
    {
        var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
        var path = Path.Combine(_imagesPath, CoverName);
        using var stream = File.Create(path);
        await model.Cover.CopyToAsync(stream);
        

        Game game = new()
        {
            Name = model.Name,
            CategoryId = model.CategoryId,
            Description = model.Description,
            Cover = CoverName,
            Devices = model.SelectedDevices
                .Select(did => new GameDevice { DeviceId = did })
                .ToList()
        };

        _Context.Add(game);
        _Context.SaveChanges();

    }
}
