using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebShopJewel.Models;
using WebShopJewel.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopJewel.Pages.SearchProduct;

public class IndexModel : PageModel
{
    private readonly Repository _repository;
    private readonly IConfiguration _config;

    public IndexModel(Repository repository, IConfiguration config)
    {
        _repository = repository;
        _config = config;
    }

    [BindProperty(SupportsGet = true)]
    public int? CategoryId { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }

    public PaginatedList<Product> Products { get; set; }
    public List<Category> Categories { get; private set;}
    public IQueryable<Product> Query {  get; private set; }

    public async Task OnGetAsync()
    {
        Categories = await _repository.GetCategories();
    }

    public async Task OnPostAsync(int categoryId, string searchString, int? pageIndex)
    {
        Query = await _repository.GetProducts(categoryId, searchString);
        Categories = await _repository.GetCategories();

        var pageSize = _config.GetValue("PageSize", 10);

        Products = await PaginatedList<Product>
            .CreateAsync(Query.AsNoTracking(), pageIndex ?? 1, pageSize);
    }
}
