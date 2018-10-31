using OrchardCore.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModernBusiness.Pages.Users.ViewModels
{
    public class LostPasswordViewModel
    {
		public User User { get; set; }

		public string LostPasswordUrl { get; set; }
    }
}
