using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Posts
{
    public class PostCreateRequest
    {
        public string Head { get; set; }
        public string Content { get; set; }
        //public List<int> TID { get; set; }
        //public List<PostInTopic> PostInTopics { get; set; }
        //public Guid UserId { get; set; }
        //public User Creator { get; set; }
        //public List<...> Images;
        public IFormFile Image { get; set; }
    }
}
