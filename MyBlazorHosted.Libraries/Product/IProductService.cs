

using MyBlazorHosted.Libraries.Product.Models;

namespace MyBlazorHosted.Libraries.Product
{
    public interface IProductService
    {
        ProductModel? GetProduct(string sku);

        ProductModel? GetProductBySlug(string slug);

        IList<ProductModel> GetAll();

        IList<ProductModel> GetAll(int size, int pageId = 1);

        int GetTotalPageCount(int size);
    }

}
