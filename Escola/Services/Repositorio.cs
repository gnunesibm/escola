/*
 * file: Repositorio.cs
 * 
 * purpose: academic teaching and learning
 *          definition and implementation of the interface to the default repository
 *           
 * 
 * version: 1.0
 * 
 * author: adilson.silva@ibm.com
 * date: September 16, 2021
 * 
 * Copyright (C) 2021 IBM. All rights reserved.
 * 
 * 
 * history:
 * 20210916 - adilson.silva@ibm.com - first version
 * 
 **/
using Escola.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Services
{

    /// <summary>
    /// interface para repositorio padrao
    /// </summary>
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Find(params object[] key);
        T First(Expression<Func<T, bool>> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Func<T, bool> predicate);
        void Delete(T entity);
        void Commit();
        void Dispose();
    }

    /// <summary>
    /// implementacao da interface para repositorio padrao no contexto TEST
    /// </summary>
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private escolaEntities context;

        public Repositorio()
        {
            context = new escolaEntities();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .Where(predicate);
        }

        public T Find(params object[] key)
        {
            return context.Set<T>()
                .Find(key);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .Where(predicate)
                .FirstOrDefault();
        }

        public void Insert(T entity)
        {
            context.Set<T>()
                .Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Func<T, bool> predicate)
        {
            context.Set<T>()
                .Where(predicate)
                .ToList()
                .ForEach(del => context.Set<T>().Remove(del));
        }
        public void Delete(T entity)
        {
            context.Set<T>()
                .Remove(entity);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
