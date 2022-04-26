using Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ISiteEcommerceService
    {
        public (int, object) Patch(Guid id);
        public (int, object) GetCollection();

    }
}
