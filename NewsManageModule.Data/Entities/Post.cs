using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Entities
{
    //News Posts Details
    public class Post
    {
        public int ID { get; set; } //News Post ID - PK
        //public int TID { get; set; }    //Topic ID - FK
        public string Head { get; set; }
        public string Content { get; set; }
        public int UID { get; set; }    //Creator - User ID - FK
        public DateTime Time { get; set; }
        public int ViewCount { get; set; }
        public List<History> Histories { get; set; }    //1 Post relationships whith 'n' EditVersions (Histories)
        public User Creator { get; set; }   //A Post ('n') - have - (1) a creator (User)
        public List<PostInTopic> PostInTopics { get; set; } //A Post ('n') - canbe in - ('n') some topics
        public List<Resource> Resources { get; set; }   ////A Post (1) - have - ('n') some images (Resources)
    }
}
