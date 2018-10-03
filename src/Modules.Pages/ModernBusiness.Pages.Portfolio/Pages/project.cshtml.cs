using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using OrchardCore;
using OrchardCore.ContentManagement;

namespace ModernBusiness.Pages.Pages
{
    public class projectModel : PageModel
    {
        private readonly IOrchardHelper _orchardHelper;
        public dynamic Project { get; private set; }

        public IEnumerable<ContentItem> RelatedProjects { get; private set; }

        public projectModel(IOrchardHelper orchardHelper)
        {
            _orchardHelper = orchardHelper;
        }

        public void OnGet(string projectTitle)
        {

            //var bla1 = Pagination(currentPage: 5, totalPages: 10, boundaries: 2, around: 1); // 1 2 .. 4 5 6 .. 9 10
            //var bla2 = Pagination(currentPage: 1, totalPages: 1, boundaries: 2, around: 1); // 1 
            //var bla3 = Pagination(currentPage: 9, totalPages: 10, boundaries: 3, around: 3); // 1 2 3 ...6 7 8 9 10
            //var bla4 = Pagination(currentPage: 12, totalPages: 10, boundaries: 3, around: 3); // 
            //var bla5 = Pagination(currentPage: 9, totalPages: 0, boundaries: 3, around: 3); //
            //var bla6 = Pagination(currentPage: 2, totalPages: 4, boundaries: 4, around: 4); // 1 2 3 4
            //var bla7 = Pagination(currentPage: 5, totalPages: 5, boundaries: 0, around: 0); // ... 5
            //var bla8 = Pagination(currentPage: 3, totalPages: 5, boundaries: 0, around: 1); // ...2 3 4...
            //var bla9 = Pagination(currentPage: 1, totalPages: 5, boundaries: 0, around: 0); // 1 ...
            //var bla10 = Pagination(currentPage: 45, totalPages: 10000, boundaries: 5, around: 5); // 1 2 3 4 5 .. 40 41 42 43 44 45 46 47 48 49 50 6 ..9996 9997 9998 9999 10000

            Project = _orchardHelper.QueryContentItemsAsync(q => q.Where(c => c.DisplayText == projectTitle))
                .GetAwaiter().GetResult().SingleOrDefault();

            IEnumerable<string> relProjs = Project.Content.RelatedProjects.ContentItemIds.ToObject<IEnumerable<string>>();

            RelatedProjects = _orchardHelper.GetContentItemsByIdAsync(relProjs).GetAwaiter().GetResult();
        }

        /// <summary>
        /// This imaginary pager takes the current_page, displays
        /// navigation items 
        /// [boundery] [around] [current page] [around] [boundery]
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="totalPages"></param>
        /// <param name="boundaries"></param>
        /// <param name="around"></param>
        /// <returns>string</returns>
        //public string Pagination(int currentPage, int totalPages, int boundaries, int around)
        //{
        //    // assumption: pagination starts with page 1
        //    // always want to see current page
        //    // depending on index of cp, with around > 0, you want pages around cp
        //    // depending on index of cp, with bounderies > 0, you want pages at the beginning and end

        //    // if(cp > bounderies && bounderies > 0) { prepend bounderies }
        //    // if(cp < bounderies && bounderies > 0) { bounderies = cp -1; append bounderies }
        //    // if(cp - around > 0 && around > 0) { prepend the pager with around pages}
        //    // if(cp + around < tp && around > 0) { append the pager with around pages}

        //    // list, addbefore, add after, check if page already part of pager pages

        //    if (totalPages < 1 || currentPage > totalPages) { return ""; }

        //    var listPages = new List<int>();
        //    listPages.Add(currentPage);

        //    // add (uniquely) before bounderies
        //    for (int i = 1; i <= boundaries && i < currentPage; i++)
        //    {
        //        if (!listPages.Contains(i)) { listPages.Add(i); }
        //    }
        //    // add after bounderies
        //    for (int i = totalPages; i > (totalPages - boundaries) && i > currentPage; i--)
        //    {
        //        if (!listPages.Contains(i)) { listPages.Add(i); }
        //    }
        //    // add the before around pages
        //    for (int i = currentPage - 1; i >= currentPage - around && i >= 1; i--)
        //    {
        //        if (!listPages.Contains(i)) { listPages.Add(i); }
        //    }
        //    // add the after around pages
        //    for (int i = currentPage + 1; i <= currentPage + around && i <= totalPages; i++)
        //    {
        //        if (!listPages.Contains(i)) { listPages.Add(i); }
        //    }
        //    // order pages
        //    listPages = listPages.OrderBy(i => i).ToList();
        //    string pagination = "";
        //    // get first page
        //    var lastPageChecked = listPages.FirstOrDefault();
        //    // add leading dots if first page is not page 1
        //    if (lastPageChecked > 1)
        //    {
        //        pagination += "... ";
        //    }
        //    foreach (var page in listPages)
        //    {
        //        // if we find a gap bigger than 1, add ... 
        //        if (page - lastPageChecked > 1 )
        //        {
        //            pagination += "... ";
        //        }
        //        lastPageChecked = page;
        //        // add the page
        //        pagination += $"{page} ";
        //    }
        //    // add trailing dots if last page is not the final page
        //    if (listPages.Last() < totalPages)
        //    {
        //        pagination += "... ";
        //    }

        //    return pagination;
        //}
    }
}