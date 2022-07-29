namespace RestfullAPI.DTO
{
    public class CategoryAndProductsDTO
    {
        public CategoryAndProductsDTO()
        {
            Products = new List<ProductInfo>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductInfo> Products { get; set; }
    }
    public class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
