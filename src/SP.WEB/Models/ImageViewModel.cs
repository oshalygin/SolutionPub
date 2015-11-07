using System;
using System.ComponentModel.DataAnnotations;

namespace SP.WEB.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string ImagePath { get; set; }

        [Required]
        public string Description { get; set; }
    }
}