using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories.Products
{
    //Generic repositorydeki methodlar propertyler miras yoluyla gelir fakat constructorda gelmez bu sebeple
    //ProductRepository(AppDbContext context) burada gelen primary constructerdaki contexti
    //: GenericRepository<Product>(context) buraya gönderiyoruz.
    internal class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public Task<List<Product>> GetTopPriceProductsAsync(int count)
        {
            return Context.Products.OrderByDescending(x=>x.Price).Take(count).ToListAsync();
        }
    }
}
