using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Interfaces.Services
{
    public interface IBaseServiceInterface<TEntity> where TEntity:class
    {
        Result<IEnumerable<TEntity>> GetAll();
        Result<TEntity> GetOne(int id);
        Result Insert(TEntity entity);
        Result Update(int id, TEntity entity);
        Result Delete(int id); 
    }
}
