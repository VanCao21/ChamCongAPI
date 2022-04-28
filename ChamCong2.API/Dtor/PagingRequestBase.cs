using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamCong1.API.Dtos
{
    public class PagingRequestBase
    {
        public int id { get; set; }
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int _PageSize = 10;
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
