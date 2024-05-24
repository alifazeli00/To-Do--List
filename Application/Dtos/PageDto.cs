using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PageDto
    {

        public int pageSize { get; set; } = 4;
        public string SearchKey { get; set; }
        public int pageIndex { get; set; } = 1;
        public int RowCount { get; set; }
    }


    public enum SortType
    {
        /// <summary>
        /// بدونه مرتب سازی
        /// </summary>
        None = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروش‌ترین
        /// </summary>
        Bestselling = 2,
        /// <summary>
        /// محبوب‌ترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        ///  ‌جدیدترین
        /// </summary>
        newest = 4,
        /// <summary>
        /// ارزان‌ترین
        /// </summary>
        cheapest = 5,
        /// <summary>
        /// گران‌ترین
        /// </summary>
        mostExpensive = 6,
    }


}
