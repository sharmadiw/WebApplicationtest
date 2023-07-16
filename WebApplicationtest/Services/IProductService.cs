using WebApplicationtest.Models;

namespace WebApplicationtest.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}