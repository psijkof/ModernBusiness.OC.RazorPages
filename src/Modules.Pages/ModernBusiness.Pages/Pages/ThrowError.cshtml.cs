using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ModernBusiness.Pages
{
    public class ThrowErrorModel : PageModel
    {
        public void OnGet()
        {
            var k = 0;
            var j = 1 / k;
        }
    }
}