using System;
using System.Collections.Generic;

namespace SoftwareEngineeringProject.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public byte[] Thumbnail { get; set; }
    }
}
