﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caching
{
    interface IRepo
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
