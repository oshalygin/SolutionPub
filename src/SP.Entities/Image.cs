using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }

    }
}
