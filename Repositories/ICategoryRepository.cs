using RestfullAPI.DTO;
namespace RestfullAPI.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryAndProductsDTO> GetAll();
        CategoryAndProductsDTO GetById(int id);
    }
}
