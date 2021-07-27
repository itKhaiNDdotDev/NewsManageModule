using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Posts
{
    public class GetPostPublicRequest : PagingRequestBase
    {
        public int? topicID { get; set; }
    }
}
