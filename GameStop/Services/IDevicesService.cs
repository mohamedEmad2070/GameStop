namespace GameStop.Services;

public interface IDevicesService
{
    IEnumerable<SelectListItem> GetSelectListItems();
}
