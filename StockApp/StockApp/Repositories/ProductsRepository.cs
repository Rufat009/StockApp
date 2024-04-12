namespace StockApp.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockApp.Data;
using StockApp.Models;
using StockApp.Repositories.Base;

public class ProductsRepository : IProductsRepository<Product>
{
    private readonly StockDbContext dbContext;

    public ProductsRepository(StockDbContext dbContext)
    {
        this.dbContext = dbContext;
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

}
