﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorHosted.Shared.Models
{
    public class ShoppingCartAddModel
    {
        public string? ProductSku { get; set; }

        public int Quantity { get; set; }
    }
}
