using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Resources
{
    public class ResourceViewModel
    {
        public int RID { get; set; }    //Resource ID - PK
        public int ID { get; set; } //The Post (ID) (1) - use - this resource ('n') - FK
        public string URL { get; set; } //URL for user in content HTML of post
        public string Caption { get; set; }
        public DateTime ImportDate { get; set; }
        public long FileSize { get; set; }
        public bool IsAvatar { get; set; }
        //public IFormFile ImageFile { get; set; }
    }
}
