using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Examen.Domain.Entity;

namespace Tekton.Examen.Application.Interface.Services
{
    public interface IProductDiscountService
    {
        ProductDiscount GetById(int id);

        Task<ProductDiscount> GetByIdAsync(int id);
    }
}
