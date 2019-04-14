using System.Collections.Generic;
using System.Linq;

namespace NShop.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        // Trang hiện tại
        public int Page { get; set; }
        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count()  : 0;
            }
        }
        //Tổng số trang
        public int TotalPages { get; set; }
        //Tổng số bản ghi
        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }



    }
}