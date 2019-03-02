namespace ClientCsharp
{
    using System;

    public class Order
    {
        public string AccountNumber { get; set; }
        public int Number { get; set; }
        public Instrument Instrument { get; set; }
        public string Status { get; set; }
        public decimal LimitPrice { get; set; }
        public string Type { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime Dt { get; set; }
    }

    public class Instrument
    {
        public string Id { get; set; }
    }
}
