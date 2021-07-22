using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Entities
{
    //Save and manage all resources of all posts (images,...)
    public class Resource
    {
        public int RID { get; set; }    //Resource ID - PK
        public int ID { get; set; } //The Post (ID) (1) - use - this resource ('n') - FK
        public string URL { get; set; } //URL for user in content HTML of post
        public string Caption { get; set; }
        public bool IsAvatar { get; set; } 
        public DateTime ImportDate { get; set; }
        public long FileSize { get; set; }
        public Post Post { get; set; }  //A Post (1) - can use/have - ('n') some resources (images) in content 
    }
}
