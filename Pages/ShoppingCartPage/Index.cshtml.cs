using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebShopJewel.Models;
using WebShopJewel.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopJewel.Pages.ShoppingCartPage;

public class IndexModel : PageModel
{
    private readonly Repository _repository;
    public IndexModel(Repository repository)
    {
        _repository = repository;
    }
    public List<ShoppingCart> ShoppingCart { get; set; }
    
    public decimal TotalCartPrice { get; set; }

    public async Task OnGetAsync()
    {
        ShoppingCart = await _repository.DisplayCart();

        if (ShoppingCart.Any())
        {
            TotalCartPrice = ShoppingCart.First().ShoppingCartAccount.TotalCartPrice;
        }
    }
    public async Task<IActionResult> OnPostAsync(int id)
    {
        await _repository.AddToShoppingCart(id);

        return RedirectToPage("/SearchProduct/ProductDetails", new { id});
    }
}
