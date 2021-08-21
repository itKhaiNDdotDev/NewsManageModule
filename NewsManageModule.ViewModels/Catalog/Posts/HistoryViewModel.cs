using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManageModule.ViewModels.Catalog.Posts
{
    public class HistoryViewModel
    {
        public DateTime EditTime { get; set; }
        public string OldHeader { get; set; }
        public string NewHeader { get; set; }
        public string OldContent { get; set; }
        public string NewContent { get; set; }

    }
}
