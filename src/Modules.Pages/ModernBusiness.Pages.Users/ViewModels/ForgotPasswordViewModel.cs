using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModernBusiness.Pages.Users.ViewModels
{
    public class ForgotPasswordViewModel
    {
		[Required]
		public string UserIdentifier { get; set; }
    }
}
