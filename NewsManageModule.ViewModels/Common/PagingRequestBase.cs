using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Common
{
    public class PagingRequestBase
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
