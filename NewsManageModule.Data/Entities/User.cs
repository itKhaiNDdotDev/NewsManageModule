using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.Data.Entities
{
    //Login and public Info of list creators
    public class User : IdentityUser<Guid>
    {
        //public int UID { get; set; }    //User ID - PK
        //public string Username { get; set; }    //Username - UNIQUE (for login)
        public string Fullname { get; set; }    //Public name of Crator
        //public string Password { get; set; }    //(for login)
        //public DateTime RegistDate { get; set; }
        public List<Post> Posts { get; set; }  //A User (1) - can create - ('n') many Posts (News)
        //public List<History> Edits { get; set; }    //A User {1} - can do - ('n') edit tasks (Histories)  ====== ERROR
    }
}
