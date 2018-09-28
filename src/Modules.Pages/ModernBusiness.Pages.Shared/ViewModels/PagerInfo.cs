using ModernBusiness.Pages.Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernBusiness.Pages.Shared.ViewModels
{
    public class PagerInfo
    {
        public int TotalPages { get; set; }
        public string PageBaseUrl { get; set; }
        public int CurrentPage { get; set; }
        public PaginatedList<object> paginatedList { get;set;}
    }
}
