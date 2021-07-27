using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Posts
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public string Head { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        //public User Creator { get; set; }
        public DateTime Time { get; set; }
        public int ViewCount { get; set; }
        //public List<int> TID { get; set; }
        //public List<PostInTopic> PostInTopics { get; set; }
        //public List<int> HID { get; set; }
        //public List<History> Histories { get; set; }
        //public List<int> RID { get; set; }
        //public List<Resource> Resources { get; set; }
    }
}
