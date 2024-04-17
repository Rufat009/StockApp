namespace StockApp.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repositories.Base;

public class ProductsRepository : IProductsRepository<Product>
{
    private readonly StockDbContext dbContext;

    public ProductsRepository()
    {
        this.dbContext = new StockDbContext();
    }

    public IEnumerable<Product> GetAll()
    {
        return dbContext.Products.ToList();
    }

    public Product GetById(int id)
    {
        return dbContext.Products.FirstOrDefault(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        dbContext.Products.Add(product);

        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        dbContext.Products.Update(product);

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = dbContext.Products.FirstOrDefault(p => p.Id == id);

        if (product != null)
        {
            dbContext.Products.Remove(product);

            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> SearchAsync(string searchProduct)
    {
        return await dbContext.Products.Where(p => p.Name.ToLower().Contains(searchProduct.ToLower())).ToListAsync();
    }

    public async Task<IEnumerable<Product>> FilterAsync(Category category)
    {
        return await dbContext.Products.Where(p => p.Category == category).ToListAsync();
    }
}
