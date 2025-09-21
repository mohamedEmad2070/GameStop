namespace GameStop.Services;

public interface ICategoriesServices
{
    IEnumerable<SelectListItem> GetSelectListItems();
}
