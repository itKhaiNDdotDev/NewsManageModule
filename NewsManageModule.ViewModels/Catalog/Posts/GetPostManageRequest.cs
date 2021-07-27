using NewsManageModule.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Posts
{
    public class GetPostManageRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> topicIDs { get; set; }
    }
}
