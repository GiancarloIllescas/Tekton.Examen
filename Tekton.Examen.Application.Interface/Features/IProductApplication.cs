using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekton.Examen.Application.DTO;
using Tekton.Examen.Cross.Common;
using System.Threading.Tasks;

namespace Tekton.Examen.Application.Interface.Features
{
    public interface IProductApplication
    {
        #region Sincronos
        Response<bool> Insert(ProductDto product);

        Response<bool> Update(ProductDto product);

        Response<ProductDto> GetById(int id);
        #endregion

        #region Asincronos

        Task<Response<bool>> InsertAsync(ProductDto product);

        Task<Response<bool>> UpdateAsync(ProductDto product);

        Task<Response<ProductDto>> GetByIdAsync(int id);

        #endregion
    }
}
