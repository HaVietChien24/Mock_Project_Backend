﻿namespace Mock.Bussiness.Service.Base
{
    public interface IBaseService<T> where T : class
    {
        T GetByID(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        IList<T> GetAll();
    }
}
