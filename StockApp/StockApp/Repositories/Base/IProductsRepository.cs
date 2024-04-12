namespace StockApp.Repositories.Base;

using System.Collections.Generic;
using System.Threading.Tasks;
using StockApp.Models;



public interface IProductsRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    Task AddAsync(TEntity product);
    Task UpdateAsync(TEntity product);
    Task DeleteAsync(int id);
}
