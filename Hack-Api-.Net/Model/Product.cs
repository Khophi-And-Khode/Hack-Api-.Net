using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackApi.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string Implication { get; set; }
        public string Reviews { get; set; }
        public string PublicId { get; set; }
        public string Keyword { get; set; }
    }
}
