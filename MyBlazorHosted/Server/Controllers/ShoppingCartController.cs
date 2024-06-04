using Microsoft.AspNetCore.Mvc;
using MyBlazorHosted.Libraries.Product;
using MyBlazorHosted.Libraries.ShoppingCart;
using MyBlazorHosted.Libraries.ShoppingCart.Models;
using MyBlazorHosted.Shared.Models;

namespace MyBlazorHosted.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        #region consractor

        private IShoppingCartService _shoppingCartService;
        private IProductService _productService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }

        #endregion

        [HttpGet]
        public ShoppingCartModel GetCart()
        {
            return _shoppingCartService.Get();
        }

        [HttpGet("count")]
        public int GetCount()
        { 
            return _shoppingCartService.Count();
        }

        [HttpGet("has-product/{sku}")]
        public bool HasProduct(string sku)
        {
            return _shoppingCartService.HasProduct(sku);
        }

        [HttpPost]
        public IActionResult AddProduct(ShoppingCartAddModel shoppingCartAdd)
        {
            var product = !string.IsNullOrWhiteSpace(shoppingCartAdd.ProductSku) ? _productService.GetProduct(shoppingCartAdd.ProductSku) : null;

            if (product == null)
            {
                return NotFound();
            }

            _shoppingCartService.AddProduct(product, shoppingCartAdd.Quantity);

            return Ok(new { Success = true });
        }

        [HttpPut]
        public IActionResult UpdateProduct(ShoppingCartAddModel shoppingCartAdd)
        {
            var product = !string.IsNullOrWhiteSpace(shoppingCartAdd.ProductSku) ? _productService.GetProduct(shoppingCartAdd.ProductSku) : null;

            if (product == null)
            {
                return NotFound();
            }

            _shoppingCartService.AddProduct(product, shoppingCartAdd.Quantity);

            return Ok(new { Success = true });
        }

        [HttpDelete("{sku}")]
        public IActionResult DeleteProduct(string sku)
        {
            var cart = _shoppingCartService.Get();

            if (cart?.Items == null || !cart.Items.Any(s => s.Product.Sku == sku))
            {
                return NotFound();
            }

            var product = cart?.Items.First(p => p.Product.Sku == sku);

            _shoppingCartService.DeleteProduct(product);

            return Ok(new { Success = true });
        }
    }
}
