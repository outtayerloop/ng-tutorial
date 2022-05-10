﻿using MyStore.Core.Data.Entity.Model;

namespace MyStore.Core.Repository
{
    public interface IStoreRepository<T> where T : BaseModel
    {
        List<T> GetAll();
    }
}
