using Microsoft.EntityFrameworkCore;
using RestfullAPI.DTO;
using RestfullAPI.Models;

namespace RestfullAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext context;
        public ProductRepository(ApiDbContext context)
        {
            this.context = context;
        }
        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }
        public List<ProductWithCategoryDTO> GetAllWithCategory()
        {
            List<Product> Products = context.Products.Include(p=>p.Category).ToList();
            List<ProductWithCategoryDTO> ProductsWithCategory = new List<ProductWithCategoryDTO>();
            foreach(var product in Products)
            {
                ProductsWithCategory.Add(new ProductWithCategoryDTO 
                { ProductId = product.Id, ProductName = product.Name, ProductPrice = product.Price, CategoryName = product.Category.Name });
            }
            return ProductsWithCategory;
        }
        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }
        public void Insert(Product NewProduct)
        {
            context.Products.Add(NewProduct);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.Products.Remove(GetById(id));
            context.SaveChanges();
        }
        public void Update(int id, Product UpdatedProduct)
        
        {
            UpdatedProduct.Id = id;
            context.Products.Update(UpdatedProduct);
            context.SaveChanges();
        }
        public Product GetByName(string name)
        {
            return context.Products.FirstOrDefault(p => p.Name == name);
        }


    }
}
