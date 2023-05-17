using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogify.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? blogImage { get; set; }
        public string? blogTitle { get; set; }
        public string? blogCategory { get; set; }
        public string? blogDescription { get;set; }
        public int WriterId { get; set; }
        public string? WriterName { get; set; }
    }
}