using System.ComponentModel.DataAnnotations;

namespace SP.WEB.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TimesUsed { get; set; }
    }
}