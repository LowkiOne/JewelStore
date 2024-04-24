using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebShopJewel.Models;
using WebShopJewel.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopJewel.Pages.ShoppingCartPage;

public class OrderConfirmationPageModel : PageModel
{
    private readonly Repository _repository;
    public OrderConfirmationPageModel(Repository repository)
    {
        _repository = repository;
    }
    public List<ShoppingCart> ShoppingCart { get; set; }
    [BindProperty]
    public decimal TotalCartPrice { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        ShoppingCart = await _repository.DisplayCart();

        if (ShoppingCart.Any())
        {
            TotalCartPrice = ShoppingCart.First().ShoppingCartAccount.TotalCartPrice;
        }

        _repository.RemoveShoppingCart();

        return Page();
    }
}
