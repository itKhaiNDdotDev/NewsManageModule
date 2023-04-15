using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Entities
{
    //Relationship for 'n' Posts - to - 'n' Topics
    public class PostInTopic
    {
        public int ID { get; set; } //News Post (ID) - PK,FK 
        public int TID { get; set; }    //Topic (ID) -  - PK,FK
        public Post Post { get; set; }  //Object to map with Posts
        public Topic Topic { get; set; }    //Object to map with Topics

    }
}
