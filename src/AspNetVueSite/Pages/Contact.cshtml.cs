using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetVueSite.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }
        public Address Address { get; set; }
        public Emails Emails { get; set; }
        public void OnGet()
        {
            Message = "Your contact page.";
            Address = new Address();
            Address.Line1 = "One Microsoft Way";
            Address.Line2 = "Redmond, WA 98052-6399";
            Address.Phone = "425.555.0100";

            Emails = new Emails();
            Emails.SupportEmail = "Support@example.com";
            Emails.MarketingEmail = "Marketing@example.com";
        }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Phone { get; set; }
    }

    public class Emails
    {
        public string MarketingEmail { get; set; }
        public string SupportEmail { get; set; }
    }
}
