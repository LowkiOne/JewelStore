using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebShopJewel.Models;
using WebShopJewel.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopJewel.Pages.SearchProduct
{
    public class ProductDetailsModel : PageModel
    {
        private readonly Repository _repository;
        public ProductDetailsModel(Repository repository)
        {
            _repository = repository;
        }
        public Product Product { get; set; }

        public async Task OnGetAsync(int id)
        {
           Product = await _repository.GetProductDetails(id);
        }

        public IActionResult OnPost(int id)
        {
            return Page();
        }
    }
}
