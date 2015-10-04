using System;

namespace SP.Entities
{
    public class PublicImage
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

    }
}
