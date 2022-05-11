﻿using MyStore.Core.Data.Entity.Relation;

namespace MyStore.Core.Domain.Service
{
    public interface IStoreApplication
    {
        List<Product> GetAllProducts();

        List<Shipping> GetAllShippings();
    }
}
