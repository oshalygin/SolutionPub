using System;
using System.ComponentModel.DataAnnotations;

namespace SP.WEB.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime DateOfComment { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }
    }
}