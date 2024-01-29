using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.ViewModels
{
    public class PageViewModel
    {
        public PageViewModel(int count, int pageNumber, int limit)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)limit);
        }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;
    }
}
