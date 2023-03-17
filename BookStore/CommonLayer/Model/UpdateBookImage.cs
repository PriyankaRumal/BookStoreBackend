using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class UpdateBookImage
    {
        public int BookId { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
