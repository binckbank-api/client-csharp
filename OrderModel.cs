namespace ClientCsharp
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    ///     The order update
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        ///     The number of the account
        /// </summary>
        [JsonProperty(PropertyName= "accountNumber", Required = Required.Always)]
        public string AccountNumber { get; set; }

        /// <summary>
        ///     Order sequence number for the account
        /// </summary>
        [JsonProperty(PropertyName = "number", Required = Required.Always)]
        public long Number { get; set; }

        /// <summary>
        ///     Instrument for which the order has been placed
        /// </summary>
        [JsonProperty(PropertyName = "instrument", Required = Required.Always)]
        public InstrumentModel Instrument { get; set; }

        /// <summary>
        ///     Order status
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public string Status { get; set; }

        /// <summary>
        ///     [Optional] Limit price
        /// </summary>
        [JsonProperty(PropertyName = "limitPrice", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public decimal? LimitPrice { get; set; }

        /// <summary>
        ///     [Optional] Order (price condition) type
        /// </summary>
        [JsonProperty(PropertyName = "type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OrderType { get; set; }

        /// <summary>
        ///    [Optional] Expiration date 
        /// </summary>
        [JsonProperty(PropertyName = "expirationDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        ///     Date and time of update
        /// </summary>
        [JsonProperty(PropertyName = "dt", Required = Required.Always)]
        public DateTime TransactionDateTime { get; set; }

        /// <summary>
        ///     [Optional] Combination strategy. Pay or Receive
        /// </summary>
        [JsonProperty(PropertyName = "combinationCondition", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Condition { get; set; }

        /// <summary>
        ///     [Optional] Order reference id
        /// </summary>
        [JsonProperty(PropertyName = "referenceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; set; }
    }

    public class InstrumentModel
    {
        public string Id { get; set; }
    }
}
