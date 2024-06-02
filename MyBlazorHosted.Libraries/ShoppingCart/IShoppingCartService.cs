using MyBlazorHosted.Libraries.Product.Models;
using MyBlazorHosted.Libraries.ShoppingCart.Models;

namespace MyBlazorHosted.Libraries.ShoppingCart
{
    public interface IShoppingCartService
    {
        ShoppingCartModel Get();

        void AddProduct(ProductModel product, int quantity);

        void DeleteProduct(ShoppingCartItemModel item);

        int Count();

        bool HasProduct(string sku);
    }
}
