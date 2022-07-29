using Microsoft.EntityFrameworkCore;
using RestfullAPI.DTO;
using RestfullAPI.Models;
using System.Collections.Generic;

namespace RestfullAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext context;
        public CategoryRepository(ApiDbContext context)
        {
            this.context = context;
        }
        public List<CategoryAndProductsDTO> GetAll()
        {
            List<Category> Categories = context.Categories.Include(c => c.Products).ToList();
            List<CategoryAndProductsDTO> categoryAndProducts = new List<CategoryAndProductsDTO>();
            List<ProductInfo> Products;
            foreach (var category in Categories)
            {
                Products = new List<ProductInfo>();
                foreach (Product product in category.Products)
                {
                    Products.Add(new ProductInfo() { ProductId = product.Id, ProductName = product.Name });
                }
                categoryAndProducts.Add(new CategoryAndProductsDTO() { CategoryId = category.Id, CategoryName = category.Name, Products = Products });
            }
            return categoryAndProducts;
        }
        public CategoryAndProductsDTO GetById(int id)
        {
            Category Category = context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
            CategoryAndProductsDTO CategoryWithProducts = new CategoryAndProductsDTO();
            CategoryWithProducts.CategoryName = Category.Name;
            CategoryWithProducts.CategoryId = Category.Id;
            foreach (var Product in Category.Products)
            {
                CategoryWithProducts.Products.Add(new ProductInfo { ProductId = Product.Id, ProductName = Product.Name });
            }
            return CategoryWithProducts;
        }
    }
}
