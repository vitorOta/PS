﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessoSeletivo.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity entity);

        void Remove(TEntity entity);

        void Dispose();
    }
}
