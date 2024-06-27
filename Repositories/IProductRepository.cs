using ProductWebAPI.DTO;

namespace ProductWebAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> Get();
        Task<ProductDTO> GetById(Guid id);
        Task<bool> Add(ProductDTO product);
        Task<bool> Update(ProductDTO product);
        Task<bool> Delete(Guid id);
    }
}
