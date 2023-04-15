using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Resources
{
    public class PostImageUpdateRequest
    {
        //public int RID { get; set; }    // ID of image
        public string Caption { get; set; }
        //public long FileSize { get; set; }
        public bool IsAvatar { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
