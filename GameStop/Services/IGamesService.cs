using GameStop.ViewModels;

namespace GameStop.Services;

public interface IGamesService
{
    Task Create(CreateGameFormViewModel model);
}
