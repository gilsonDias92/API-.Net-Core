using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Interfaces.Services
{
    public interface IBaseServiceInterface<T> where T:class
    {
        Result<T> Insert(T entity);
        Result <T> Update(int id, T entity);
        Result<T> GetOne(int id);
        Result<T> GetAll();
        Result<bool> Delete(int id); 
    }
}
