using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    public class ShopCategoryEntity
    {
        public int Id { get; set; }
        
        public string Category { get; set; }
    }
}