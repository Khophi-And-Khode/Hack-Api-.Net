using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackApi.Model
{
    public class ImageData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Signature { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
        public string SecureUrl { get; set; }
        public string Format { get; set; }
        public string ResourceType { get; set; }

    }


    public class VideoData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Signature { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
        public string SecureUrl { get; set; }
        public string Format { get; set; }
        public string ResourceType { get; set; }
        public double Duration { get; set; }

    }
}
