using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Entities
{
    //Histories for: some Users can edit some Posts many times
    public class History
    {
        public int HID { get; set; }    //History ID - PK
        public int ID { get; set; } //Post (ID) is edited - FK
        public int UID { get; set; }    //User (ID) edit post - FK
        public DateTime EditTime { get; set; }  //Edit time
        public string OldHeader { get; set; }
        public string NewHeader { get; set; }
        public string OldContent { get; set; }
        public string NewContent { get; set; }
        public Post Post { get; set; }  //some edits (Histories) ('n') - of - (1) a Post
        public User Editor { get; set; }    //Some edits (Histories) ('n") - by - (1) a User
    }
}
