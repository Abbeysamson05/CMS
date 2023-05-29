using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CMS.DATA.DTO
{
    public class ImageUpload
    {
        public IFormFile file { get; set; }
    }
}
