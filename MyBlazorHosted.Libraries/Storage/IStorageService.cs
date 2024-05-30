using MyBlazorHosted.Libraries.Product.Models;
using MyBlazorHosted.Libraries.ShoppingCart.Models;

namespace MyBlazorHosted.Libraries.Storage
{
    public interface IStorageService
    {
        IList<ProductModel> products { get; }

        ShoppingCartModel ShoppingCart { get; }
    }

}
