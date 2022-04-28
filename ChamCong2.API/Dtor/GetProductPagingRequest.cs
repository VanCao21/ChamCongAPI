using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong1.API.Dtos
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int Keyword { get; set; }
       
    }
}
