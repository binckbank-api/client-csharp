﻿using System;
using System.Collections.Generic;

namespace StreamerClientExample
{
    public class InstrumentQuote
    {
        public string Id { get; set; }
        public int Lvl { get; set; }
        public List<Qt> Qt { get; set; }
        public DateTime Sdt { get; set; }
    }

    public class Qt
    {
        public string Msg { get; set; }
        public string Typ { get; set; }
        public double Prc { get; set; }
        public DateTime Dt { get; set; }
        public int Vol { get; set; }
    }
}
