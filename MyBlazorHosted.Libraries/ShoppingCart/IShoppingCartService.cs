﻿using MyBlazorHosted.Libraries.Product.Models;
using MyBlazorHosted.Libraries.ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
