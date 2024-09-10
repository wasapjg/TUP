﻿using RepositoryExample.Domain;

namespace RepositoryExample.Data
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        bool Save(Product oProduct);
        bool Delete(int id);
    }
}
