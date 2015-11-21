using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SP.WEB.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string UrlTitle { get; set; }
        public string PhotoPath { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime DateEdited { get; set; }
        [Required]
        [MinLength(256)]
        public string Body { get; set; }
        public string Preview { get; set; }
        public int Views { get; set; }


        public ICollection<TagViewModel> Tags { get; set; }
        public ICollection<CommentViewModel> Comments { get; set; }
    }
}