using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernBusiness.Pages.Shared.ViewModels
{
    public class PagerInfo
    {
        private bool _hasNextPage;
        private bool _hasPreviousPage;

        public int TotalPages { get; set; }
        public string PageBaseUrl { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<ContentItem> CurrentItemsOnPage { get; set; }
        public bool ShowPages { get; set; } = true;
        public string ItemsContentType { get; set; }

        public bool HasPreviousPage
        {
            get { return CurrentPage > 1; }
            set { _hasPreviousPage = value; }
        }
        public bool HasNextPage
        {
            get { return CurrentPage < TotalPages; }
            set { _hasNextPage = value; }
        }
    }
}
