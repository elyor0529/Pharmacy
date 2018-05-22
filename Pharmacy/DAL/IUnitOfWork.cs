using System;
using System.Data.Entity;

namespace Pharmacy.DAL
{

    public interface IUnitOfWork : IDisposable
    {

        DbContext DbContext { get; }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
