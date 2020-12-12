using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("shop")]
    public class ShopEntity
    {
        public int Id { get; set; }
        
        public ShopCategoryEntity Category { get; set; }
        
        public Double Rating { get; set; }

        public String Address { get; set; }
        
        public String SiteLink { get; set; }
    }
}