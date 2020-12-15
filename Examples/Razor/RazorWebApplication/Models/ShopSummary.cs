using System;

namespace RazorWebApplication.Models
{
    public class ShopSummary
    {
        public decimal Rating { get; set; }

        public String Address { get; set; }
        
        public String SiteLink { get; set; }
        
        public string ShopCategory { get; set; }
    }
}