﻿using SportsStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
