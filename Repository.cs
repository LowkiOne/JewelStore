using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebShopJewel.Models;
using WebShopJewel.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebShopJewel;

public class Repository
{
    private readonly AppDbContext _appDbContext;
    private readonly AccessControl _accessControl;

    public Repository(AppDbContext appDbContext, AccessControl accessControl)
    {
        _appDbContext = appDbContext;
        this._accessControl = accessControl;
    }

    public async Task<IQueryable<Product>> GetProducts(int categoryId, string searchString)
    {
            IQueryable<Product> query = _appDbContext.Products.Include(p => p.Category);
            
            if (categoryId != 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString));
            }

            return query;
    }

    public async Task<Product> GetProductDetails(int id)
    {
       return await _appDbContext.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Category>> GetCategories()
    {
        return await _appDbContext.Categories.AsNoTracking().ToListAsync();
    }

    private int CreateShoppingAccount()
    {
        ShoppingCartAccount account = _appDbContext.ShoppingCartAccounts.FirstOrDefault(p => p.AccountId == _accessControl.LoggedInAccountID);

        if (account == null)
        {
            account = new ShoppingCartAccount
            {
                AccountId = _accessControl.LoggedInAccountID
            };

            _appDbContext.ShoppingCartAccounts.Add(account);
            _appDbContext.SaveChanges();
        }

        return account.Id;
    }

    public void AddShoppingCart(int id)
    {
        int accountId = CreateShoppingAccount();

        Product product = _appDbContext.Products.FirstOrDefault(p => p.Id == id);
        
        ShoppingCart cartItem = _appDbContext.ShoppingCarts
            .FirstOrDefault(p => p.ProductId == id && p.ShoppingCartAccountId == accountId);
        
        decimal totalPrice = product.Price;

        if (cartItem != null)
        {
            cartItem.AmountProduct++;
            cartItem.TotalPrice += totalPrice;

            _appDbContext.SaveChanges();
        }
        else
        {
            cartItem = new ShoppingCart
            {
                AmountProduct = 1,
                TotalPrice = totalPrice,
                ProductId = product.Id,
                ShoppingCartAccountId = accountId
            };

            _appDbContext.ShoppingCarts.Add(cartItem);
        }

        cartItem.ShoppingCartAccount.TotalCartPrice += product.Price;

        _appDbContext.SaveChanges();
    }

    public async Task<List<ShoppingCart>> AddToShoppingCart(int id)
    {
        AddShoppingCart(id);

        return await _appDbContext.ShoppingCarts
            .Include(s => s.ShoppingCartAccount)
            .Where(a => a.ShoppingCartAccount.AccountId == _accessControl.LoggedInAccountID)
            .ToListAsync();
    }

    public async Task<List<ShoppingCart>> DisplayCart()
    {
        return await _appDbContext.ShoppingCarts
            .Include(p => p.Product)
            .Include(a => a.ShoppingCartAccount)
            .Where(a => a.ShoppingCartAccount.AccountId == _accessControl.LoggedInAccountID)
            .ToListAsync();
    }

    public void RemoveShoppingCart()
    {
       ShoppingCartAccount accountId = _appDbContext.ShoppingCartAccounts.FirstOrDefault(a => a.AccountId == _accessControl.LoggedInAccountID);

        if(accountId != null)
        {
            foreach (var product in accountId.Items)
            {
                _appDbContext.ShoppingCarts.Remove(product);
            }

            accountId.TotalCartPrice = 0;

            _appDbContext.SaveChanges();
        }
    }
}
