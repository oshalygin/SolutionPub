using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SP.Entities;

namespace SP.WEB.Models
{
    public class TagViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TimesUsed { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
