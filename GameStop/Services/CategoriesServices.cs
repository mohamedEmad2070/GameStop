﻿
using Microsoft.EntityFrameworkCore;

namespace GameStop.Services;

public class CategoriesServices : ICategoriesServices
{
    private readonly ApplicationDbContext _Context;

    public CategoriesServices(ApplicationDbContext context)
    {
        _Context = context;
    }
    public IEnumerable<SelectListItem> GetSelectListItems()
    {
        return _Context.Categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        })
         .OrderBy(c => c.Text)
         .AsNoTracking()
         .ToList();
    }
}
