using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OrchardCore.Users;

namespace ModernBusiness.Pages
{
    public class LogOffModel : PageModel
    {
        private readonly SignInManager<IUser> _signInManager;
        private readonly ILogger<LogOffModel> _logger;

        public LogOffModel(SignInManager<IUser> signInManager, ILogger<LogOffModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");

            return Redirect("~/");
        }
    }
}