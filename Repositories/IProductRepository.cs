using RestfullAPI.DTO;
using RestfullAPI.Models;

namespace RestfullAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        List<ProductWithCategoryDTO> GetAllWithCategory();
        Product GetById(int id);
        void Insert(Product NewProduct);
        void Delete(int id);
        void Update(int id, Product UpdatedProduct);
        Product GetByName(string name);
    }
}
