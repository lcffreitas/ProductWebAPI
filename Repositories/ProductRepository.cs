using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Context;
using ProductWebAPI.DTO;
using ProductWebAPI.Models;

namespace ProductWebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDataContext _context;

        public ProductRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(ProductDTO product)
        {
            var productEntity = new Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Price = product.Price,
            };

            _context.Products.Add(productEntity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var productToDelete = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });

            return await products.ToListAsync();
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _context.Products
                                .Where(p => p.Id == id)
                                .Select(p => new ProductDTO
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Price = p.Price,
                                })
                                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<bool> Update(ProductDTO product)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
