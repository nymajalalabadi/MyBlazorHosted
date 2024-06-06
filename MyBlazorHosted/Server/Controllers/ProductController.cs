using Microsoft.AspNetCore.Mvc;
using MyBlazorHosted.Libraries.Product;
using MyBlazorHosted.Libraries.Product.Models;

namespace MyBlazorHosted.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region consractor

        private IProductService _productService;
        private ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        #endregion


        [HttpGet]
        public IList<ProductModel> GetAll(int? size = null, int page = 1)
        {
            if (!size.HasValue)
            {
                return _productService.GetAll();
            }

            _logger.LogWarning("Get All Product from controller");

            return _productService.GetAll(size.Value, page);
        }

        [HttpGet("total-page-count")]
        public int GetTotalPageCount(int size)
        {
            return _productService.GetTotalPageCount(size);
        }

        [HttpGet("by-slug/{slug}")]
        public IActionResult GetBySlug(string slug)
        {
            var product = _productService.GetProductBySlug(slug);

            if (product == null)
            {
                return NotFound(string.Format("The Slug '{0}' could not be found", slug));
            }

            return Ok(product);
        }


        [HttpGet("by-sku/{sku}")]
        public IActionResult GetBySku(string sku)
        {
            var product = _productService.GetProduct(sku);

            if (product == null)
            {
                return NotFound(string.Format("The sku '{0}' could not be found", sku));
            }

            return Ok(product);
        }
    }
}
