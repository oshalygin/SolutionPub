using System;
using System.ComponentModel.DataAnnotations;

namespace SP.WEB.Models
{
    public class ImageViewModel
    {

        public int Id { get; set; }
        public DateTime UploadDate { get; set; }

        [Required]
        [MinLength(10)]
        public string ImagePath { get; set; }
        public string Description { get; set; }
        
    }
}
