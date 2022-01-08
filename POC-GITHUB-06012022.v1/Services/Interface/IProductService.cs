﻿using POC_GITHUB_06012022.v1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GITHUB_06012022.v1.Services
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAll();
        Task<Product> Get(long id);
        Task Save(Product product);
    }
}