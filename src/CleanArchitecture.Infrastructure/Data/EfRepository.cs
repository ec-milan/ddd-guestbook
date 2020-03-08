﻿using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        #region Fields

        private readonly AppDbContext _dbContext;

        #endregion Fields


        #region Methods

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById<T>(int id, string include = null) where T : BaseEntity
        {
            return include == null
                ? _dbContext.Set<T>()
                    .SingleOrDefault(e => e.Id == id)
                : _dbContext.Set<T>()
                    .Include(include)
                    .SingleOrDefault(e => e.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        #endregion Methods


        #region Constructors

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Constructors
    }
}
