using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class PageDto
    {

        public int pageSize { get; set; } = 100;
        public string SearchKey { get; set; }
        public int pageIndex { get; set; } = 1;
        public int RowCount { get; set; }
        public SortType SortType { get; set; }
    }


    public enum SortType
    {
        /// <summary>
        /// بدونه مرتب سازی
        /// </summary>
        All = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        Active = 1,
        /// <summary>
        /// پرفروش‌ترین
        /// </summary>
        Completed = 2,

        ClearCompleted = 3,
    }


}
