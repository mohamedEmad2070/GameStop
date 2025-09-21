
using Microsoft.EntityFrameworkCore;

namespace GameStop.Services;

public class DevicesService : IDevicesService
{
    private readonly ApplicationDbContext _Context;

    public DevicesService(ApplicationDbContext context)
    {
        _Context = context;
    }
    public IEnumerable<SelectListItem> GetSelectListItems()
    {
        return _Context.Devices.Select(d => new SelectListItem
        {
            Value = d.Id.ToString(),
            Text = d.Name
        })
         .OrderBy(d => d.Text)
         .AsNoTracking()
         .ToList();
    }
}
