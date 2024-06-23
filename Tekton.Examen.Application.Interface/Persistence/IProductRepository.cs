using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekton.Examen.Domain.Entity;

namespace Tekton.Examen.Application.Interface.Persistence
{
    public interface IProductRepository
    {
        #region Sincronos
        bool Insert(Product product);

        bool Update(Product product);

        Product GetById(int id);
        #endregion

        #region Asincronos

        Task<bool> InsertAsync(Product product);

        Task<bool> UpdateAsync(Product product);

        Task<Product> GetByIdAsync(int id);

        #endregion



    }
}
