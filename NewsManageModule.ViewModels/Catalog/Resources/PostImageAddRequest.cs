using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Resources
{
    public class PostImageAddRequest
    {
        //public int ID { get; set; }     // ID of post
        public string Caption { get; set; }
        //public long FileSize { get; set; }
        public bool IsAvatar { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
