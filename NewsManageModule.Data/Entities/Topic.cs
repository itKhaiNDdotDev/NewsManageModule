using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Entities
{
    //List Topics
    public class Topic
    {
        public int TID { get; set; }    //Topic ID - PK
        public string TName { get; set; }   //Topic Name
        public List<PostInTopic> PostsInTopic { get; set; } //A Topic ('n') - can have - ("n") many post
    }
}
