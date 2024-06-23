using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekton.Examen.Application.Interface.Cache
{
    public  interface IProductStatusCache
    {
        Dictionary<int, string> GetProductStatusDictionary();
    }
}
