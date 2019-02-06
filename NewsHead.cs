using System;
using System.Collections.Generic;

namespace StreamerClientExample
{
    public class NewsHead
    {
        public string Head { get; set; }
        public string Body { get; set; }
        public string Fmt { get; set; }
        public DateTime Dt { get; set; }
        public List<string> Iids { get; set; }
    }
}
