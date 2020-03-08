using CleanArchitecture.Core.SharedKernel;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IRepository
    {
        #region Methods

        T Add<T>(T entity) where T : BaseEntity;

        void Delete<T>(T entity) where T : BaseEntity;

        T GetById<T>(int id, string include = null) where T : BaseEntity;

        List<T> List<T>() where T : BaseEntity;

        void Update<T>(T entity) where T : BaseEntity;

        #endregion Methods
    }
}
